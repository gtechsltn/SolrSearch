using SolrNet;

namespace SolrSearch;

public class ProductSolrRepository : IProductSolrRepository
{
    private readonly ISolrOperations<Product> _solr;

    public ProductSolrRepository(ISolrOperations<Product> solr)
    {
        _solr = solr;
    }

    public async Task Add(Product product)
    {
        await _solr.AddAsync(product);
        await _solr.CommitAsync();
    }

    public async Task Delete(Product product)
    {
        await _solr.DeleteAsync(product);
        await _solr.CommitAsync();
    }

    public Product GetById(string Id)
    {
        Product solrResult = _solr.Query(new SolrQueryByField("id", Id)).FirstOrDefault();

        if (solrResult != null)
            return solrResult;

        return null;
    }

    public IEnumerable<Product> Search(string searchNameString)
    {
        if (!string.IsNullOrEmpty(searchNameString))
            return _solr.Query(new SolrQueryByField("name_str", $"name_str:*{searchNameString.Replace(' ', '*')}*")).ToList();
        else
            return _solr.Query(SolrQuery.All).ToList();
    }

}
