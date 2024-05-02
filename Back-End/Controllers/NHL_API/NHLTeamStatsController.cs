using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Sports_Stats_Back_End.Controllers.NHL_API
{
    [ApiController]
    [Route("api/[controller]")]
    public class NHLTeamStatsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public NHLTeamStatsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetNHLTeamStats([FromHeader] string teamId)
        {
            if (string.IsNullOrEmpty(teamId))
            {
                return BadRequest("Team ID is required");
            }

            try
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Team Id {0}", teamId);
                var client = _clientFactory.CreateClient();
                var uri = new Uri($"https://nhl-api5.p.rapidapi.com/team-statistic?teamId={teamId}");
                Console.WriteLine("Uri {0}", uri);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Headers =
                    {
                        { "X-RapidAPI-Key", "247fad3da0msh0578dc9195d4f0bp1c399ejsnbe542042ec49" },
                        { "X-RapidAPI-Host", "nhl-api5.p.rapidapi.com" },
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