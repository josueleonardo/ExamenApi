using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDApiTarea.Models;
using Newtonsoft.Json;
using System.IO;

namespace CRUDApiTarea.Controllers
{
    public class ProductsController : ApiController
    {

        [Route("api/products")]
        [HttpPost]
        public IHttpActionResult Create(Product product)
        {
            if (product == null)
            {
                return BadRequest("Error en la solicitud"); // HTTP 400
            }
            try
            {
                Add(product);
                return Ok(product); // HTTP 200
            }
            catch (Exception e)
            {
                return BadRequest("Error interno del servidor");// HTTP 500
            }
        }

        public IHttpActionResult Add(Product product)
        {

            try
            {
                if (product != null)
                {
                    product.id = DB.Products.Count;
                    DB.addProduct(product);
                    return Ok("Procedimiento exitoso"); // HTTP 201
                }
                else
                {
                    return BadRequest("Error en la solicitud");// HTTP 400
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error interno del servidor");// HTTP 500
            }

        }


        [Route("api/products/{id}")]
        [HttpGet]
        public IHttpActionResult Read(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Error en la solicitud"); // HTTP 400
                }
                Product product = DB.Products.Find(p => p.id == id);

                if (product == null)
                {
                    return BadRequest("Registro no encontrado"); // HTTP 404
                }

                return Ok(product); // HTTP 200
            }
            catch (Exception e)
            {
                return BadRequest("Error interno del servidor");// HTTP 500
            }

        }

        [Route("api/products/")]
        [HttpGet]
        public IHttpActionResult Read()
        {
            try
            {

                if (DB.Products == null)
                {
                    return BadRequest("Registro no encontrado"); // HTTP 404
                }

                return Ok(DB.Products); // HTTP 200
            }
            catch (Exception e)
            {
                return BadRequest("Error interno del servidor");// HTTP 500
            }

        }



        [Route("api/products/{id}")]
        [HttpPut]

        public IHttpActionResult Update(Product product, int id)
        {
            try
            {
                int index = DB.Products.FindIndex(p => p.id == id);
                if (index == -1)
                {
                    return BadRequest("Error en la solicitud"); // HTTP 400
                }
                DB.Products.RemoveAt(index);
                DB.Products.Add(product);
                return Ok(product); // HTTP 200*/
            }
            catch (Exception e)
            {
                return BadRequest("Error interno del servidor");// HTTP 500
            }
        }



        [Route("api/products/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            try
            {
                int index = DB.Products.FindIndex(p => p.id == id);
                if (index == -1)
                {
                    return BadRequest("Registro no encontrado");// HTTP 404
                }
                return Ok("Procedimiento exitoso"); //HTTP 200
            }
            catch (Exception e)
            {
                return BadRequest("Error interno del servidor");// HTTP 500
            }
        }



    }
}
