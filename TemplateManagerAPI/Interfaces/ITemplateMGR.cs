using TemplateManagerAPI.Models;

namespace TemplateManagerAPI.Interfaces
{
    public interface ITemplateMGR
    {
        // Return list of Templates
        Task<List<Template>> GetAllTemplates();
        // Return single template data against the template id
        // This method will also take an ID parameter
        Task<Template> GetTemplateById(int id);
        // This method will add the template
        /* This method will take template object
          as a parameter and will not return anything.*/
        Task AddTemplate(Template template);
        // This method will update the template data
        /* We need to pass the id as a parameter of type integer to update the template record
          and will not return anything. */
        Task UpdateTemplate(int id, Template template);
        // This method used to delete a particular record based on id as a parameter
        Task DeleteTemplate(int id);
    }
}
