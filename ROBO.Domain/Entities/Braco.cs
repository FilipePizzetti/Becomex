using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Braco
    {
        public EBracoLado LadoBraco { get; set; }
        public Cotovelo Cotovelo { get; set; }
        public Braco(EBracoLado ladoBraco)
        {
            LadoBraco = ladoBraco;
            Cotovelo = new Cotovelo();
        }
    }
}
