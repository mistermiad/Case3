using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace calculator.frontend.Controllers
{
    public class AttributeController : Controller
    {
        private readonly static string base_url =
            Environment.GetEnvironmentVariable("CALCULATOR_BACKEND_URL");
        const string api = "api/Calculator";
        private (string prime, string odd, double sqrt) ExecuteOperation(string number)
        {
            bool? raw_prime =  null;
            bool? raw_odd = null;
            double raw_sqrt = 0;
            var clientHandler = new HttpClientHandler();
            var client = new HttpClient(clientHandler);
            var url = $"{base_url}/{api}/number_attribute?number={number}";
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
                if (sqrt != null)
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
            double getSquareRoot = 0;
            if (number2 <= -0.00000000000000001 || number2 >= 0.00000000000000001) {
                getSquareRoot = raw_sqrt;
            }

            return (isPrime,isOdd, getSquareRoot);
        }
        public IActionResult Index()
        {
            return View();
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
