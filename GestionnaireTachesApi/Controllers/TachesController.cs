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

        [HttpPost]
        public async Task<ActionResult<TacheDto>> CreerTache(TacheDto tacheDto)
        {
            var tache = _mapper.Map<Tache>(tacheDto);
            _contexte.Taches.Add(tache);
            await _contexte.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaches), new { id = tache.Id }, _mapper.Map<TacheDto>(tache));
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
    }
}
