using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVW.Data;

namespace MVW.WebApp.API
{
    public class WordEntitiesController : ApiController
    {
        private MVWDataBase db = new MVWDataBase();

        // GET: api/WordEntities
        public IQueryable<WordEntity> GetWord()
        {
            return db.Word.Where(o => o.Closed == false).OrderByDescending(o => o.ModifyUtc);
        }

        public IQueryable<WordEntity> GetClosedWordByLastDays(int days)
        {
            DateTime closeDate = DateTime.UtcNow.AddDays(days * -1);
            return db.Word.Where(o => o.Closed && o.CloseUtc > closeDate).OrderByDescending(o => o.ModifyUtc);
        }

        // GET: api/WordEntities/5
        [ResponseType(typeof(WordEntity))]
        public IHttpActionResult GetWordEntity(int id)
        {
            WordEntity wordEntity = db.Word.Find(id);
            if (wordEntity == null)
            {
                return NotFound();
            }

            return Ok(wordEntity);
        }

        // PUT: api/WordEntities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWordEntity(int id, WordEntity wordEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wordEntity.Id)
            {
                return BadRequest();
            }
            if (wordEntity.Closed)
                wordEntity.CloseUtc = DateTime.UtcNow;
            else
                wordEntity.ModifyUtc = DateTime.UtcNow;
            db.Entry(wordEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WordEntityExists(id))
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

        // POST: api/WordEntities
        [ResponseType(typeof(WordEntity))]
        public IHttpActionResult PostWordEntity(WordEntity wordEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            wordEntity.CreateUtc = DateTime.UtcNow;
            wordEntity.ModifyUtc = DateTime.UtcNow;
            wordEntity.CreateUser = "Kim";
            db.Word.Add(wordEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wordEntity.Id }, wordEntity);
        }

        // DELETE: api/WordEntities/5
        [ResponseType(typeof(WordEntity))]
        public IHttpActionResult DeleteWordEntity(int id)
        {
            WordEntity wordEntity = db.Word.Find(id);
            if (wordEntity == null)
            {
                return NotFound();
            }

            db.Word.Remove(wordEntity);
            db.SaveChanges();

            return Ok(wordEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WordEntityExists(int id)
        {
            return db.Word.Count(e => e.Id == id) > 0;
        }
    }
}