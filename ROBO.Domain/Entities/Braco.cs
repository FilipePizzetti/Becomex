using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Braco
    {
        public EBracoLado LadoBraco { get; private set; }
        public Cotovelo Cotovelo { get; private set; }
        public Braco(EBracoLado ladoBraco)
        {
            LadoBraco = ladoBraco;
            Cotovelo = new Cotovelo();
        }
    }
}
