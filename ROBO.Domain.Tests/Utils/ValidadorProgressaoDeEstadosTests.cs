using ROBO.Domain.Enums;
using ROBO.Domain.Utils;

namespace ROBO.Domain.Tests.Utils
{
    [TestClass]
    public class ValidadorProgressaoDeEstadosTests
    {
        [TestMethod]
        public void NaoPodeSaltarMaisDeUmEstado()
        {
            var progressao = ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(ECabecaRotacao.EmRepouso, ECabecaRotacao.RotacaoMenos90);
            Assert.IsFalse(progressao);
        }
    }
}
