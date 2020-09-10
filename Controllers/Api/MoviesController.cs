using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vid.Dtos;
using Vid.Models;

namespace Vid.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies()
        {

            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));

        }

        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null) return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(MovieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            MovieDto.Id = movie.Id;
            return Created(new Uri( Request.RequestUri+"/"+movie.Id),MovieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id,MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null) return NotFound();
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }




    }
}
