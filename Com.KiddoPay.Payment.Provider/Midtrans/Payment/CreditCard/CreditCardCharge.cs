using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard
{
    public class CreditCardCharge : ChargeObject
    {
        public CreditCardCharge(CreditCardObject creditCard) : base(Midtrans.PaymentType.CREDIT_CARD)
        {
            //this.CreditCard = creditCard;
            this.CreditCard = new CreditCardToken(creditCard);
        }
        [JsonProperty("credit_card")]
        public CreditCardToken CreditCard { get; }
    }
    public class CreditCardToken
    {
        public CreditCardToken(CreditCardObject cco)
        {
            this.Token = cco.Token;
        }
        [JsonProperty("token_id")]
        public string Token { get; set; }
    }
}
