namespace ROBO.Domain.Utils
{
    public static class ValidadorProgressaoDeEstados
    {
        public static bool ValidaProgressaoDeEstados<T>(T novoEstado, T antigoEstado) where T : Enum
        {
            int diferenca = Convert.ToInt32(novoEstado) - Convert.ToInt32(antigoEstado);
            return Math.Abs(diferenca) == 1;
        }
    }
}
