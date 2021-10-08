using Microsoft.AspNetCore.Mvc;
using NPF_Teste.Objectos;

namespace NPF_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        [HttpPost]

        public IActionResult Post(Root r)
        {
            return Ok(Calculator.IsMultipleOf11(r.numbers));
        }
    }
}
