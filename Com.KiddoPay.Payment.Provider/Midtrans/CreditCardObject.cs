using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public class MidtransCreditCardObject
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public short ExpiryMonth { get; set; }
        public short ExpiryYear { get; set; }
        public string Bank { get; set; }
        public bool Secure { get; set; }
        public decimal GrossAmount { get; set; }
        public string InstallmentTerm { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public bool Point { get; set; }
    }
}
