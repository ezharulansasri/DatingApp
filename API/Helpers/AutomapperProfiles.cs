using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;
using API.Extension;

namespace API.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AppUser,MembersDTO>()
            .ForMember(dest =>dest.PhotoUrl, opt=>opt.MapFrom(src=>
            src.Photos.FirstOrDefault(x=>x.IsMain).Url))
            .ForMember(dest =>dest.Age, opt=>opt.MapFrom(src=>src.DateOfBirth.CaculateAge()));

            CreateMap<Photo,PhotoDTO>();
        }
    }
}