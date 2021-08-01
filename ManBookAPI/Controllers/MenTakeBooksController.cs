using DataBaseRepository;
using DataBaseRepository.DTO_s;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using DataBaseRepository.DataBaseContexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenTakeBooksController : ControllerBase
    {
        //GET: api/<MenTakeBooksController>
        [HttpGet]
        public IEnumerable<ManTakeBookDto> Get()
        {
            using (var manTakeBookContext = new ManTakeBookContext())
            {               
                return manTakeBookContext.GetAllManTakeBook();
            }
        }

        // POST api/<MenTakeBooksController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] ManTakeBookDto newManTakeBookDto)
        {
            if (ModelState.IsValid)
            {
                using (var manTakeBookContext = new ManTakeBookContext())
                {                  
                    var result = manTakeBookContext.AddManTakeBook(newManTakeBookDto);
                    
                    return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true});
                }
            }
            return BadRequest();
        }    
    }
}
