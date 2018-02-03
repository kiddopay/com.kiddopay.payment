using Com.KiddoPay.Payment.Provider.Midtrans;
using Com.KiddoPay.Payment.Provider.Midtrans.Payment;
using Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Com.KiddoPay.Payment.Provider.XTest
{
    public class CreditCardTest
    {
        CreditCardObject GetCreditCard()
        {
            return new CreditCardObject()
            {
                CardNumber = "4111 1111 1111 1111",
                CCV = "123",
                ExpiryMonth = 12,
                ExpiryYear = 2018,
                Secure = false,
                GrossAmount = 50000
            };
        }

        CreditCardCharge GetCreditCardCharge(CreditCardObject creditCard)
        {
            CreditCardCharge charge = new CreditCardCharge(creditCard);
            AddressInfo address = new AddressInfo()
            {
                FirstName = "BUDI",
                LastName = "UTOMO",
                Email = "test@midtrans.com",
                Phone = "+628123456",
                Address = "Sudirman",
                City = "Jakarta",
                PostalCode = "12190",
                CountryCode = "IDN"
            };
            charge.TransactionDetails = new TransactionDetail()
            {
                OrderID = Guid.NewGuid().ToString("N"),
                GrossAmount = 50000
            };
            charge.CustomerDetails = new CustomerDetail()
            {
                FirstName = "BUDI",
                LastName = "UTOMO",
                Email = "test@midtrans.com",
                Phone = "+628123456",
                BillingAddress = address,
                ShippingAddress = address
            };
            HashSet<ItemDetail> itemDetails = charge.ItemDetails as HashSet<ItemDetail>;
            itemDetails.Add(new ItemDetail()
            {
                Id = Guid.NewGuid().ToString("N"),
                Brand = "KiddoPay",
                Name = "Top-up 50k",
                Category = "e-Commerce",
                MerchantName = "KiddoPay",
                Price = 50000,
                Quantity = 1
            });

            return charge;
        }

        [Fact]
        public async Task Test_GetToken()
        {
            Client client = new Client();
            CreditCardObject creditCard = GetCreditCard();
            await client.GetTokenAsync(creditCard)
                .ContinueWith(tokenTask =>
                {
                    var tokenResponse = tokenTask.Result;
                    Assert.IsAssignableFrom<TokenResponseObject>(tokenResponse);
                    Assert.Equal(tokenResponse.StatusCode, 200);
                });
        }

        [Fact]
        public async Task Test_Charge()
        {
            Client client = new Client();
            CreditCardObject creditCard = GetCreditCard();
            await client.GetTokenAsync(creditCard)
                .ContinueWith(tokenTask =>
                {
                    var tokenResponse = tokenTask.Result;
                    Assert.IsAssignableFrom<TokenResponseObject>(tokenResponse);
                    Assert.Equal(tokenResponse.StatusCode, 200);

                    creditCard.Token = tokenResponse.Token;
                    return client.ChargeAsync(GetCreditCardCharge(creditCard))
                    .ContinueWith(chargeTask =>
                    {
                        var chargeResponse = chargeTask.Result;

                        Assert.IsAssignableFrom<ChargeResponseObject>(chargeResponse);
                        Assert.InRange(chargeResponse.StatusCode, 200, 201);
                        Assert.Equal(chargeResponse.TransactionStatus, TransactionStatus.CAPTURE);
                        if (chargeResponse.StatusCode == 201)
                            Assert.Equal(chargeResponse.FraudStatus, FraudStatus.CHALLENGE);
                        else
                            Assert.Equal(chargeResponse.FraudStatus, FraudStatus.ACCEPT);
                    });
                }).Unwrap();
        }

        [Fact]
        public async Task Test_Charge_Then_Approve()
        {
            Client client = new Client();
            CreditCardObject creditCard = GetCreditCard();
            await client.GetTokenAsync(creditCard)
                .ContinueWith(tokenTask =>
                {
                    var tokenResponse = tokenTask.Result;
                    Assert.IsAssignableFrom<TokenResponseObject>(tokenResponse);
                    Assert.Equal(tokenResponse.StatusCode, 200);

                    creditCard.Token = tokenResponse.Token;
                    return client.ChargeAsync(GetCreditCardCharge(creditCard))
                    .ContinueWith(chargeTask =>
                    {
                        var chargeResponse = chargeTask.Result;

                        Assert.IsAssignableFrom<ChargeResponseObject>(chargeResponse);
                        Assert.InRange(chargeResponse.StatusCode, 200, 201);
                        Assert.Equal(chargeResponse.TransactionStatus, TransactionStatus.CAPTURE);

                        if (chargeResponse.StatusCode == 201)
                        {
                            Assert.Equal(chargeResponse.FraudStatus, FraudStatus.CHALLENGE);
                            return client.ApproveAsync(chargeResponse.TransactionId)
                              .ContinueWith(approveTask =>
                              {
                                  var approveResponse = approveTask.Result;
                                  Assert.IsAssignableFrom<ChargeResponseObject>(approveResponse);
                                  Assert.Equal(approveResponse.StatusCode, 200);
                                  Assert.Equal(approveResponse.TransactionStatus, TransactionStatus.CAPTURE);
                                  Assert.Equal(approveResponse.FraudStatus, FraudStatus.ACCEPT);
                              });
                        }
                        else
                        {
                            Assert.Equal(chargeResponse.FraudStatus, FraudStatus.ACCEPT);
                            return Task.FromResult(chargeResponse);
                        }
                    }).Unwrap();
                }).Unwrap();
        }
    }
}
