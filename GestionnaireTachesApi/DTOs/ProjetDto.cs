using System.Collections.Generic;

namespace GestionnaireTachesApi.DTOs
{
    public class ProjetDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<TacheDto> Taches { get; set; } = new();
    }
}
