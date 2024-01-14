using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateManager.Application.Contracts.v1.Templates.Response;

namespace TemplateManager.Application.Services.v1
{
    public class TemplateConfigService : ITemplateConfigService
    {
        private readonly HttpClient _httpClient;
        public TemplateConfigService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }


        #region --- (Functions not implemented by the TemplateManager API) ---
        public Task<GetTemplatesResponse> GetAllTemplatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetTemplatesResponse> GetTemplateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
} 

