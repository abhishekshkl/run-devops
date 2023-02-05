using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Data;
using Shopping.Api.Models;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return  ProductContext.Products;
        }
    }
}
