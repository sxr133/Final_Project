using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Sports_Stats_Back_End.Controllers.NHL_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public TestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetTest() { 
  
          try
            {
                var client = _clientFactory.CreateClient();
                var uri = new Uri($"https://api-basketball-nba.p.rapidapi.com/nbastandings?year=2024&group=division");
                Console.WriteLine("Uri {0}", uri);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Headers =
                    {
                        { "X-RapidAPI-Key", "9e673511f7mshf50a8bb66cecc6cp10c387jsn2542bfbedbf6" },
                        { "X-RapidAPI-Host", "api-basketball-nba.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    // Parse the JSON string into a JObject
                    var jsonObject = JObject.Parse(body);

                    return Ok(jsonObject.ToString()); // Directly return the JSON object if the API's response is suitable


                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}