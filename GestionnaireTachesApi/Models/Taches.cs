using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionnaireTachesApi.Models
{
    public class Tache
    {
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DateEcheance { get; set; }

        public bool EstTerminee { get; set; }

        [ForeignKey("Projet")]
        public int ProjetId { get; set; }

        public Projet? Projet { get; set; }
    }
}
