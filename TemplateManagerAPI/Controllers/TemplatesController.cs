using Microsoft.AspNetCore.Mvc;
using TemplateManagerAPI.Interfaces;
using TemplateManagerAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TemplateManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private ITemplateMGR _templateService;
        public TemplatesController(ITemplateMGR templateService)
        {
            _templateService = templateService;
        }
        // GET: api/<TemplatesController>
        [HttpGet]
        public async Task<IEnumerable<Template>> Get()
        {
            var vehicles = await _templateService.GetAllTemplates();
            return vehicles;
        }

        // GET api/<TemplatesController>/5
        [HttpGet("{id}")]
        public async Task<Template> Get(int id)
        {
            return await _templateService.GetTemplateById(id);
        }

        // POST api/<TemplatesController>
        [HttpPost]
        public async Task Post([FromBody] Template template)
        {
            await _templateService.AddTemplate(template);
        }

        // PUT api/<TemplatesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Template template)
        {
            await _templateService.UpdateTemplate(id, template);
        }

        // DELETE api/<TemplatesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _templateService.DeleteTemplate(id);
        }
    }
}
