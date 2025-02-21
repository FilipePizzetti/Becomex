using ROBO.Domain.Enums;
using ROBO.Domain.Utils;

namespace ROBO.Domain.Entities
{
    public class Cabeca
    {
        public ECabecaInclinacao Inclinacao { get; private set; }
        public ECabecaRotacao Rotacao { get; private set; }
        public Cabeca()
        {
            Inclinacao = ECabecaInclinacao.EmRepouso;
            Rotacao = ECabecaRotacao.EmRepouso;
        }
        public void Rotacionar(ECabecaRotacao novaRotacao)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Rotacao, novaRotacao))
            {
                //Notifications.Add("Nao e possivel alterar mais de uma progressao por estado."); verificar para utilizar o fluent validator depois
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            if (Inclinacao == ECabecaInclinacao.ParaBaixo)
            {
                throw new InvalidOperationException("Cabeca nao pode ser rotacionada estando no estado Para Baixo");
            }

            Rotacao = novaRotacao;
        }

        public void Inclinar(ECabecaInclinacao novaInclinacao)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Inclinacao, novaInclinacao))
            {
                throw new InvalidOperationException("Nao e possivel alterar mais de uma progressao por estado.");
            }

            Inclinacao = novaInclinacao;
        }
    }
}
