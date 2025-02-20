using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Cotovelo
    {
        public ECotoveloPosicao Posicao { get; set; }
        public Cotovelo()
        {
            Posicao = ECotoveloPosicao.EmRepouso;
        }
    }
}
