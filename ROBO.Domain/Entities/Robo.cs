using ROBO.Domain.Enums;

namespace ROBO.Domain.Entities
{
    public class Robo
    {
        public Cabeca Cabeca { get; private set; }
        public Braco BracoDireito { get; private set; }
        public Braco BracoEsquerdo { get; private set; }
        public Robo()
        {
            Cabeca = new Cabeca();
            BracoDireito = new Braco(EBracoLado.Direito);
            BracoEsquerdo = new Braco(EBracoLado.Esquerdo);
        }
    }
}
