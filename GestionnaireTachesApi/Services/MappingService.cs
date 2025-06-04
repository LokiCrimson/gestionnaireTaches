using AutoMapper;
using GestionnaireTachesApi.Models;
using GestionnaireTachesApi.DTOs;

namespace GestionnaireTachesApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Projet, ProjetDto>().ReverseMap();
            CreateMap<Tache, TacheDto>().ReverseMap();
        }
    }
}
