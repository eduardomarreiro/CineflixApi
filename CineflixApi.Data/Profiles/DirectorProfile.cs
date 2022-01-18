using AutoMapper;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Data.Profiles
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile()
        {
            CreateMap<Director, ReadDirectorDto>();
            CreateMap<CreateDirectorDto, Director>();
            CreateMap<UpdateDirectorDto, Director>();
        }
    }
}
