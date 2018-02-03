using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard
{
    public class CreditCardCharge : ChargeObject
    {
        public CreditCardCharge() : base(Payment.PaymentType.CREDIT_CARD)
        {

        }
    }
}
