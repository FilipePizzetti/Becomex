using ROBO.Domain.Enums;
using ROBO.Domain.Utils;

namespace ROBO.Domain.Tests
{
    [TestClass]
    public class ValidadorProgressaoDeEstadosTests
    {
        [TestMethod]
        public void NaoPodeSaltarMaisDeUmEstado()
        {
            var progressao = ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(ECabecaRotacao.Repouso, ECabecaRotacao.RotacaoMenos90);
            Assert.IsFalse(progressao);
        }
    }
}
