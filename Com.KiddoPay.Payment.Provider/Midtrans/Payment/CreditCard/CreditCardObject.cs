using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard
{
    public class CreditCardObject : IPaymentObject
    {
        [JsonProperty("card_number")]
        public string CardNumber { get; set; }
        [JsonProperty("card_ccv")]
        public string CCV { get; set; }
        [JsonProperty("card_exp_month")]
        public ushort ExpiryMonth { get; set; }
        [JsonProperty("card_exp_year")]
        public uint ExpiryYear { get; set; }
        [JsonProperty("bank")]
        public string Bank { get; set; }
        [JsonProperty("secure")]
        public bool Secure { get; set; }
        [JsonProperty("gross_amount")]
        public decimal GrossAmount { get; set; }
        [JsonProperty("installment_term")]
        public string InstallmentTerm { get; set; }
        [JsonProperty("token_id")]
        public string Token { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("point")]
        public bool Point { get; set; }
    }
}
