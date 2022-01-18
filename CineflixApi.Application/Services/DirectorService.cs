using AutoMapper;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Application.Services
{
    public class DirectorService : IDirectorService
    {
        public IDirectorRepository _directorRepo;
        public IMapper _mapper;

        public DirectorService(IDirectorRepository directorRepo, IMapper mapper)
        {
            _directorRepo = directorRepo;
            _mapper = mapper;
        }

        public void AddDirector(CreateDirectorDto directorDto)
        {
            Director director = _mapper.Map<Director>(directorDto);
            _directorRepo.Add(director);
        }
        //public List<ReadDirectorDto> GetDirectors()
        //{
        //    List<Director> directors = new List<Director>();  ********** fazer uma conversão bem chata!!

        //    return _directorRepo.GetAll();
        //}
    }
}
