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
        //private MVWDataBase db = new MVWDataBase();

        private MVWJsonDataBase jsonDb;
        public WordEntitiesController()
        {
            jsonDb = MvcApplication.jsonDb;

        }

        // GET: api/WordEntities
        public IEnumerable<WordEntity> GetWord()
        {
            return jsonDb.Word.Where(o => o.Closed == false).OrderByDescending(o => o.ModifyUtc);
            //return db.Word.Where(o => o.Closed == false).OrderByDescending(o => o.ModifyUtc);
        }

        public IEnumerable<WordEntity> GetClosedWordByLastDays(int days)
        {
            DateTime closeDate = DateTime.UtcNow.AddDays(days * -1);
            return jsonDb.Word.Where(o => o.Closed && o.CloseUtc > closeDate).OrderByDescending(o => o.ModifyUtc);
            // return db.Word.Where(o => o.Closed && o.CloseUtc > closeDate).OrderByDescending(o => o.ModifyUtc);
        }

        // GET: api/WordEntities/5
        [ResponseType(typeof(WordEntity))]
        public IHttpActionResult GetWordEntity(int id)
        {
            WordEntity wordEntity = jsonDb.Word.Single(o => o.Id == id);
            // WordEntity wordEntity = db.Word.Find(id);
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
            //db.Entry(wordEntity).State = EntityState.Modified;
            var oldEntity = jsonDb.Word.Single(o => o.Id == id);
            oldEntity.KnowTimes = wordEntity.KnowTimes;
            oldEntity.FromWord = wordEntity.FromWord;
            oldEntity.ToWord = wordEntity.ToWord;

            jsonDb.SaveChanges();

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
            wordEntity.Id = jsonDb.Word.Max(o => o.Id) + 1;
            jsonDb.Word.Add(wordEntity);
            jsonDb.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wordEntity.Id }, wordEntity);
        }

        // DELETE: api/WordEntities/5
        [ResponseType(typeof(WordEntity))]
        public IHttpActionResult DeleteWordEntity(int id)
        {
            WordEntity wordEntity = jsonDb.Word.Single(o => o.Id == id);
            if (wordEntity == null)
            {
                return NotFound();
            }

            jsonDb.Word.Remove(wordEntity);
            jsonDb.SaveChanges();

            return Ok(wordEntity);
        }

    }
}