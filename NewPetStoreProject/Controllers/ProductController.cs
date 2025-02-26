using Microsoft.AspNetCore.Mvc;
using PetStore.Data;

namespace NewPetStoreProject.Controllers
{
    [ApiController]
    [Route("{Controller}")]

    public class ProductController : ControllerBase
    {
        private readonly IProductLogic _productLogic;

        public ProductController(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        [HttpGet("{action}/{id}")]
        public IActionResult GetProduct(int id)
        {
            return new JsonResult(_productLogic.GetProductById(id));
        }

        [HttpGet("{action}/{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            return new JsonResult(_productLogic.GetOrder(orderId));
        }

        [HttpGet("{action}/{orderId}")]
        public IActionResult GetAllProducts()
        {
            return new JsonResult(_productLogic.GetAllProducts());
        }
        //[HttpPost("Product")]
        //public IActionResult AddProduct([FromBody]Product product)
        //{
        //}
    } 
}

