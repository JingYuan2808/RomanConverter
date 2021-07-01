using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RomanConvertWebApi.Controllers
{
    [ApiController]
    public class RomanConverterController : ControllerBase
    {
        private readonly ILogger<RomanConverterController> _logger;
        private readonly IRomanConverterService _romanConverterService;
        public RomanConverterController(ILogger<RomanConverterController> logger, IRomanConverterService romanConverterService)
        {
            _logger = logger;
            _romanConverterService = romanConverterService;
        }

        [HttpGet]
        [Route("[controller]/RomanToDigital/{roman}")]
        public IActionResult RomanToDigital(string roman)
        {
            return Ok(_romanConverterService.RomanToDigital(roman));
        }

        [HttpGet]
        [Route("[controller]/DigitalToRoman/{digital}")]
        public IActionResult DigitalToRoman(int digital)
        {
            try
            {
                return Ok(_romanConverterService.DigitalToRoman(digital));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        [HttpGet]
        [Route("[controller]")]
        public string Get()
        {
            return "API: RomanConverter/RomanToDigital/roman and RomanConverter/DigitalToRoman/digital";

        }
    }
}
