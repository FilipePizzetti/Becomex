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

            if (posicaoCotovelo != ECotoveloPosicao.FortementeContraido)
            {
                throw new InvalidOperationException("O pulso só pode ser rotacionado se o cotovelo estiver fortemente contraído.");
            }

            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Rotacao, novaRotacao))
            {
                var estadosValidos = ObterEstadosValidos.ObterEstadosDeProgressaoValidos(Rotacao);
                string estadosPermitidos = string.Join(", ", estadosValidos.Select(e => e.GetDescription()));
                throw new InvalidOperationException("Não é permitido alterar de " + Rotacao.GetDescription() + " para " + novaRotacao.GetDescription() + ". Voce pode alterar para " + estadosPermitidos + ".");
            }

            Rotacao = novaRotacao;
        }
    }
}
