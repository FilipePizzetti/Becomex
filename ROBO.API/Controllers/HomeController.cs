using Microsoft.AspNetCore.Mvc;
using ROBO.Domain.Enums;
using ROBO.Domain.Interface;

namespace ROBO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoboController : ControllerBase
    {
        private readonly IRoboService _roboService;

        public RoboController(IRoboService roboService)
        {
            _roboService = roboService;
        }

        [HttpGet("/v1/LigarRobo")]
        public IActionResult GetRoboState()
        {
            var state = _roboService.LigarRobo();
            return Ok(state);
        }
        [HttpPost("/v1/RotacionarCabeca")]
        public IActionResult RotacionarCabeca([FromBody] ECabecaRotacao rotacao)
        {
            var state = _roboService.RotacionarCabeca(rotacao);
            return Ok(state);
        }
        [HttpPost("/v1/InclinarCabeca")]
        public IActionResult InclinarCabeca([FromBody] ECabecaInclinacao inclinacao)
        {
            var state = _roboService.InclinarCabeca(inclinacao);
            return Ok(state);
        }
        [HttpPost("/v1/MoverCotovelo")]
        public IActionResult MoverCotovelo([FromBody] ECotoveloPosicao posicao, EBracoLado lado)
        {
            var state = _roboService.MoverCotovelo(posicao, lado);
            return Ok(state);
        }
        [HttpPost("/v1/RotacionarPulso")]
        public IActionResult RotacionarPulso([FromBody] EPulsoRotacao rotacao, EBracoLado lado)
        {
            var state = _roboService.RotacionarPulso(rotacao, lado);
            return Ok(state);
        }
    }
}
