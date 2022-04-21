namespace WebApiMOngoDb.Models
{
    public class ProductDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ProductCollectionName { get; set;} = string.Empty;
    }
}
