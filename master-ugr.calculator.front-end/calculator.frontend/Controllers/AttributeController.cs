using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace calculator.frontend.Controllers
{
    public class AttributeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private string base_url =
            Environment.GetEnvironmentVariable("CALCULATOR_BACKEND_URL") ??
            "https://ds11-calculator-backend-uat.azurewebsites.net/";
        const string api = "api/Calculator";
        private (string prime, string odd, double sqrt) ExecuteOperation(string number)
        {
            bool? raw_prime =  null;
            bool? raw_odd = null;
            double raw_sqrt = 0;
            var clientHandler = new HttpClientHandler();
            var client = new HttpClient(clientHandler);
            var url = $"{base_url}api/Calculator/number_attribute?number={number}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };
            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;
                var json = JObject.Parse(body);
                var prime = json["prime"];
                var odd = json["odd"];
                var sqrt = json["square_root"];
                if (prime != null)
                {
                    raw_prime = prime.Value<bool>();
                }
                if (odd != null)
                {
                    raw_odd = odd.Value<bool>();
                }
                if (sqrt != 0)
                {
                    raw_sqrt = sqrt.Value<Double>();
                }

            }
            var isPrime = "unknown";
            if (raw_prime != null && raw_prime.Value)
            {
                isPrime = "Yes";
            }
            else if (raw_prime != null && !raw_prime.Value)
            {
                isPrime = "No";
            }
            var isOdd = "unknown";
            if (raw_odd != null && raw_odd.Value)
            {
                isOdd = "Yes";
            }
            else if (raw_odd != null && !raw_odd.Value)
            {
                isOdd = "No";
            }
            var getSquareRoot = 0;
            if (raw_sqrt != 0) {
                getSquareRoot = raw_sqrt.Value<Double>();
            }

            return (isPrime,isOdd, getSquareRoot);
        }
        [HttpPost]
        public ActionResult Index(string number)
        {
            var result = ExecuteOperation(number);
            ViewBag.IsPrime = result.prime;
            ViewBag.IsOdd = result.odd;
            ViewBag.getSquareRoot = result.sqrt;
            return View();
        }
    }
}
