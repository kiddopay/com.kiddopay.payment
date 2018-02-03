using Com.KiddoPay.Payment.Provider.Midtrans.Payment;
using Com.KiddoPay.Payment.Provider.Midtrans.Payment.CreditCard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Com.KiddoPay.Payment.Provider.Midtrans
{
    public class Client
    {
        //https://api-docs.midtrans.com/#http-s-header
        const string CLIENT_KEY = "SB-Mid-client-1AGVMRf91Kr-NXc0";
        const string SERVER_KEY = "SB-Mid-server-qQfQ9XmYEQPqlJermGyIRftb";
        const string BASE_URI = "https://api.sandbox.midtrans.com/";
        HttpClient http;

        public Client()
        {
            this.http = new HttpClient();
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(SERVER_KEY + ":")));
        }
        private string GetCCQuery(CreditCardObject creditCard)
        {
            List<string> info = new List<string>();
            info.Add(string.Format("card_number={0}", creditCard.CardNumber));
            info.Add(string.Format("card_cvv={0}", creditCard.CCV));
            info.Add(string.Format("card_exp_month={0}", creditCard.ExpiryMonth));
            info.Add(string.Format("card_exp_year={0}", creditCard.ExpiryYear));
            info.Add(string.Format("client_key={0}", CLIENT_KEY));
            info.Add(string.Format("secure={0}", creditCard.Secure));
            info.Add(string.Format("gross_amount={0}", creditCard.GrossAmount));
            return string.Join('&', info);
        }
        public Task<TokenResponseObject> GetTokenAsync(CreditCardObject creditCard)
        {
            const string endpoint = "v2/token";
            UriBuilder uriBuilder = new UriBuilder(BASE_URI);
            uriBuilder.Path = endpoint;
            uriBuilder.Query = GetCCQuery(creditCard);

            return this.http.GetAsync(uriBuilder.Uri)
                .ContinueWith(responseTask =>
                {
                    var response = responseTask.Result;
                    return response.Content.ReadAsStringAsync().ContinueWith(readTask =>
                    {
                        var json = readTask.Result;
                        return JsonConvert.DeserializeObject<TokenResponseObject>(json);
                    });
                }).Unwrap();
        }

        public Task<ChargeResponseObject> ChargeAsync(ChargeObject chargeObject)
        {
            const string endpoint = "v2/charge";
            UriBuilder uriBuilder = new UriBuilder(BASE_URI);
            uriBuilder.Path = endpoint;

            string chargeObjectJson = JsonConvert.SerializeObject(chargeObject);
            HttpContent content = new StringContent(chargeObjectJson, Encoding.UTF8, "application/json");
            return this.http.PostAsync(uriBuilder.Uri, content)
            .ContinueWith(responseTask =>
            {
                var response = responseTask.Result;
                return response.Content.ReadAsStringAsync().ContinueWith(readTask =>
                {
                    var json = readTask.Result;
                    return JsonConvert.DeserializeObject<ChargeResponseObject>(json);
                });
            }).Unwrap();
        }

        public Task<ChargeResponseObject> ApproveAsync(string orderOrTransactionId)
        {
            const string endpoint = "v2/{0}/approve"; ;
            UriBuilder uriBuilder = new UriBuilder(BASE_URI);
            uriBuilder.Path = string.Format(endpoint, orderOrTransactionId);

            HttpContent content = new StringContent("{}", Encoding.UTF8, "application/json");
            return this.http.PostAsync(uriBuilder.Uri, content)
            .ContinueWith(responseTask =>
            {
                var response = responseTask.Result;
                return response.Content.ReadAsStringAsync().ContinueWith(readTask =>
                {
                    var json = readTask.Result;
                    return JsonConvert.DeserializeObject<ChargeResponseObject>(json);
                });
            }).Unwrap();
        }
    }
}
