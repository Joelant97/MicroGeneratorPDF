using Microsoft.EntityFrameworkCore;
using TemplateManagerAPI.Interfaces;
using TemplateManagerAPI.Models;

namespace TemplateManagerAPI.Services
{
    public class TemplateService : ITemplateMGR
    {
        private TemplatemgrContext _context;
        public TemplateService()
        {
            _context = new TemplatemgrContext();
        }
        public async Task AddTemplate(Template template)
        {
            // This line will add template data and set the database.
            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTemplate(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template != null)
            {
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync(true);
            }
        }
        public async Task<List<Template>> GetAllTemplates()
        {
            // This line will return list of templates
            var templates = await _context.Templates.ToListAsync();
            return templates;
        }
        public async Task<Template> GetTemplateById(int id)
        {
            // This line will return the specific template record based on id pass as a parameter
            var template = await _context.Templates.FindAsync(id);
            return template;
        }
        public async Task UpdateTemplate(int id, Template template)
        {
            var templateObj = await _context.Templates.FindAsync(id);
            templateObj.Name = template.Name;
            templateObj.Content = template.Content;
            templateObj.AddresseeName = template.AddresseeName;
            templateObj.DesiredPosition = template.DesiredPosition;
            templateObj.AuthorName = template.AuthorName;
            templateObj.CurrentDate = DateTime.Now;
            templateObj.FileType = template.FileType;
            await _context.SaveChangesAsync();
        }
    }
}
