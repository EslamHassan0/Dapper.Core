using Dapper.Core.Interfaces;
using Dapper.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetAllProductAsync")]
        public async Task<IActionResult> GetAllProductAsync()
            => Ok(await _unitOfWork.Product.GetAllAsync());
        [HttpGet("GetProductByIdAsync/{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
            => Ok(await _unitOfWork.Product.GetByIdAsync(id));
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
           => Ok(await _unitOfWork.Product.AddAsync(product));

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
           => Ok(await _unitOfWork.Product.UpdateAsync(product));

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
           => Ok(await _unitOfWork.Product.DeleteAsync(id));
    }
}
