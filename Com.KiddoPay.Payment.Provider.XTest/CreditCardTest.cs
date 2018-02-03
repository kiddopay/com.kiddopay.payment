using Com.KiddoPay.Payment.Provider.Midtrans;
using Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Com.KiddoPay.Payment.Provider.XTest
{
    public class CreditCardTest
    {
        [Fact]
        public async Task GetToken()
        {
            Client client = new Client();
            await client.GetTokenAsync(new CreditCardObject())
                .ContinueWith(resultTask =>
                {
                    var result = resultTask.Result;
                    Assert.IsAssignableFrom<ResponseObject>(result);
                    Assert.Equal(result.status_code, 200);
                });
        }
    }
}
