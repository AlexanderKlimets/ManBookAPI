using AutoMapper;
using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using ManBookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public BookController(IBookService bookContext, IMapper mapper)
        {
            _bookContext = bookContext;
            _mapper = mapper;
        }

        private readonly IBookService _bookContext;        
        private readonly IMapper _mapper;

        // GET: api/<Book>
        [HttpGet]
        public IEnumerable<BookDto> Get()
        {
            var result = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(_bookContext.GetAllBooks());
            return result;
        }

        // POST api/<Book>
        [HttpPost]
        public ActionResult<string> Post([FromBody] BookDto newBook)
        {
            if (ModelState.IsValid)
            {
                var bookToAdd = _mapper.Map<BookDto, Book>(newBook);                              
                _bookContext.AddBook(bookToAdd);
                var result = _mapper.Map<Book, BookDto>(_bookContext.GetBook(bookToAdd));              
                return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });                
            }
            return BadRequest();

        }

        // DELETE api/<Book>/5
        [HttpDelete("{authorName}&{title}")]
        public ActionResult Delete(Author authorName, string title)
        {
            
            if (ModelState.IsValid)
            {
                _bookContext.DeleteBooks(authorName, title);
                _bookContext.Save();               
                return Ok();
            }
            return BadRequest();
        }     
    }
}
