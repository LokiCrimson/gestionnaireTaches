using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionnaireTachesApi.Models;
using GestionnaireTachesApi.Data;

[ApiController]
[Route("api/projets")]
public class ProjetsController : ControllerBase
{
    private readonly TachesDbContext _contexte;

    public ProjetsController(TachesDbContext contexte)
    {
        _contexte = contexte;
    }

    // GET: api/projets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Projet>>> GetProjets()
    {
        return await _contexte.Projets
            .Include(p => p.Taches)
            .ToListAsync();
    }

    // GET: api/projets/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Projet>> GetProjetParId(int id)
    {
        var projet = await _contexte.Projets
            .Include(p => p.Taches)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (projet == null)
        {
            return NotFound();
        }

        return projet;
    }

    // POST: api/projets
    [HttpPost]
    public async Task<ActionResult<Projet>> CreerProjet(Projet projet)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _contexte.Projets.Add(projet);
        await _contexte.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProjetParId), new { id = projet.Id }, projet);
    }
}
