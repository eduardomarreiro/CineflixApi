using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Domain.Interfaces.IService
{
    public interface IGenreService
    {
        void AddGenre(CreateGenreDto genreDto);
        List<ReadGenreDto> GetAllGenres();
        List<ReadGenreDto> GetGenresByAlphabeticalOrder();
        ReadGenreDto GetGenreById(int id);
        void DeleteGenre(int id);
        void UpdateGenre(int id, UpdateGenreDto genreDto);
    }
}
