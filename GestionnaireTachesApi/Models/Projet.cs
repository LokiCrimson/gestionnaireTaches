using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionnaireTachesApi.Models
{
    public class Projet
    {
        public int Id { get; set; }

        public string? Nom { get; set; }

        public ICollection<Tache> Taches { get; set; } = new List<Tache>();
    }
}
