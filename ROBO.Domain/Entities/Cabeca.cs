using ROBO.Domain.Enums;
using ROBO.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace ROBO.Domain.Entities
{
    public class Cabeca
    {
        [Range(1, 3, ErrorMessage = "O valor deve estar entre 1 e 3.")]
        public ECabecaInclinacao Inclinacao { get; private set; }
        [Range(1, 5, ErrorMessage = "O valor deve estar entre 1 e 5.")]
        public ECabecaRotacao Rotacao { get; private set; }
        public Cabeca()
        {
            Inclinacao = ECabecaInclinacao.EmRepouso;
            Rotacao = ECabecaRotacao.EmRepouso;
        }
        public void Rotacionar(ECabecaRotacao novaRotacao)
        {
            if (Inclinacao == ECabecaInclinacao.ParaBaixo)
            {
                throw new InvalidOperationException("Para rotacionar a cabeça seu estado de inclinação não pode ser: Para Baixo");
            }
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Rotacao, novaRotacao))
            {
                var estadosValidos = ObterEstadosValidos.ObterEstadosDeProgressaoValidos(Rotacao);
                string estadosPermitidos = string.Join(", ", estadosValidos.Select(e => e.GetDescription()));
                throw new InvalidOperationException("Não é permitido alterar de " + Rotacao.GetDescription() + " para " + novaRotacao.GetDescription() + ". Voce pode alterar para " + estadosPermitidos + ".");
            }

            Rotacao = novaRotacao;
        }

        public void Inclinar(ECabecaInclinacao novaInclinacao)
        {
            if (!ValidadorProgressaoDeEstados.ValidaProgressaoDeEstados(Inclinacao, novaInclinacao))
            {
                var estadosValidos = ObterEstadosValidos.ObterEstadosDeProgressaoValidos(Inclinacao);
                string estadosPermitidos = string.Join(", ", estadosValidos.Select(e => e.GetDescription()));
                throw new InvalidOperationException("Não é permitido alterar de " + Inclinacao.GetDescription() + " para " + novaInclinacao.GetDescription() + ". Voce pode alterar para " + estadosPermitidos + ".");
            }

            Inclinacao = novaInclinacao;
        }
    }
}
