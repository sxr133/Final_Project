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
        public async Task<IActionResult> GetTest([FromHeader] string division) { 
  
            if (string.IsNullOrEmpty(division))
            {
                return BadRequest("division ID is required");
            }

            try
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("division{0}", division);
                var client = _clientFactory.CreateClient();
                var uri = new Uri($"https://sports-information.p.rapidapi.com/nhl/standings?year=2024&group={division}");
                Console.WriteLine("Uri {0}", uri);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Headers =
                    {
                        { "X-RapidAPI-Key", "247fad3da0msh0578dc9195d4f0bp1c399ejsnbe542042ec49" },
                        { "X-RapidAPI-Host", "sports-information.p.rapidapi.com" },
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