using System;
using System.Collections.Generic;

namespace TemplateManagerAPI.Models;

public partial class Template
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public string? FileType { get; set; }
}
