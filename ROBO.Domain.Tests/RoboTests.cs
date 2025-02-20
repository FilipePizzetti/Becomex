using ROBO.Domain.Entities;
using ROBO.Domain.Enums;

namespace ROBO.Domain.Tests
{
    [TestClass]
    public class RoboTests
    {
        [TestMethod]
        public void RoboDeveIniciarComTodosEstadosEmModoRepouso()
        {
            var robo = new Robo();
            Assert.AreEqual(ECabecaInclinacao.EmRepouso, robo.Cabeca.Inclinacao);
            Assert.AreEqual(ECabecaRotacao.Repouso, robo.Cabeca.Rotacao);
            Assert.AreEqual(ECotoveloPosicao.EmRepouso, robo.BracoEsquerdo.Cotovelo.Posicao);
            Assert.AreEqual(EPulsoRotacao.Repouso, robo.BracoEsquerdo.Cotovelo.Pulso.Rotacao);
            Assert.AreEqual(ECotoveloPosicao.EmRepouso, robo.BracoDireito.Cotovelo.Posicao);
            Assert.AreEqual(EPulsoRotacao.Repouso, robo.BracoDireito.Cotovelo.Pulso.Rotacao);
        }
    }
}
