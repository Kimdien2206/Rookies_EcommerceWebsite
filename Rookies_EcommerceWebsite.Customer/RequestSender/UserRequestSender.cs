using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rookies_EcommerceWebsite.Customer.Interface;
using Rookies_EcommerceWebsite.Customer.Models;
using System.Net.Http.Headers;

namespace Rookies_EcommerceWebsite.Customer.RequestSender
{
    public class UserRequestSender : IUserRequestSender
    {
        private readonly string _baseURL = "https://localhost:7144/api/User/";

        public UserRequestSender()
        {
        }
        public async Task<UserInfo> Update(string id, UserInfo entity, string token)
        {
            HttpClient _httpClient = new HttpClient();

            //Passing service base url
            _httpClient.BaseAddress = new Uri(_baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Define request data format
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource GetAllProducts using HttpClient
            HttpResponseMessage Res = await _httpClient.PatchAsJsonAsync<UserInfo>(id, entity);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Product list
                return JsonConvert.DeserializeObject<UserInfo>(EmpResponse);
            }
            //returning the employee list to view
            return null;
        }
    }
}
