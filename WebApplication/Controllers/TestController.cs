using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public async Task<IHttpActionResult> Get(string url)
        {
            var isValidUrl = Uri.TryCreate(url, UriKind.Absolute, out _);
            if (!isValidUrl)
            {
                return BadRequest("Given url is not valid.");
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            try
            {

                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
