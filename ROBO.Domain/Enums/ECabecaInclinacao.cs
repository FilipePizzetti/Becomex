using System.ComponentModel;

namespace ROBO.Domain.Enums
{
    public enum ECabecaInclinacao
    {
        [Description("Para Cima")]
        ParaCima = 1,
        [Description("Em Repouso")]
        EmRepouso = 2,
        [Description("Para Baixo")]
        ParaBaixo = 3
    }
}
