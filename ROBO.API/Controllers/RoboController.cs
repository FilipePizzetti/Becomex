using Microsoft.AspNetCore.Mvc;
using ROBO.Domain.Enums;
using ROBO.Domain.Interface;

namespace ROBO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoboController : Controller
    {
        private readonly IRoboService _roboService;

        public RoboController(IRoboService roboService)
        {
            _roboService = roboService;
        }

        [HttpGet("/v1/LigarRobo")]
        public IActionResult GetRoboState()
        {
            var robo = _roboService.LigarRobo();
            return Json(new
            {
                cabeca = new
                {
                    inclinacao = robo.Cabeca.Inclinacao.ToString(),
                    rotacao = robo.Cabeca.Rotacao.ToString()
                },
                bracoDireito = new
                {
                    cotovelo = robo.BracoDireito.Cotovelo.Posicao.ToString(),
                    pulso = robo.BracoDireito.Pulso.Rotacao.ToString()
                },
                bracoEsquerdo = new
                {
                    cotovelo = robo.BracoEsquerdo.Cotovelo.Posicao.ToString(),
                    pulso = robo.BracoEsquerdo.Pulso.Rotacao.ToString()
                }
            });
        }
        [HttpPost("/v1/RotacionarCabeca")]
        public IActionResult RotacionarCabeca([FromBody] int rotacao)
        {
            var state = _roboService.RotacionarCabeca((ECabecaRotacao)rotacao);
            return Json(new
            {
                cabeca = new
                {
                    rotacao = state.Cabeca.Rotacao.ToString()
                }
            });
        }
        [HttpPost("/v1/InclinarCabeca")]
        public IActionResult InclinarCabeca([FromBody] int inclinacao)
        {
            var state = _roboService.InclinarCabeca((ECabecaInclinacao)inclinacao);
            return Json(new
            {
                cabeca = new
                {
                    inclinacao = state.Cabeca.Inclinacao.ToString()
                }
            });
        }
        [HttpPost("/v1/MoverCotovelo")]
        public IActionResult MoverCotovelo([FromBody] ECotoveloPosicao posicao, EBracoLado lado)
        {
            var state = _roboService.MoverCotovelo(posicao, lado);
            return Json(new
            {
                cabeca = new
                {
                    inclinacao = state.Cabeca.Inclinacao.ToString(),
                    rotacao = state.Cabeca.Rotacao.ToString()
                },
                bracoDireito = new
                {
                    cotovelo = state.BracoDireito.Cotovelo.Posicao.ToString(),
                    pulso = state.BracoDireito.Pulso.Rotacao.ToString()
                },
                bracoEsquerdo = new
                {
                    cotovelo = state.BracoEsquerdo.Cotovelo.Posicao.ToString(),
                    pulso = state.BracoEsquerdo.Pulso.Rotacao.ToString()
                }
            });
        }
        [HttpPost("/v1/RotacionarPulso")]
        public IActionResult RotacionarPulso([FromBody] EPulsoRotacao rotacao, EBracoLado lado)
        {
            var state = _roboService.RotacionarPulso(rotacao, lado);
            return Json(new
            {
                cabeca = new
                {
                    inclinacao = state.Cabeca.Inclinacao.ToString(),
                    rotacao = state.Cabeca.Rotacao.ToString()
                },
                bracoDireito = new
                {
                    cotovelo = state.BracoDireito.Cotovelo.Posicao.ToString(),
                    pulso = state.BracoDireito.Pulso.Rotacao.ToString()
                },
                bracoEsquerdo = new
                {
                    cotovelo = state.BracoEsquerdo.Cotovelo.Posicao.ToString(),
                    pulso = state.BracoEsquerdo.Pulso.Rotacao.ToString()
                }
            });
        }
    }
}
