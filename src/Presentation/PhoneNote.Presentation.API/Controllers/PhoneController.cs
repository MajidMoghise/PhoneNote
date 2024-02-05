using Microsoft.AspNetCore.Mvc;
using PhoneNote.Application.Contract.Services.People.Dtos;
using PhoneNote.Application.Contract.Services.Phones.Dtos;

namespace PhoneNote.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly ILogger<PhoneController> _logger;

        public PhoneController(ILogger<PhoneController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePhoneRequestDto request)
        {
            return null;
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePhoneRequestDto request)
        {
            return null;
        }
        [HttpPatch]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdatePhoneRequestDto request)
        {
            return null;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, [FromBody] DeletePhoneRequestDto request)
        {
            return null;
        }
    }
}
