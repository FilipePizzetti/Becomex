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
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            Posicao = novaPosicao;
        }
    }
}
