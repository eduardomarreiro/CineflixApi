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
    public class GenreService : IGenreService
    {
        public IGenreRepository _genreRepo;
        public IMapper _mapper;

        public GenreService(IGenreRepository genreRepo, IMapper mapper)
        {
            _genreRepo = genreRepo;
            _mapper = mapper;
        }

        public void AddGenre(CreateGenreDto genreDto)
        {
            Genre genre = _mapper.Map<Genre>(genreDto);
            _genreRepo.Add(genre);
        }

        public List<ReadGenreDto> GetGenre()
        {
            List<Genre> AllGenres = _genreRepo.GetAll();
            List<ReadGenreDto> genreDtosList = new List<ReadGenreDto>();
            foreach (Genre genres in AllGenres)
            {
                ReadGenreDto readGenreDto = new ReadGenreDto();
                readGenreDto = _mapper.Map<ReadGenreDto>(genres);
                genreDtosList.Add(readGenreDto);
            }
            return genreDtosList;
        }

        public ReadGenreDto GetGenreById(int id)
        {
            ReadGenreDto genreDto = _mapper.Map<ReadGenreDto>(id);
            _genreRepo.GetById(id);
            return genreDto;
        }

        public void DeleteGenre(int id)
        {
            Genre genre = _genreRepo.GetById(id);
            if(genre != null)
            {
                _genreRepo.Delete(genre);
            }
        }
        public void UpdateGenre(int id, UpdateGenreDto genreDto)
        {
            Genre genre = _genreRepo.GetById(id);
            if(genre != null)
            {
                genre.Id = id;
                genre.Name = genreDto.Name;
                _genreRepo.Update(genre);
            }
        }
    }
}
