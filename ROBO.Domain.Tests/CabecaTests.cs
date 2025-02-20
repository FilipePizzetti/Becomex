using ROBO.Domain.Entities;
using ROBO.Domain.Enums;

namespace ROBO.Domain.Tests
{
    [TestClass]
    public class CabecaTests
    {
        [TestMethod]
        public void CabecaNaoPodeRotacionarSeEstiverNoEstadoParaBaixo()
        {
            var cabeca = new Cabeca();
            cabeca.Inclinar(ECabecaInclinacao.ParaBaixo);
            Assert.ThrowsException<InvalidOperationException>(() => cabeca.Rotacionar(ECabecaRotacao.Rotacao90));
        }
    }
}