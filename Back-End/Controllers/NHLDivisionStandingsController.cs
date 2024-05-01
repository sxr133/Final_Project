using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Sports_Stats_Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NHLDivisionStandingsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public NHLDivisionStandingsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetNHLDivisionStandings([FromHeader] string conference)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var uri = new Uri("https://nhl-api5.p.rapidapi.com/nhlstandings?year=2024&group=division");

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

                    // Filter for the specified conference
                    var conferenceData = jsonObject["children"].FirstOrDefault(c => c["name"].ToString().Contains(conference));

                    if (conferenceData != null)
                    {
                        return Ok(conferenceData.ToString());
                    }
                    else
                    {
                        return NotFound($"{conference} Conference data not found.");
                    }

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
