using System.ComponentModel;

namespace ROBO.Domain.Enums
{
    public enum ECotoveloPosicao
    {
        [Description("Em Repouso")]
        EmRepouso = 1,
        [Description("Levemente Contraído")]
        LevementeContraido = 2,
        [Description("Contraído")]
        Contraido = 3,
        [Description("Fortemente Contraído")]
        FortementeContraido = 4
    }
}
