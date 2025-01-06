namespace SolrSearch
{
    public interface IProductSolrRepository
    {
        Task Add(Product product);
        Task Delete(Product product);
        Product GetById(string Id);
        IEnumerable<Product> Search(string searchNameString);
    }
}