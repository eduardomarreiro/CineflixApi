using CineflixApi.Shared.Dto.Create;
using CineflixApi.Shared.Dto.Read;
using CineflixApi.Shared.Dto.Update;
using System.Collections.Generic;

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
