using Microsoft.AspNetCore.Mvc;
using ROBO.Domain.Enums;
using ROBO.Domain.Interface;
using ROBO.Domain.Utils;

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
        public IActionResult GetRoboresposta()
        {
            try
            {
                var resposta = _roboService.LigarRobo();
                return Json(new
                {
                    cabeca = new
                    {
                        inclinacao = resposta.Cabeca.Inclinacao.GetDescription(),
                        rotacao = resposta.Cabeca.Rotacao.GetDescription()
                    },
                    bracoDireito = new
                    {
                        cotovelo = resposta.BracoDireito.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoDireito.Cotovelo.Pulso.Rotacao.GetDescription()
                    },
                    bracoEsquerdo = new
                    {
                        cotovelo = resposta.BracoEsquerdo.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoEsquerdo.Cotovelo.Pulso.Rotacao.GetDescription()
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet("/v1/ObterEstadoAtual")]
        public IActionResult ObterEstadoAtual()
        {
            try
            {
                var resposta = _roboService.ObterEstadoAtual();
                return Json(new
                {
                    cabeca = new
                    {
                        inclinacao = resposta.Cabeca.Inclinacao.GetDescription(),
                        rotacao = resposta.Cabeca.Rotacao.GetDescription()
                    },
                    bracoDireito = new
                    {
                        cotovelo = resposta.BracoDireito.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoDireito.Cotovelo.Pulso.Rotacao.GetDescription()
                    },
                    bracoEsquerdo = new
                    {
                        cotovelo = resposta.BracoEsquerdo.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoEsquerdo.Cotovelo.Pulso.Rotacao.GetDescription()
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpPost("/v1/RotacionarCabeca")]
        public IActionResult RotacionarCabeca([FromBody] ECabecaRotacao rotacao)
        {
            try
            {
                var resposta = _roboService.RotacionarCabeca(rotacao);
                return Json(new
                {
                    cabeca = new
                    {
                        rotacao = resposta.Cabeca.Rotacao.GetDescription()
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpPost("/v1/InclinarCabeca")]
        public IActionResult InclinarCabeca([FromBody] ECabecaInclinacao inclinacao)
        {
            try
            {
                var resposta = _roboService.InclinarCabeca(inclinacao);
                return Json(new
                {
                    cabeca = new
                    {
                        inclinacao = resposta.Cabeca.Inclinacao.GetDescription()
                    }
                });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpPost("/v1/MoverCotovelo")]
        public IActionResult MoverCotovelo([FromBody] ECotoveloPosicao posicao, EBracoLado lado)
        {
            try
            {
                var resposta = _roboService.MoverCotovelo(posicao, lado);
                return Json(new
                {
                    cabeca = new
                    {
                        inclinacao = resposta.Cabeca.Inclinacao.GetDescription(),
                        rotacao = resposta.Cabeca.Rotacao.GetDescription()
                    },
                    bracoDireito = new
                    {
                        cotovelo = resposta.BracoDireito.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoDireito.Cotovelo.Pulso.Rotacao.GetDescription()
                    },
                    bracoEsquerdo = new
                    {
                        cotovelo = resposta.BracoEsquerdo.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoEsquerdo.Cotovelo.Pulso.Rotacao.GetDescription()
                    }
                });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }
        [HttpPost("/v1/RotacionarPulso")]
        public IActionResult RotacionarPulso([FromBody] EPulsoRotacao rotacao, EBracoLado lado)
        {
            try
            {
                var resposta = _roboService.RotacionarPulso(rotacao, lado);
                return Json(new
                {
                    cabeca = new
                    {
                        inclinacao = resposta.Cabeca.Inclinacao.GetDescription(),
                        rotacao = resposta.Cabeca.Rotacao.GetDescription()
                    },
                    bracoDireito = new
                    {
                        cotovelo = resposta.BracoDireito.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoDireito.Cotovelo.Pulso.Rotacao.GetDescription()
                    },
                    bracoEsquerdo = new
                    {
                        cotovelo = resposta.BracoEsquerdo.Cotovelo.Posicao.GetDescription(),
                        pulso = resposta.BracoEsquerdo.Cotovelo.Pulso.Rotacao.GetDescription()
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }
    }
}
