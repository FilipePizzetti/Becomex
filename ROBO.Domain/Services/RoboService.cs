using ROBO.Domain.Entities;
using ROBO.Domain.Enums;
using ROBO.Domain.Interface;

namespace ROBO.Domain.Services
{
    public class RoboService : IRoboService
    {
        private readonly Robo _robo;
        public RoboService()
        {
            _robo = new Robo();
        }

        public Robo LigarRobo()
        {
            return _robo;
        }

        public Robo RotacionarCabeca(ECabecaRotacao rotacao)
        {
            _robo.Cabeca.Rotacao = rotacao;
            return _robo;
        }

        public Robo InclinarCabeca(ECabecaInclinacao inclinacao)
        {
            _robo.Cabeca.Inclinacao = inclinacao;
            return _robo;
        }

        public Robo MoverCotovelo(ECotoveloPosicao posicao, EBracoLado lado)
        {
            if (lado == EBracoLado.Esquerdo)
                _robo.BracoEsquerdo.Cotovelo.Posicao = posicao;
            else
                _robo.BracoDireito.Cotovelo.Posicao = posicao;

            return _robo;
        }

        public Robo RotacionarPulso(EPulsoRotacao rotacao, EBracoLado lado)
        {
            if (lado == EBracoLado.Esquerdo)
                _robo.BracoEsquerdo.Pulso.Rotacao = rotacao;
            else
                _robo.BracoDireito.Pulso.Rotacao = rotacao;

            return _robo;
        }
    }
}
