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
    public interface IDirectorService 
    {
        void AddDirector(CreateDirectorDto directorDto);
        List<ReadDirectorDto> GetAllDirectors();
        List<ReadDirectorDto> GetDirectorByAlphabeticalOrder();
        ReadDirectorDto GetDirectorById(int id);
        void DeleteDirector(int id);
        void UpdateDirector(int id, UpdateDirectorDto directorDto);
    }
}
