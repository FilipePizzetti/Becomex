using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Robo
    {
        public Cabeca Cabeca { get; set; }
        public Braco BracoDireito { get; set; }
        public Braco BracoEsquerdo { get; set; }
        public Robo()
        {
            Cabeca = new Cabeca();
            BracoDireito = new Braco(EBracoLado.Direito);
            BracoEsquerdo = new Braco(EBracoLado.Esquerdo);
        }
    }
}
