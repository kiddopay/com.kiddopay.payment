using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public sealed class FraudStatus
    {
        public const string ACCEPT = "accept";
        public const string CHALLENGE = "challenge";
        public const string DENY = "deny";
    }
}
