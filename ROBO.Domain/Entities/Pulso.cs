using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Pulso
    {
        public EPulsoRotacao Rotacao { get; set; }
        public Pulso()
        {
            Rotacao = EPulsoRotacao.Repouso;
        }
    }
}
