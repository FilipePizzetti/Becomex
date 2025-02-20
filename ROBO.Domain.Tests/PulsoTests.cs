using ROBO.Domain.Entities;

namespace ROBO.Domain.Tests
{
    [TestClass]
    public class PulsoTests
    {
        [TestMethod]
        public void PulsoSoPodeMovimentarSeOCotoveloEstiverFortementeContraido()
        {
            var cotovelo = new Cotovelo();
            cotovelo.Mover(Enums.ECotoveloPosicao.LevementeContraido);
            cotovelo.Mover(Enums.ECotoveloPosicao.Contraido);
            cotovelo.Mover(Enums.ECotoveloPosicao.FortementeContraido);
            var pulso = new Pulso();
            pulso.Rotacionar(Enums.EPulsoRotacao.RotacaoMenos45, cotovelo.Posicao);
            Assert.AreEqual(Enums.EPulsoRotacao.RotacaoMenos45, pulso.Rotacao);
        }
    }
}
