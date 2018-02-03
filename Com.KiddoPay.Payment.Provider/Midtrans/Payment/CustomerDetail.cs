using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment
{
    public class CustomerDetail
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("billing_address")]
        public AddressInfo BillingAddress { get; set; }
        [JsonProperty("shipping_address")]
        public AddressInfo ShippingAddress { get; set; }
    }
}
