using Com.KiddoPay.Payment.Provider.Midtrans;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Com.KiddoPay.Payment.Provider.XTest
{
    public class MidtransTest
    {
        [Fact]
        public Task GetToken()
        {
            Client client = new Client();
            return client.GetToken(new MidtransCreditCardObject())
                .ContinueWith(resultTask =>
                {
                    var result = resultTask.Result;
                    Assert.IsAssignableFrom<ResponseObject>(result);
                    Assert.Equal(result.status_code, 200);
                });
        }
    }
}
