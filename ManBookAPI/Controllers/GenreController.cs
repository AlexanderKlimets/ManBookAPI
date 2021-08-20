using AutoMapper;
using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using ManBookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public GenreController(IGenreService genreRepository, IMapper mapper)
        {
            _genreContext = genreRepository;
            _mapper = mapper;
        }

        private readonly IGenreService _genreContext;
        private readonly IMapper _mapper;

        // GET: api/<GenreController>
        [HttpGet]
        public IEnumerable<GenreDto> Get()
        {
            var result = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(_genreContext.GetAllGenres());
            return result;
        }

        // GET: api/<GenreController>
        [HttpGet]
        [Route("/getStatistic")]
        public ActionResult<string> GetStatistic()
        {
            var result = _genreContext.GetStatistic();
            
            return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true }); ;
        }

        // POST api/<GenreController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] GenreDto newGenre)
        {
            if(ModelState.IsValid)
            {
                var genreToAdd = _mapper.Map<GenreDto, Genre>(newGenre);
                _genreContext.AddGenre(genreToAdd);
                _genreContext.Save();
                var result = _mapper.Map<Genre, GenreDto>(_genreContext.GetGenreBy(g => g.GenreName == genreToAdd.GenreName));
                return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
            }
            return BadRequest();
        }
    }
}
