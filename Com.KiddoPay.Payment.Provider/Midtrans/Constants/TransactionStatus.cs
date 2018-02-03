using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public sealed class TransactionStatus
    {
        public const string CAPTURE = "capture";
        public const string DENY = "deny";
        public const string AUTHORIZE = "authorize";
    }
}
