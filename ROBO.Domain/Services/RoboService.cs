using ROBO.Domain.Entities;
using ROBO.Domain.Enums;
using ROBO.Domain.Interface;
using ROBO.Domain.Utils;

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
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(_robo.Cabeca.Rotacao, rotacao))
            {
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            if (_robo.Cabeca.Inclinacao == ECabecaInclinacao.ParaBaixo)
            {
                throw new InvalidOperationException("Cabeca nao pode ser rotacionada estando no estado Para Baixo");
            }
            else
                _robo.Cabeca.Rotacao = rotacao;
            return _robo;
        }

        public Robo InclinarCabeca(ECabecaInclinacao inclinacao)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(_robo.Cabeca.Inclinacao, inclinacao))
            {
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            _robo.Cabeca.Inclinacao = inclinacao;
            return _robo;
        }

        public Robo MoverCotovelo(ECotoveloPosicao posicao, EBracoLado lado)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(_robo.BracoEsquerdo.Cotovelo.Posicao, posicao))
            {
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            if (lado == EBracoLado.Esquerdo)
                _robo.BracoEsquerdo.Cotovelo.Posicao = posicao;
            else
                _robo.BracoDireito.Cotovelo.Posicao = posicao;

            return _robo;
        }

        public Robo RotacionarPulso(EPulsoRotacao rotacao, EBracoLado lado)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(_robo.BracoEsquerdo.Cotovelo.Pulso.Rotacao, rotacao))
            {
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }


            if (lado == EBracoLado.Esquerdo)
                if (_robo.BracoEsquerdo.Cotovelo.Posicao != ECotoveloPosicao.FortementeContraido)
                {
                    throw new InvalidOperationException("O pulso só pode ser rotacionado se o cotovelo estiver fortemente contraído.");
                }
                else
                    _robo.BracoEsquerdo.Cotovelo.Pulso.Rotacao = rotacao;
            else
                if (_robo.BracoDireito.Cotovelo.Posicao != ECotoveloPosicao.FortementeContraido)
            {
                throw new InvalidOperationException("O pulso só pode ser rotacionado se o cotovelo estiver fortemente contraído.");
            }
            else
                _robo.BracoDireito.Cotovelo.Pulso.Rotacao = rotacao;

            return _robo;
        }

        public Robo ObterEstadoAtual()
        {
            return _robo;
        }
    }
}
