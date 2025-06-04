using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionnaireTachesApi.Data;
using GestionnaireTachesApi.Models;
using GestionnaireTachesApi.DTOs;
using AutoMapper;

namespace GestionnaireTachesApi.Controllers
{
    [ApiController]
    [Route("api/projets")]
    public class ProjetsController : ControllerBase
    {
        private readonly TachesDbContext _contexte;
        private readonly IMapper _mapper;

        public ProjetsController(TachesDbContext contexte, IMapper mapper)
        {
            _contexte = contexte;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetDto>>> GetProjets()
        {
            var projets = await _contexte.Projets
                .Include(p => p.Taches)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ProjetDto>>(projets));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetDto>> GetProjetParId(int id)
        {
            var projet = await _contexte.Projets
                .Include(p => p.Taches)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projet == null)
                return NotFound();

            return Ok(_mapper.Map<ProjetDto>(projet));
        }

        [HttpPost]
        public async Task<ActionResult<ProjetDto>> CreerProjet(ProjetDto projetDto)
        {
            var projet = _mapper.Map<Projet>(projetDto);
            _contexte.Projets.Add(projet);
            await _contexte.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjetParId), new { id = projet.Id }, _mapper.Map<ProjetDto>(projet));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MettreAJourProjet(int id, ProjetDto projetDto)
        {
            if (id != projetDto.Id)
                return BadRequest();

            var projet = await _contexte.Projets.FindAsync(id);
            if (projet == null)
                return NotFound();

            _mapper.Map(projetDto, projet);
            await _contexte.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SupprimerProjet(int id)
        {
            var projet = await _contexte.Projets.FindAsync(id);
            if (projet == null)
                return NotFound();

            _contexte.Projets.Remove(projet);
            await _contexte.SaveChangesAsync();

            return NoContent();
        }
    }
}
