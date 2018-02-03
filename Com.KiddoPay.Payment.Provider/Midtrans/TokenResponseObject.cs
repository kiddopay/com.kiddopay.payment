using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public class TokenResponseObject : ResponseObject
    {
        [JsonProperty("validation_messages")]
        public string[] ValidationMessage { get; set; }
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
        [JsonProperty("token_id")]
        public string Token { get; set; }
        [JsonProperty("eci")]
        public string Eci { get; set; }
    }
}
