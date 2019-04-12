using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsRepository _pr;
        public KeepsController(KeepsRepository pr)
        {
            _pr = pr;
        }

        // GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> Get()
        {
            IEnumerable<Keep> results = _pr.GetAll();
            if (results == null)
            {
                return BadRequest();
            }
            return Ok(results);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Keep> Get(int id)
        {
            Keep found = _pr.GetById(id);
            if (found == null)
            {
                return BadRequest();
            }
            return Ok(found);
        }

        // CREATE
        [HttpPost]
        public ActionResult<Keep> Create([FromBody] Keep keep)
        {
            Keep newKeep = _pr.CreateKeep(keep);
            if (newKeep == null)
            {
                return BadRequest();
            }
            return Ok(newKeep);
        }

        // EDIT
        [HttpPut("{id}")]
        public ActionResult<Keep> Edit(int id, [FromBody] Keep editedKeep)
        {
            Keep updatedKeep = _pr.EditKeep(id, editedKeep);
            if (updatedKeep == null)
            {
                return BadRequest();
            }
            return Ok(updatedKeep);
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            bool successful = _pr.Delete(id);
            if (successful)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}