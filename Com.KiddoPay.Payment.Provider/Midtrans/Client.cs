using Com.KiddoPay.Payment.Provider.Midtrans.Payment;
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
        const string CLIENT_KEY = "SB-Mid-client-1AGVMRf91Kr-NXc0" + ":";
        const string BASE_URI = "https://api.sandbox.midtrans.com/";
        HttpClient http;

        public Client()
        {
            this.http = new HttpClient();
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(CLIENT_KEY)));

            //http.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //http.DefaultRequestHeaders.Add("Accept", "application/json");
            //http.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(CLIENT_KEY))));
        }

        public Task<ResponseObject> GetTokenAsync(IPaymentObject paymentObject)
        {
            const string endpoint = "v2/token";
            UriBuilder uriBuilder = new UriBuilder(BASE_URI);
            uriBuilder.Path = endpoint;

            uriBuilder.Query = string.Join('&', new string[] {
                "card_number=4111 1111 1111 1111",
                "card_cvv=123",
                "card_exp_month=12",
                "card_exp_year=2018",
                "client_key=SB-Mid-client-1AGVMRf91Kr-NXc0",
                "secure=true",
                "gross_amount=50000"
            });

            return this.http.GetAsync(uriBuilder.Uri)
                .ContinueWith(responseTask =>
                {
                    var response = responseTask.Result;
                    return response.Content.ReadAsStringAsync().ContinueWith(readTask =>
                    {
                        var json = readTask.Result;
                        return JsonConvert.DeserializeObject<ResponseObject>(json);
                    });
                }).Unwrap();
        }

        public Task<ResponseObject> ChargeAsync(ChargeObject chargeObject)
        {
            const string endpoint = "v2/charge";
            UriBuilder uriBuilder = new UriBuilder(BASE_URI);
            uriBuilder.Path = endpoint;

            HttpContent content = new StringContent(JsonConvert.SerializeObject(chargeObject), Encoding.UTF8, "application/json");
            return this.http.PostAsync(uriBuilder.Uri, content)
            .ContinueWith(responseTask =>
            {
                var response = responseTask.Result;
                return response.Content.ReadAsStringAsync().ContinueWith(readTask =>
                {
                    var json = readTask.Result;
                    return JsonConvert.DeserializeObject<ResponseObject>(json);
                });
            }).Unwrap();
        }
    }
}
