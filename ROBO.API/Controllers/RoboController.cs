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
            if (!Enum.IsDefined(typeof(ECabecaRotacao), rotacao))
            {
                return Json(new
                {
                    error = "Valor inválido para rotação da cabeça."
                });
            }

            try
            {
                var resposta = _roboService.RotacionarCabeca(rotacao);
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
        [HttpPost("/v1/InclinarCabeca")]
        public IActionResult InclinarCabeca([FromBody] ECabecaInclinacao inclinacao)
        {
            if (!Enum.IsDefined(typeof(ECabecaInclinacao), inclinacao))
            {
                return Json(new
                {
                    error = "Valor inválido para inclinação da cabeça."
                });
            }
            try
            {
                var resposta = _roboService.InclinarCabeca(inclinacao);
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

        [HttpPost("/v1/MoverCotovelo")]
        public IActionResult MoverCotovelo([FromBody] AtualizaMoverCotoveloDTO atualizaMoverCotoveloDTO)
        {
            if (!Enum.IsDefined(typeof(ECotoveloPosicao), atualizaMoverCotoveloDTO.Posicao))
            {
                return Json(new
                {
                    error = "Valor inválido para posição do cotovelo."
                });
            }
            if (!Enum.IsDefined(typeof(EBracoLado), atualizaMoverCotoveloDTO.Lado))
            {
                return Json(new
                {
                    error = "O Valor para o braço deve ser 1. Direito ou 2. Esquerdo."
                });
            }
            try
            {
                var resposta = _roboService.MoverCotovelo(atualizaMoverCotoveloDTO.Posicao, atualizaMoverCotoveloDTO.Lado);
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
        public IActionResult RotacionarPulso([FromBody] AtualizaRotacionarPulsoDTO atualizaRotacionarPulsoDTO)
        {
            if (!Enum.IsDefined(typeof(EPulsoRotacao), atualizaRotacionarPulsoDTO.Rotacao))
            {
                return Json(new
                {
                    error = "Valor inválido para rotação do pulso."
                });
            }
            if (!Enum.IsDefined(typeof(EBracoLado), atualizaRotacionarPulsoDTO.Lado))
            {
                return Json(new
                {
                    error = "O Valor para o braço deve ser 1. Direito ou 2. Esquerdo."
                });
            }
            try
            {
                var resposta = _roboService.RotacionarPulso(atualizaRotacionarPulsoDTO.Rotacao, atualizaRotacionarPulsoDTO.Lado);
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
        public class AtualizaRotacionarPulsoDTO
        {
            public EPulsoRotacao Rotacao { get; set; }
            public EBracoLado Lado { get; set; }
        }
        public class AtualizaMoverCotoveloDTO
        {
            public ECotoveloPosicao Posicao { get; set; }
            public EBracoLado Lado { get; set; }
        }
    }
}
