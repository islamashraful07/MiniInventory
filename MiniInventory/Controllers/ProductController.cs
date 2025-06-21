using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.DTOs;
using MiniInventory.Models.Entities;
using MiniInventory.Models.ViewModels;
using MiniInventory.Services.Interfaces;
using NuGet.Protocol.Core.Types;
using System.Threading.Tasks;

namespace MiniInventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<ActionResult> Index()
        {
            var searchFilter = new SearchFilterDto
            {
                Name = "",
                Category = 0,
                
            };
            var products =await _productServices.GetAllProductsAsync(searchFilter);
            return View(products);
        }


        public async Task<ActionResult> SearchedProduct(SearchFilterDto searchFilter)
        {
            var products = await _productServices.GetAllProductsAsync(searchFilter);
            return View("Index",products);
        }



        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult> Createoredit(ProductModel product)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Create");

                }
                if (product.Id == 0)
                {
                   
                    await _productServices.AddProductAsync(product);
                   
                }else
                {
                   
                    await _productServices.UpdateProductAsync(product);
                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var productData=await _productServices.GetProductByIdAsync(id);
            return View("Create",productData);
        }

        
        

    
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _productServices.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
