using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        private readonly DonationDbContext _context;

        public DCandidateController(DonationDbContext context)
        {
            _context = context;
        }

        // GET: api/DCandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDCandidate()
        {
            return await _context.DCandidate.ToListAsync();
        }

        // GET: api/DCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
            var dCandidate = await _context.DCandidate.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DCandidate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DCandidate dCandidate)
        {
            if (id != dCandidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(dCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DCandidate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dCandidate)
        {
            _context.DCandidate.Add(dCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.Id }, dCandidate);
        }

        // DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DCandidate>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.DCandidate.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.DCandidate.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.DCandidate.Any(e => e.Id == id);
        }
    }
}
