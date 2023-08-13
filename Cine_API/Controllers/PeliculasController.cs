using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cine_API.Models;

namespace Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly CineContext _context;

        public PeliculasController(CineContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetMovies")]
        public IActionResult GetMovies() // todas las peliculas estatus A
        {
            var movies = _context.Peliculas.Where(x => x.Status == "A").ToList();
            if (movies != null)
            {
                return StatusCode(StatusCodes.Status200OK, movies);

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No hay data");
            }
        }

        [HttpGet]
        [Route("GetMovie")]
        public IActionResult GetMovie(int id) // una pelicula en especifico
        {
            var movies = _context.Peliculas.Where(x => x.IdPelicula == id && x.Status == "A").ToList();
            if (movies != null)
            {
                return StatusCode(StatusCodes.Status200OK, movies);

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Llene el formulario completo");
            }
        }

        [HttpPost]
        [Route("AddMovies")]
        public async Task<IActionResult> AddMovies(Pelicula pelicula) // agragregar pelicula
        {
            if (pelicula == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No ha ingresado la película");
            }

            var existingMovie = _context.Peliculas.FirstOrDefault(x => x.Titulo == pelicula.Titulo);

            if (existingMovie != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ya existe una película con este título");
            }
            pelicula.Status = "A";
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Película agregada correctamente");
        }

        [HttpPut]
        [Route("PutMovie")]
        public IActionResult PutMovie(Pelicula pelicula) // actualizar movie
        {
            if (pelicula != null)
            {
                _context.Peliculas.Update(pelicula);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "todo correcto");

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No ha Ingresado la pelicula");
            }
        }

        [HttpPut]
        [Route("DeleteMovie/{Id}")]
        public IActionResult DeleteMovie(int Id) // eliminar pelicula
        {
            try
            {
                Pelicula movie = _context.Peliculas.FirstOrDefault(x => x.IdPelicula == Id);

                if (movie != null)
                {
                    movie.Status = "I";
                    _context.Peliculas.Update(movie);
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, "Película eliminada correctamente");
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La película no fue encontrada");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ha ocurrido un error: {ex.Message}");
            }
        }
    }
}
