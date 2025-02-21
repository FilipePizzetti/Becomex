using ROBO.Domain.Enums;
using ROBO.Domain.Utils;

namespace ROBO.Domain.Entities
{
    public class Pulso
    {
        public EPulsoRotacao Rotacao { get; private set; }
        public Pulso()
        {
            Rotacao = EPulsoRotacao.EmRepouso;
        }

        public void Rotacionar(EPulsoRotacao novaRotacao, ECotoveloPosicao posicaoCotovelo)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Rotacao, novaRotacao))
            {
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            if (posicaoCotovelo != ECotoveloPosicao.FortementeContraido)
            {
                throw new InvalidOperationException("O pulso só pode ser rotacionado se o cotovelo estiver fortemente contraído.");
            }

            Rotacao = novaRotacao;
        }
    }
}
