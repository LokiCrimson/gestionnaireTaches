using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionnaireTachesApi.Models;
using GestionnaireTachesApi.Data;

[ApiController]
[Route("api/taches")]
public class TachesController : ControllerBase
{
    private readonly TachesDbContext _contexte;

    public TachesController(TachesDbContext contexte)
    {
        _contexte = contexte;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tache>>> GetTaches()
    {
        return await _contexte.Taches.Include(t => t.Projet).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Tache>> CreerTache(Tache tache)
    {
        _contexte.Taches.Add(tache);
        await _contexte.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTaches), new { id = tache.Id }, tache);
    }

    [HttpPut("{id}/terminer")]
    public async Task<IActionResult> MarquerCommeTerminee(int id)
    {
        var tache = await _contexte.Taches.FindAsync(id);
        if (tache == null) return NotFound();

        tache.EstTerminee = true;
        await _contexte.SaveChangesAsync();
        return NoContent();
    }
}
