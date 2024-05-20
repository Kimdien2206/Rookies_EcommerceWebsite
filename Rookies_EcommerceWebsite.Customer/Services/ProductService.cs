using Rookies_EcommerceWebsite.Customer.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;


namespace Rookies_EcommerceWebsite.Customer.Services
{
    public class ProductService
    {
        private readonly string BaseUrl = "https://localhost:7144/api/";

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllProducts using HttpClient
                HttpResponseMessage Res = await client.GetAsync("Product");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Product list
                    products = JsonConvert.DeserializeObject<List<Product>>(EmpResponse);
                }
                //returning the employee list to view
                return products;
            }
        }
    }
}
