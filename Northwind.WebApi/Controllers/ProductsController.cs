using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Northwind.Repositorios.SqlServer.EFDbFirst;

namespace Northwind.WebApi.Controllers
{
    [RoutePrefix("api/products")]
    //[EnableCors("*", "*", "*")]
    public class ProductsController : ApiController
    {
        private NorthwindModel db = new NorthwindModel();

        public ProductsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Products
        public IQueryable<Products> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult GetProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducts(int id, Products viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewModel.ProductID)
            {
                return BadRequest();
            }

            //db.Entry(viewModel).State = EntityState.Modified;

            var produto = db.Products.Find(id);

            db.Entry(produto).CurrentValues.SetValues(viewModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Products))]
        public IHttpActionResult PostProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products.ProductID }, products);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Products))]
        public IHttpActionResult DeleteProducts(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            db.SaveChanges();

            return Ok(products);
        }

        [Route("{id}/orders")]
        public IHttpActionResult GetProductOrders(int id)
        {
            var product = db.Products
                .Include(p => p.Order_Details)
                .Include(p => p.Order_Details.Select(od => od.Orders))
                .SingleOrDefault(p => p.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.Order_Details.Select(od => od.Orders).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}