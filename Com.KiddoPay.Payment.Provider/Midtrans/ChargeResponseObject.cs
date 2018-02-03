using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public class ChargeResponseObject : ResponseObject
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("gross_amount")]
        public decimal GrossAmount { get; set; }
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }
        [JsonProperty("transaction_time")]
        public DateTime TransactionTime { get; set; }
        [JsonProperty("transaction_status")]
        public string TransactionStatus { get; set; }
        [JsonProperty("fraud_status")]
        public string FraudStatus { get; set; }
        [JsonProperty("masked_card")]
        public string MaskedCard { get; set; }
        [JsonProperty("bank")]
        public string Bank { get; set; }
        [JsonProperty("approval_code")]
        public string ApprovalCode { get; set; }
        [JsonProperty("eci")]
        public string Eci { get; set; }
        [JsonProperty("channel_response_code")]
        public string ChannelResponseCode { get; set; }
        [JsonProperty("channel_response_message")]
        public string ChannelResponseMessage { get; set; }
    }
}
