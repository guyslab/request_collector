namespace ResponseConsumer.Options
{
    public class CatalogDatabaseOptions
    {
        public int ProcessInParallelCount { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
