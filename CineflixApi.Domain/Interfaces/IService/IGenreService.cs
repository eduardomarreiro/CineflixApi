using CineflixApi.Shared.Dto.Create;
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
    }
}
