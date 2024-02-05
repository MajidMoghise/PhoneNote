using Microsoft.AspNetCore.Mvc;
using PhoneNote.Application.Contract.Services.People.Dtos;
using PhoneNote.Presentation.API.Controllers._Base;

namespace PhoneNote.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : BasicController
    {

        private readonly ILogger<PhoneController> _logger;

        public PersonController(ILogger<PhoneController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return null;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePersonRequestDto request)
        {
            return null;
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,[FromBody]UpdatePersonRequestDto request)
        {
            return null;
        }
        [HttpPatch()]
        public async Task<IActionResult> Patch(int id,[FromBody]UpdatePersonRequestDto request)
        {
            return null;
        }
        [HttpDelete()]
        public async Task<IActionResult> Delete(int id,[FromBody]DeletePersonRequestDto request)
        {
            return null;
        }
    }
}
