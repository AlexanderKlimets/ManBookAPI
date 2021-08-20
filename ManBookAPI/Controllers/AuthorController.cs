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
    public class AuthorController : ControllerBase
    {
        public AuthorController(IAuthorService authorRepository, IBookService bookRepository, IMapper mapper)
        {
            _authorContext = authorRepository;
            _bookContext = bookRepository;
            _mapper = mapper;
        }

        private readonly IAuthorService _authorContext;
        private readonly IBookService _bookContext;
        private readonly IMapper _mapper;

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<AuthorDto> Get()
        {
            var authors = _authorContext.GetAllAuthors();
            var result = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(authors);
            return result;
        }

        // GET api/<AuthorController>/5
        [HttpGet("getAuthorBooks")]
        public ActionResult<string> Get(string firstName, string MiddleName, string lastName)
        {
            //_mapper.Map<AuthorDto, Author>(author);
            if(!_authorContext.ContainsBy(x =>
                x.FirstName == firstName &&
                x.MiddleName == MiddleName &&
                x.LastName == lastName))
            {
                return NotFound("This author doen't exsist");
            }
            var resultAuthor = _authorContext.GetAuthorBy(x =>
                x.FirstName == firstName &&
                x.MiddleName == MiddleName &&
                x.LastName == lastName);
            var books = _bookContext.GetBooksBy(b => b.Author.Equals(resultAuthor));
            var booksJson = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
            var author = _mapper.Map<Author, AuthorDto>(resultAuthor);
            var authorJson = JsonSerializer.Serialize(author, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
            return $"[author:{authorJson},\nbooks:{booksJson}]";
        }

        // POST api/<AuthorController>
        [HttpPost]
        public ActionResult<AuthorDto> Post(AuthorDto newAuthor)//, List<Book> books)
        {
            if(_authorContext.ContainsBy(a =>
               a.FirstName == newAuthor.FirstName &&
               a.LastName == newAuthor.LastName &&
               a.MiddleName == newAuthor.MiddleName))
            {
                return BadRequest("This author already exsist");
            }
            var authorToAdd = _mapper.Map<AuthorDto, Author>(newAuthor);
            _authorContext.AddAuthor(authorToAdd);
            _authorContext.Save();
            var result = _mapper.Map<Author, AuthorDto>(_authorContext.GetAuthorBy(a =>
               a.FirstName == newAuthor.FirstName &&
               a.LastName == newAuthor.LastName &&
               a.MiddleName == newAuthor.MiddleName));
            return result;
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var test = _bookContext.GetBooksBy(b => b.Author.Id == id);
            if (_bookContext.GetBooksBy(b => b.Author.Id == id).Count() != 0)
            {
                BadRequest("Can't delete authors with books");
            }
            _authorContext.DeleteAuthorBy(a => a.Id == id);
            _authorContext.Save();
            return Ok();
        }
    }
}
