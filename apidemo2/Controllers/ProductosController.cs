using apidemo2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apidemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly AplicationDbcontext _dbcontext;

        public ProductosController(AplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        // GET: api/<ProductosController>
        [HttpGet]
        public ActionResult<List<productos>>  Get()
        {
            try
            {
                var listaProductos = _dbcontext.Producto.ToList();
                return Ok(listaProductos);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public ActionResult<productos> Get(int id)
        {
            try
            {
                var listaProductos = _dbcontext.Producto.Find(id);
                if (listaProductos == null)
                { 
                    return NotFound(); 
                }
                return Ok(listaProductos);  

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public ActionResult Post([FromBody] productos producto)
        {
            try
            {
                _dbcontext.Add(producto);
                _dbcontext.SaveChanges();
                return Ok();

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] productos producto)
        {

            try
            {
                if( id != producto.Id)
                { 
                    return BadRequest();
                }
                _dbcontext.Entry(producto).State = EntityState.Modified;
                _dbcontext.Update(producto);
                _dbcontext.SaveChanges();
                return Ok();


            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                var producto = _dbcontext.Producto.Find(id);

                if (producto == null)
                {
                    return NotFound();
                }
                _dbcontext.Remove(producto);
                _dbcontext.SaveChanges();

                return Ok();

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
