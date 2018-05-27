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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MigrationStepsController : ApiController
    {
        private MigrationStepsDataContext db = new MigrationStepsDataContext();

        // GET: api/MigrationSteps
        public IQueryable<MigrationStepsViewModel> GetMigrationStepsViewModels()
        {
            return db.MigrationStepsViewModels;
        }

        // GET: api/MigrationSteps/5
        [ResponseType(typeof(MigrationStepsViewModel))]
        public IHttpActionResult GetMigrationStepsViewModel(int id)
        {
            MigrationStepsViewModel migrationStepsViewModel = db.MigrationStepsViewModels.Find(id);
            if (migrationStepsViewModel == null)
            {
                return NotFound();
            }

            return Ok(migrationStepsViewModel);
        }

        // PUT: api/MigrationSteps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMigrationStepsViewModel(int id, MigrationStepsViewModel migrationStepsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != migrationStepsViewModel.StepNumber)
            {
                return BadRequest();
            }

            db.Entry(migrationStepsViewModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MigrationStepsViewModelExists(id))
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

        // POST: api/MigrationSteps
        [ResponseType(typeof(MigrationStepsViewModel))]
        public IHttpActionResult PostMigrationStepsViewModel(MigrationStepsViewModel migrationStepsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MigrationStepsViewModels.Add(migrationStepsViewModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = migrationStepsViewModel.StepNumber }, migrationStepsViewModel);
        }

        // DELETE: api/MigrationSteps/5
        [ResponseType(typeof(MigrationStepsViewModel))]
        public IHttpActionResult DeleteMigrationStepsViewModel(int id)
        {
            MigrationStepsViewModel migrationStepsViewModel = db.MigrationStepsViewModels.Find(id);
            if (migrationStepsViewModel == null)
            {
                return NotFound();
            }

            db.MigrationStepsViewModels.Remove(migrationStepsViewModel);
            db.SaveChanges();

            return Ok(migrationStepsViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MigrationStepsViewModelExists(int id)
        {
            return db.MigrationStepsViewModels.Count(e => e.StepNumber == id) > 0;
        }
    }
}