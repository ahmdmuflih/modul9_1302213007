using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using modul9_1302213007;

namespace modul9_1302213007.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>()
        {
            new Movie() { Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton" }, Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency." },
            new Movie() { Title = "The Godfather", Director = "Francis Ford Coppola", Stars = new List<string> { "Marlon Brando", "Al Pacino", "James Caan" }, Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son." },
            new Movie() { Title = "The Dark Knight", Director = "Christopher Nolan", Stars = new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart" }, Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
        };

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            movie.Id = _movies.Count + 1;
            _movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _movies.Remove(movie);
            return NoContent();
        }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Stars { get; set; }
        public string Description { get; set; }
    }
}
