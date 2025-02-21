using ROBO.Domain.Entities;
using ROBO.Domain.Enums;
using ROBO.Domain.Interface;

namespace ROBO.Domain.Services
{
    public class RoboService : IRoboService
    {
        private Robo _robo;
        public RoboService()
        {
            _robo = new Robo();
        }
        public Robo LigarRobo()
        {
            return _robo;
        }
        public Robo ObterEstadoAtual()
        {
            return _robo;
        }
        #region Cabeca
        public Robo InclinarCabeca(ECabecaInclinacao inclinacao)
        {
            _robo.Cabeca.Inclinar(inclinacao);
            return _robo;
        }

        public Robo RotacionarCabeca(ECabecaRotacao rotacao)
        {
            _robo.Cabeca.Rotacionar(rotacao);
            return _robo;
        }
        # endregion

        #region Braco
        public Robo MoverCotovelo(ECotoveloPosicao posicao, EBracoLado lado)
        {
            if (lado == EBracoLado.Direito)
            {
                _robo.BracoDireito.Cotovelo.Mover(posicao);
            }
            else
            {
                _robo.BracoEsquerdo.Cotovelo.Mover(posicao);
            }
            return _robo;

        }

        public Robo RotacionarPulso(EPulsoRotacao rotacao, EBracoLado lado)
        {
            if (lado == EBracoLado.Direito)
            {
                _robo.BracoDireito.Cotovelo.Pulso.Rotacionar(rotacao, _robo.BracoDireito.Cotovelo.Posicao);
            }
            else
            {
                _robo.BracoEsquerdo.Cotovelo.Pulso.Rotacionar(rotacao, _robo.BracoDireito.Cotovelo.Posicao);
            }
            return _robo;
        }
        # endregion
    }
}
