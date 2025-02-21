using ROBO.Domain.Enums;
using ROBO.Domain.Utils;

namespace ROBO.Domain.Entities
{
    public class Cotovelo
    {
        public ECotoveloPosicao Posicao { get; private set; }
        public Pulso Pulso { get; private set; }
        public Cotovelo()
        {
            Posicao = ECotoveloPosicao.EmRepouso;
            Pulso = new Pulso();
        }
        public void Mover(ECotoveloPosicao novaPosicao)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Posicao, novaPosicao))
            {
                var estadosValidos = ObterEstadosValidos.ObterEstadosDeProgressaoValidos(Posicao);
                string estadosPermitidos = string.Join(", ", estadosValidos.Select(e => e.GetDescription()));
                throw new InvalidOperationException("Não é permitido alterar de " + Posicao.GetDescription() + " para " + novaPosicao.GetDescription() + ". Voce pode alterar para " + estadosPermitidos + ".");
            }

            Posicao = novaPosicao;
        }
    }
}
