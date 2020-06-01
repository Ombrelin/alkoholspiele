using alkoholspiele.Models;
using alkoholspiele.Models.DTO;
using AutoMapper;

namespace alkoholspiele.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Game, GameDTO>().ReverseMap();
        }
    }
}