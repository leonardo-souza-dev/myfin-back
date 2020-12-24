namespace MyFin.Infrastructure.MongoDB
{
    public class MyFinDatabaseSettings : IMyFinDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string CarrinhoCollectionName { get; set; }
        public string ProdutoCollectionName { get; set; }
        public string TicketAutenticacaoCollectionName { get; set; }
        public string LoggerCollectionName { get; set; }
    }

    public interface IMyFinDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

        string CarrinhoCollectionName { get; set; }
        string ProdutoCollectionName { get; set; }
        string TicketAutenticacaoCollectionName { get; set; }
        string LoggerCollectionName { get; set; }
    }
}
