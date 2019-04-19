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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsRepository _vkr;
        public VaultKeepsController(VaultKeepsRepository vkr)
        {
            _vkr = vkr;
        }

        // GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<VaultKeep>> Get()
        {
            IEnumerable<VaultKeep> results = _vkr.GetAll();
            if (results == null)
            {
                return BadRequest();
            }
            return Ok(results);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<VaultKeep> Get(int id)
        {
            VaultKeep found = _vkr.GetById(id);
            if (found == null)
            {
                return BadRequest();
            }
            return Ok(found);
        }

        // CREATE
        [HttpPost]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeep)
        {
            VaultKeep newVaultKeep = _vkr.CreateVaultKeep(vaultKeep);
            if (newVaultKeep == null)
            {
                return BadRequest("Failed to create vault keep");
            }
            return Ok(newVaultKeep);
        }

        // EDIT
        [HttpPut("{id}")]
        public ActionResult<VaultKeep> Edit(int id, [FromBody] VaultKeep editedVaultKeep)
        {
            VaultKeep updatedVaultKeep = _vkr.EditVaultKeep(id, editedVaultKeep);
            if (updatedVaultKeep == null)
            {
                return BadRequest();
            }
            return Ok(updatedVaultKeep);
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            bool successful = _vkr.Delete(id);
            if (successful)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}