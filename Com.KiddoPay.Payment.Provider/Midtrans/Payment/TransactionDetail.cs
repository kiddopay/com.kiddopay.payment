using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment
{
    public class TransactionDetail
    {
        [JsonProperty("order_id")]
        public string OrderID { get; set; }

        [JsonProperty("gross_amount")]
        public decimal GrossAmount { get; set; }
    }
}
