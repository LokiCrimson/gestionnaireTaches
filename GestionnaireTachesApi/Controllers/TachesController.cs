using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionnaireTachesApi.Data;
using GestionnaireTachesApi.Models;
using GestionnaireTachesApi.DTOs;
using AutoMapper;

namespace GestionnaireTachesApi.Controllers
{
    [ApiController]
    [Route("api/taches")]
    public class TachesController : ControllerBase
    {
        private readonly TachesDbContext _contexte;
        private readonly IMapper _mapper;

        public TachesController(TachesDbContext contexte, IMapper mapper)
        {
            _contexte = contexte;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TacheDto>>> GetTaches()
        {
            var taches = await _contexte.Taches.Include(t => t.Projet).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TacheDto>>(taches));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TacheDto>> GetTacheParId(int id)
        {
            var tache = await _contexte.Taches.Include(t => t.Projet).FirstOrDefaultAsync(t => t.Id == id);
            if (tache == null)
                return NotFound();

            return Ok(_mapper.Map<TacheDto>(tache));
        }

        [HttpPost]
        public async Task<ActionResult<TacheDto>> CreerTache(TacheDto tacheDto)
        {
            var tache = _mapper.Map<Tache>(tacheDto);
            _contexte.Taches.Add(tache);
            await _contexte.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaches), new { id = tache.Id }, _mapper.Map<TacheDto>(tache));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MettreAJourTache(int id, TacheDto tacheDto)
        {
            if (id != tacheDto.Id)
                return BadRequest();

            var tache = await _contexte.Taches.FindAsync(id);
            if (tache == null)
                return NotFound();

            _mapper.Map(tacheDto, tache);
            await _contexte.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/terminer")]
        public async Task<IActionResult> MarquerCommeTerminee(int id)
        {
            var tache = await _contexte.Taches.FindAsync(id);
            if (tache == null)
                return NotFound();

            tache.EstTerminee = true;
            await _contexte.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SupprimerTache(int id)
        {
            var tache = await _contexte.Taches.FindAsync(id);
            if (tache == null)
                return NotFound();

            _contexte.Taches.Remove(tache);
            await _contexte.SaveChangesAsync();

            return NoContent();
        }
    }
}
