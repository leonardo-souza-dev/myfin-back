namespace Ecommerce.Infrastructure.MongoDB
{
    internal static class LoggerMapper
    {
        internal static LogDocument Map(this string content)
        {
            return new LogDocument { Conteudo = content };
        }
    }
}
