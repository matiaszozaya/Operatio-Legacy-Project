using Newtonsoft.Json.Linq;

namespace MVC_App.Data
{
    public class DollarValues
    {
        public static decimal PriceBuy { get; set; }
        public static decimal PriceSell { get; set; }
        public static string Date { get; set; }

        public static async void GetLastDollarValues()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = "https://criptoya.com/api/binance/usdt/ars/1";
                    client.DefaultRequestHeaders.Clear();

                    var response = client.GetAsync(url).Result;
                    var res = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(res);

                    if (json.HasValues)
                    {
                        PriceBuy = (decimal)json.Root["totalBid"];
                        decimal.Round(PriceBuy, 1);

                        PriceSell = (decimal)json.Root["totalAsk"];
                        decimal.Round(PriceSell, 1);

                        Date = DateTime.Now.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                PriceBuy = 0;
                PriceSell = 0;
                Date = "";

                var exeption = ex.Message;
            }
        }
    }
}