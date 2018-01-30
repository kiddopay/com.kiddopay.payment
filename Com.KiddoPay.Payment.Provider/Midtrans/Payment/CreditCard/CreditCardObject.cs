using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard
{
    public class CreditCardObject : IPaymentObject
    {
        public string card_number { get; set; }
        public string card_ccv { get; set; }
        public ushort card_exp_month { get; set; }
        public uint card_exp_year { get; set; }
        public string bank { get; set; }
        public bool secure { get; set; }
        public decimal gross_amount { get; set; }
        public string installment_term { get; set; }
        public string token_id { get; set; }
        public string type { get; set; }
        public bool point { get; set; }
    }
}
