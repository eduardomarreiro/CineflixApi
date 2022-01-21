using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Shared.Dto.Read
{
    public class ReadMovieNoDirectorDto
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public ReadGenreDto Genre { get; set; }

        public int Runtime { get; set; }
    }
}
