using System;
using System.Collections.Generic;

namespace TemplateManagerAPI.Models;

public partial class Template
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? AddresseeName { get; set; }

    public string? DesiredPosition { get; set; }

    public string? AuthorName { get; set; }

    public DateTime? CurrentDate { get; set; }

    public string? FileType { get; set; }
}
