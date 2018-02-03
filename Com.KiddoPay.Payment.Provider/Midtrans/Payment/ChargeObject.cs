using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment
{
    public abstract class ChargeObject : IChargeObject
    {
        public ChargeObject(string paymentType)
        {
            this.PaymentType = paymentType;
            ItemDetails = new HashSet<ItemDetail>();
        }

        [JsonProperty("payment_type")]
        public string PaymentType { get; }

        [JsonProperty("transaction_details")]
        public TransactionDetail TransactionDetails { get; set; }

        [JsonProperty("item_details")]
        public IEnumerable<ItemDetail> ItemDetails { get; set; }

        [JsonProperty("customer_details")]
        public CustomerDetail CustomerDetails { get; set; }

    }
}
