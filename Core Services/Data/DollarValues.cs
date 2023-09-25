using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Core_Services.Data
{
    public class DollarValues
    {
        public static decimal? PriceBuy { get; set; }
        public static decimal? PriceSell { get; set; }

        public static string? Date { get; set; }

        public static async void GetLastDollarValues()
        {
            using (var client = new HttpClient())
            {
                string url = "https://api.bluelytics.com.ar/v2/latest";
                client.DefaultRequestHeaders.Clear();

                var response = client.GetAsync(url).Result;
                var res = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(res);

                if (json.HasValues)
                {
                    var dollarBlueObject = json.Root["blue"];
                    var dollarBlueValues = JObject.FromObject(dollarBlueObject);

                    PriceBuy = (decimal?)dollarBlueValues.Root["value_buy"];
                    PriceSell = (decimal?)dollarBlueValues.Root["value_sell"];
                    Date = (string?)json.Root["last_update"];
                }
            }
        }
    }
}
