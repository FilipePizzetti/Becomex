namespace ROBO.Domain.Utils
{
    public class ObterEstadosValidos
    {
        public static List<T> ObterEstadosDeProgressaoValidos<T>(T estadoAtual) where T : Enum
        {
            List<T> estadosValidos = new List<T>();


            var valoresEnum = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            int indiceAtual = valoresEnum.IndexOf(estadoAtual);


            if (indiceAtual > 0)
            {
                estadosValidos.Add(valoresEnum[indiceAtual - 1]);
            }

            if (indiceAtual < valoresEnum.Count - 1)
            {
                estadosValidos.Add(valoresEnum[indiceAtual + 1]);
            }

            return estadosValidos;
        }
    }
}
