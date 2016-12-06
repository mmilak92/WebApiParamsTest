using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiParamsTest.Models;

namespace WebApiParamsTest.Controllers
{
    public class ProductsController : ApiController
    {
        private static int _counter = 2;

        private static List<ProductViewModel> _products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id=1,
                Name = "Marmelada od šipka 0,75L",
                Description = "Šipak je plod divlje ruže koji dozrijeva u jesen, a preporučuje se za punjenje palačinki i za mazanje na kruh.",
                Price = 8.5
            },
            new ProductViewModel()
            {
                Id=2,
                Name = "Pivo Ožujsko 2L",
                Description = "Žuja je zakon",
                Price = 20
            },
        };

        public IHttpActionResult Get()
        {
            return Ok(_products.OrderBy(p=>p.Id));
        }

        public IHttpActionResult Get(int id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }


        [HttpPut]
        public IHttpActionResult Put(ProductViewModel product)
        {
            if (product.Id == 0)
            {
                product.Id = ++_counter;
                _products.Add(product);
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Post(ProductViewModel product)
        {
            var updatedProduct = _products.SingleOrDefault(p => p.Id == product.Id);
            if (updatedProduct == null)
                return NotFound();

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;

            _products = _products.Where(p => p.Id != product.Id).ToList();
            _products.Add(updatedProduct);

            return Ok(updatedProduct);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _products = _products.Where(p => p.Id != id).ToList();
            return Ok();
        }
    }
}
