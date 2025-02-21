using System.ComponentModel;

namespace ROBO.Domain.Enums
{
    public enum ECabecaRotacao
    {
        [Description("Rotação -90°")]
        RotacaoMenos90 = 1,
        [Description("Rotação -45°")]
        RotacaoMenos45 = 2,
        [Description("Em Repouso")]
        EmRepouso = 3,
        [Description("Rotação 45°")]
        Rotacao45 = 4,
        [Description("Rotação 90°")]
        Rotacao90 = 5
    }
}
