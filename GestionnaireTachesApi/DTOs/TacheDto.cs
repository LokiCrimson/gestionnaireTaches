using System;

namespace GestionnaireTachesApi.DTOs
{
    public class TacheDto
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime DateEcheance { get; set; }
        public bool EstTerminee { get; set; }
        public int ProjetId { get; set; }
    }
}
