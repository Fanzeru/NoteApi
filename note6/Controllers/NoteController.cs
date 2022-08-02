using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace note6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class notesController : ControllerBase
    {
        private static List<Note> noteList = new List<Note>
            {
                new Note {
                    id = 1,
                    title = "new note",
                    body = "bl",
                    crdate=2021,
                    update=2022
                },
                    new Note {
                    id = 2,
                    title = "second note",
                    body = "body of second note",
                    crdate=2022,
                    update=2023
                }
            };
        private readonly DataContext _context;

        public notesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Note>>> Get()

        {
            return Ok(await _context.Notes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Note>>> Get(int id)

        {
            var dbNote = await _context.Notes.FindAsync(id);
            if (dbNote == null)
                return BadRequest("note dont found.");
            return Ok(await _context.Notes.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Note>>> AddNote(Note dbNote)

        {
            _context.Notes.Add(dbNote);
            await _context.SaveChangesAsync();
            return Ok(await _context.Notes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Note>>> UpdateNote(Note request)

        {
            var dbNote = await _context.Notes.FindAsync(request.id);
            if (dbNote == null)
                return BadRequest("note dont found.");
         
           
            dbNote.title = request.title;
            dbNote.body = request.body;
            dbNote.crdate = request.crdate;
            dbNote.update = request.update;
            await _context.SaveChangesAsync();
            return Ok(await _context.Notes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Note>>> Delete(int id)

        {
            var dbNote = await _context.Notes.FindAsync(id);
            if (dbNote == null)
                return BadRequest("note dont found.");
            
            _context.Notes.Remove(dbNote);
            await  _context.SaveChangesAsync();
            return Ok(await _context.Notes.ToListAsync());
        }
    }
}
