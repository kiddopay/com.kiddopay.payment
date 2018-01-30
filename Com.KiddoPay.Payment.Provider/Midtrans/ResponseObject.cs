using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public class ResponseObject
    {
        public short status_code { get; set; }
        public string status_message { get; set; }
        public string[] validation_messages { get; set; }
        public string redirect_url { get; set; }
        public string token_id { get; set; }
        public string eci { get; set; }
    }
}
