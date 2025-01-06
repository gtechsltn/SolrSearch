using Microsoft.AspNetCore.Mvc;

namespace SolrSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductSolrRepository _solrProductRepository;

        public ProductController(ILogger<ProductController> logger, IProductSolrRepository solrProductRepository)
        {
            _logger = logger;
            _solrProductRepository = solrProductRepository;
        }

        [HttpGet]
        public IActionResult Get(string searchNameString)
        {
            return Ok(_solrProductRepository.Search(searchNameString));
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            return Ok(_solrProductRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _solrProductRepository.Add(product);
            return Ok(product);
        }        
    }
}