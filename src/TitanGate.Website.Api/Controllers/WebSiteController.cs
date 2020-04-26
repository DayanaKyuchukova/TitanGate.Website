using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TitanGate.Website.Service.Abstract;
using TitanGate.Website.Service.Models;

namespace TitanGate.Website.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebSiteController : ControllerBase
    {
        private readonly IWebSiteService webSiteService;

        public WebSiteController(IWebSiteService webSiteService)
        {
            this.webSiteService = webSiteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByFilterAsync(
            [FromQuery] string sortBy,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var result = await webSiteService.GetByFilterAsync(sortBy, page, pageSize);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] WebSiteRequestModel model)
        {
            await webSiteService.CreateAsync(model);

            return Ok();
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int id,
            [FromBody] WebSiteRequestModel model)
        {
            await webSiteService.UpdateAsync(id, model);

            return NoContent();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await webSiteService.DeleteAsync(id);

            return NoContent();
        }
    }
}
