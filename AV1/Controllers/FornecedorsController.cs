using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AV1.Models;

namespace AV1.Controllers
{
    public class FornecedorsController : ApiController
    {
        private FornecedorServiceContext db = new FornecedorServiceContext();

        // GET: api/Fornecedors
        public IQueryable<Fornecedor> GetFornecedors()
        {
            return db.Fornecedors;
        }

        //// GET: api/Fornecedors/5
        //[ResponseType(typeof(Fornecedor))]
        //public async Task<IHttpActionResult> GetFornecedor(int id)
        //{
        //    Fornecedor fornecedor = await db.Fornecedors.FindAsync(id);
        //    if (fornecedor == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(fornecedor);
        //}

        //// PUT: api/Fornecedors/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != fornecedor.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(fornecedor).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FornecedorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Fornecedors
        [ResponseType(typeof(Fornecedor))]
        public async Task<IHttpActionResult> PostFornecedor(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fornecedors.Add(fornecedor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fornecedor.Id }, fornecedor);
        }

        //// DELETE: api/Fornecedors/5
        //[ResponseType(typeof(Fornecedor))]
        //public async Task<IHttpActionResult> DeleteFornecedor(int id)
        //{
        //    Fornecedor fornecedor = await db.Fornecedors.FindAsync(id);
        //    if (fornecedor == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Fornecedors.Remove(fornecedor);
        //    await db.SaveChangesAsync();

        //    return Ok(fornecedor);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FornecedorExists(int id)
        {
            return db.Fornecedors.Count(e => e.Id == id) > 0;
        }
    }
}