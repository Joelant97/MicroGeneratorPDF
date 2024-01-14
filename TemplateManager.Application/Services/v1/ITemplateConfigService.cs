using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Application.Contracts.v1.Templates.Response;

namespace TemplateManager.Application.Services.v1
{
    public interface ITemplateConfigService
    {
        public Task<GetTemplatesResponse> GetAllTemplatesAsync();
        public Task<GetTemplatesResponse> GetTemplateByIdAsync(int id); 

    }

}
