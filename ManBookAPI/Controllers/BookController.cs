using DataBaseRepository;
using DataBaseRepository.DataBaseContexts;
using DataBaseRepository.DTO_s;
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
    public class BookController : ControllerBase
    {
        // GET: api/<Book>
        [HttpGet]
        public IEnumerable<BookDto> Get()
        {
            using (var bookContext = new BookContext())
            {
                
                return bookContext.GetAllBooks();
            }
        }

        // GET api/<Book>/5
        [HttpGet("{authorName}")]
        public ActionResult<string> Get(string authorName)
        {
            if(ModelState.IsValid)
            {
                using (var bookContext = new BookContext())
                {
                    var result = bookContext.GetBooksByAuthorName(authorName);
                    return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
                }
            }
            return BadRequest();
                         
        }

        // POST api/<Book>
        [HttpPost]
        public ActionResult<string> Post([FromBody] BookDto newBook)
        {
            if(ModelState.IsValid)
            {
                using (var bookContext = new BookContext())
                {
                    var result = bookContext.AddBookAndReturnList(newBook);
                    return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
                }
            }
            return BadRequest();
            
        }
       
        // DELETE api/<Book>/5
        [HttpDelete("{authorName}&{title}")]
        public ActionResult Delete(string authorName, string title)
        {
            if (ModelState.IsValid)
            {
                using (var bookContext = new BookContext())
                {
                    bookContext.DeleteBook(authorName, title);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
