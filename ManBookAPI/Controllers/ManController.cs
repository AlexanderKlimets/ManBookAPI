using DataBaseRepository;
using DataBaseRepository.DTO_s;
using DataBaseRepository.DataBaseContexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManController : ControllerBase
    {

        // GET: api/<ManController>
        [HttpGet]
        public IEnumerable<ManDto> Get()
        {           
            using (var menContext = new MenContext())
            {               
                return menContext.GetAllMen();
            }
        }

        // GET api/<ManController>/5
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            if(ModelState.IsValid)
            {
                using (var menContext = new MenContext())
                {
                    var result = menContext.GetMenByName(name);
                    return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
                }
            }
            return BadRequest();
        }

        // POST api/<ManController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] ManDto newMan)
        {
            if(ModelState.IsValid)
            {
                using (var menContext = new MenContext())
                {
                    var result = menContext.AddManAndReturnList(newMan);
                    return JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
                }
            }
            return BadRequest();
            
        }        

        // DELETE api/<ManController>/5
        [HttpDelete("{name}&{surname}&{patronymic}")]
        public ActionResult Delete(string name, string surname, string patronymic)
        {
            if (ModelState.IsValid)
            {
                using (var menContext = new MenContext())
                {
                    menContext.DeleteMan(name, surname, patronymic);
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
