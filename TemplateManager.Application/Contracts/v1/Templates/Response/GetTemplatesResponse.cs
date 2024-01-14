using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.Application.Contracts.v1.Templates.Response
{
    public record GetTemplatesResponse
    {
        public List<Template> Templates { get; set; } = new List<Template>();

        public record Template
        {
            public int id { get; set; }
            public string name { get; set; }
            public string content { get; set; }
            public string addresseeName { get; set; }
            public string desiredPosition { get; set; }
            public string authorName { get; set; }
            public DateTime? currentDate { get; set; }
            public string fileType { get; set; }

        }
    }

}
