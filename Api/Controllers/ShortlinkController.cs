using Application.Contracts;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get(string shortlink)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateShortlinkViewModelRequest model)
        {
            _shortlinkService.Create(model);
            return Ok();
        }
    }
}
