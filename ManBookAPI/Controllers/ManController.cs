using DataBaseRepository.DTO_s;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using ManBookAPI.Services;
using AutoMapper;
using DataBaseRepository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManController : ControllerBase
    {
        public ManController (IManService manRepository, IBookService bookRepository, IMapper mapper)
        {
            _manContext = manRepository;
            _bookContext = bookRepository;
            _mapper = mapper;
        }

        private readonly IManService _manContext;
        private readonly IBookService _bookContext;
        private readonly IMapper _mapper;

        // GET: api/<ManController>
        [HttpGet]
        public IEnumerable<ManDto> Get()
        {
            var men = _manContext.GetAllMen();
            var result = _mapper.Map<IEnumerable<Man>, IEnumerable<ManDto>>(men);
            return result;
        }

        // GET api/<ManController>/5
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name, string surname, string patronymic)
        {
            if (ModelState.IsValid)
            {
                var men = _manContext.GetMenBy(m => m.Name == name && m.Surname == surname && m.Patronymic == patronymic);
                var result = _mapper.Map<IEnumerable<Man>, IEnumerable<ManDto>>(men);
                return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });               
            }
            return BadRequest();
        }

        [HttpGet("/books/{id}")]
        public IEnumerable<BookDto> GetBooks(int id)
        {
            var books = _manContext.GetManBooks(id);
            var result = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books);
            return result;
        }

        // POST api/<ManController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] ManDto newMan)
        {
            if (ModelState.IsValid)
            {
                var manToAdd = _mapper.Map<ManDto, Man>(newMan);
                _manContext.AddMan(manToAdd);
                _manContext.Save();
                //Проверить, точно ли возвращается нужный человек
                var result = _mapper.Map<Man, ManDto>(_manContext.GetManBy(m => m.Id == manToAdd.Id));
                return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
                
            }
            return BadRequest();

        }

        // POST api/<ManController>
        [HttpPost]
        [Route("/addBook")]
        public ActionResult<string> Post(int id, [FromBody] BookDto newBook)
        {
            if (ModelState.IsValid)
            {
                if(!_manContext.ContainsBy(x => x.Id == id))
                {
                    return BadRequest($"No man with ID = {id}");
                }
                var man = _manContext.GetManBy(m => m.Id == id);
                var bookToAdd = _mapper.Map<BookDto, Book>(newBook);
                if (!_bookContext.Contains(bookToAdd))
                {
                    _bookContext.AddBook(bookToAdd);
                    _bookContext.Save();
                }
                bookToAdd = _bookContext.GetBookBy(b => b.Author.Equals(newBook.Author) && b.Title == newBook.Title);
                _manContext.AddManBook(man, bookToAdd);
                //_manContext.AddMan(manToAdd);
                _manContext.Save();
                //Проверить, точно ли возвращается нужный человек
                var result = _mapper.Map<Man, ManDto>(_manContext.GetManBy(m => m.Id == id));
                return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });

            }
            return BadRequest();

        }

        // DELETE api/<ManController>/5
        [HttpDelete("{name}&{surname}&{patronymic}")]
        public ActionResult Delete(string name, string surname, string patronymic)
        {
            if (ModelState.IsValid)
            {
                if (_manContext.ContainsBy(m => m.Name == name && m.Surname == surname && m.Patronymic == patronymic))
                {
                    _manContext.DeleteMenBy(m => m.Name == name && m.Surname == surname && m.Patronymic == patronymic);
                    _manContext.Save();
                    return Ok();
                }
                return BadRequest("The man with such a combination {name}, {surname} and {patronymic} doesn't exist");
            }
            return BadRequest("The model state is invalid");
        }

        // DELETE api/<ManController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_manContext.ContainsBy(m => m.Id == id))
            {
                _manContext.DeleteMenBy(m => m.Id == id);
                _manContext.Save();
                return Ok();                
            }
            return BadRequest("This ID doesn't exist");
        }

        [HttpDelete("deleteManBook")]
        public ActionResult Delete(int id, BookDto book)
        {
            var bookToDelete = _mapper.Map<BookDto, Book>(book);
            if(!_bookContext.ContainsBy(b =>
                b.Author.Equals(book.Author) && b.Title == book.Title))
            {
                //_bookContext.AddBook(boo)
                return BadRequest("This book doesn't exist");

            }
            if (_manContext.ContainsBy(m => m.Id == id))
            {
                _manContext.DeleteManBook(_manContext.GetManBy(m => m.Id == id), bookToDelete);
                _manContext.DeleteMenBy(m => m.Id == id);
                _manContext.Save();
                return Ok();
            }
            return BadRequest("This ID doesn't exist");
        }
    }
}
