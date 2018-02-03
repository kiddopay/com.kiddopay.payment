using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public class ResponseObject
    {
        [JsonProperty("status_code")]
        public short StatusCode { get; set; }
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }
}
