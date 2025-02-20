using ROBO.Domain.Entities;
using ROBO.Domain.Enums;

namespace ROBO.Domain.Interface
{
    public interface IRoboService
    {
        Robo ObterEstadoAtual();
        Robo LigarRobo();
        Robo InclinarCabeca(ECabecaInclinacao inclinacao);
        Robo RotacionarCabeca(ECabecaRotacao rotacao);
        Robo MoverCotovelo(ECotoveloPosicao posicao, EBracoLado lado);
        Robo RotacionarPulso(EPulsoRotacao rotacao, EBracoLado lado);
    }
}
