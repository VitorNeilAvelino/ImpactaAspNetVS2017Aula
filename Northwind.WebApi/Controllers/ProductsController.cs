﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Northwind.Repositorios.SqlServer.EFDbFirst;

namespace Northwind.WebApi.Controllers
{
    //localhost:51001/swagger/
    [RoutePrefix("api/products")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

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

            var product = db.Products.Find(id);

            //db.Entry(products).State = EntityState.Modified;
            db.Entry(product).CurrentValues.SetValues(viewModel);

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

        /// <summary>
        /// Obtém a lista dos pedidos que contêm aquele produto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Products))]
        //[HttpGet]
        [Route("{id}/orders")]        
        public IHttpActionResult GetProductOrders(int id)
        {
            var products = db.Products.Include(p => p.Order_Details).SingleOrDefault(p=> p.ProductID == id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products.Order_Details.ToList());
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