using Application.Contracts;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortlinkController : Controller
    {
        private readonly IShortlinkService _shortlinkService;

        public ShortlinkController(IShortlinkService shortlinkService)
        {
            _shortlinkService = shortlinkService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery][Required] string shortlink)
        {
            var model = _shortlinkService.Get(new GetShorlinkViewModelRequest() { ShortUrl = shortlink });
            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(CreateShortlinkViewModelRequest model)
        {
            _shortlinkService.Create(model);
            return Ok();
        }
    }
}
