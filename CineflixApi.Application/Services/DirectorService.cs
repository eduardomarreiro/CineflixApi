using AutoMapper;
using CineflixApi.Domain.Interfaces.IRepository;
using CineflixApi.Domain.Interfaces.IService;
using CineflixApi.Domain.Models;
using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
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
        public List<ReadDirectorDto> GetDirector()
        {
            List<Director> AllDirectors = _directorRepo.GetAll();
            List<ReadDirectorDto> directorDtosList = new List<ReadDirectorDto>();
            foreach(Director directors in AllDirectors)
            {
                ReadDirectorDto readDirectorDto = new ReadDirectorDto();
                readDirectorDto = _mapper.Map<ReadDirectorDto>(directors);
                directorDtosList.Add(readDirectorDto);
            }
            return directorDtosList;
        }

        public List<ReadDirectorDto> GetDirectorByAlphabeticalOrder()
        {
            List<Director> AllDirectors = _directorRepo.GetByAlphabeticalOrder();
            List<ReadDirectorDto> directorDtosList = new List<ReadDirectorDto>();

            foreach (Director directors in AllDirectors)
            {
                ReadDirectorDto readDirectorDto = new ReadDirectorDto();
                readDirectorDto = _mapper.Map<ReadDirectorDto>(directors);
                directorDtosList.Add(readDirectorDto);
            }
            return directorDtosList;
        }

        public ReadDirectorDto GetDirectorById(int id)
        {
            ReadDirectorDto directorDto = _mapper.Map<ReadDirectorDto>(id);
            _directorRepo.GetById(id);
            return directorDto;
        }

        public void DeleteDirector(int id)
        {
            Director director = _directorRepo.GetById(id);        
            if(director != null)
            {
                _directorRepo.Delete(director);
            }
        }
        public void UpdateDirector(int id, UpdateDirectorDto directorDto)
        {
            Director director = _directorRepo.GetById(id);
            if( director != null)
            {
                director.Id = id;
                director.Name = directorDto.Name;
                _directorRepo.Update(director);
            }
        }
    }
}
