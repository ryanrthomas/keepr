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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsRepository _tr;
        public VaultsController(VaultsRepository tr)
        {
            _tr = tr;
        }

        // GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            IEnumerable<Vault> results = _tr.GetAll();
            if (results == null)
            {
                return BadRequest();
            }
            return Ok(results);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Vault> Get(int id)
        {
            Vault found = _tr.GetById(id);
            if (found == null)
            {
                return BadRequest();
            }
            return Ok(found);
        }

        // GET PLAYERS BY TEAM ID   
        [HttpGet("{id}/players")]
        public ActionResult<IEnumerable<Keep>> GetKeeps(int id)
        {
            return Ok(_tr.GetKeeps(id));
        }

        // CREATE
        [HttpPost]
        public ActionResult<Vault> Create([FromBody] Vault vault)
        {
            Vault newVault = _tr.CreateVault(vault);
            if (newVault == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("newVault", vault);
        }

        // EDIT
        [HttpPut("{id}")]
        public ActionResult<Vault> Edit(int id, [FromBody] Vault editedVault)
        {
            Vault updatedVault = _tr.EditVault(id, editedVault);
            if (updatedVault == null)
            {
                return BadRequest();
            }
            return Ok(updatedVault);
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            bool successful = _tr.Delete(id);
            if (successful)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}