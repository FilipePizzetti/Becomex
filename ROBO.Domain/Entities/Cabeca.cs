using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Cabeca
    {
        public ECabecaInclinacao Inclinacao { get; set; }
        public ECabecaRotacao Rotacao { get; set; }
        public Cabeca()
        {
            Inclinacao = ECabecaInclinacao.EmRepouso;
            Rotacao = ECabecaRotacao.Repouso;
        }
    }
}
