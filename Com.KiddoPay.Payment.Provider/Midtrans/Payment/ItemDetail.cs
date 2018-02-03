using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment
{
    public class ItemDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("quantity")]
        public uint Quantity { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }
    }
}
