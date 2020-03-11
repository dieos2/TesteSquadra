using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteSquadra.Models;
using TesteSquadra.Services;

namespace TesteSquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemasController : ControllerBase
    {
        //private readonly TesteSquadraContext _context;
        private readonly ISistemaService _service;

        public SistemasController(ISistemaService service)
        {
            //_context = context;
            _service = service;
        }

        // GET: api/Sistemas
        [HttpGet]
        public ActionResult<IEnumerable<Sistemas>> GetSistemas()
        {
            var items = _service.GetAllItems();
            return Ok(items);
           
        }

        // GET: api/Sistemas/5
        [HttpGet("{id}")]
        public ActionResult GetSistemas([FromRoute] int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);

          
        }

        // PUT: api/Sistemas/5
        [HttpPut("{id}")]
        public ActionResult PutSistemas([FromRoute] int id, [FromBody] Sistemas sistemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Edit(sistemas);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // POST: api/Sistemas
        [HttpPost]
        public ActionResult PostSistemas([FromBody] Sistemas sistemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(sistemas);
            return CreatedAtAction("Get", new { id = item.Id }, item);
           
        }

        // DELETE: api/Sistemas/5
        [HttpDelete("{id}")]
        public ActionResult DeleteSistemas([FromRoute] int id)
        {

            var existingItem = _service.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok();
        }

        //private bool SistemasExists(int id)
        //{
        //    return _context.Sistemas.Any(e => e.Id == id);
        //}
    }
}