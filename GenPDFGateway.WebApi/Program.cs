using Azure.Core;
using GenPDFGateway.WebApi.Contracts.v1.DTO;
using GenPDFGateway.WebApi.Contracts.v1.Response;
using HandlebarsDotNet;
using IronPdf;
using IronPdf.Rendering;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Buffers.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using TemplateManagerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

IronPdf.License.LicenseKey = builder.Configuration.GetConnectionString("LicenseKeyIronPdf");
string routeTemp = builder.Configuration.GetConnectionString("TemplateServices");

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapPost("/generator", async ([FromBody] Generator generator) =>
{

    //TODO:Logic to get the data from TempleManagerAPI
    //call Microservice in TemplateMngApi
    var httpClient = new HttpClient();
    var uri = routeTemp + generator.template_id;
    var jsonResponse = await httpClient.GetStringAsync(uri);
    var template = JsonConvert.DeserializeObject<Template>(jsonResponse);

    //And Custom the info with the Client App info Context.

    //Format Name in Document
    string authorName = generator.context.author_name;
    string currentDate = generator.context.current_date;
    string currentDate2 = DateTime.Now.Millisecond.ToString();


    var tempHandlComp = Handlebars.Compile(template.Content);

    var data = new {
        AddresseeName = generator.context.addressee_name,
        DesiredPosition = generator.context.desired_position,
        RelevantAreas = generator.context.relevant_areas,
        AuthorName = authorName,
        CurrentDate = currentDate
    };
    var result = tempHandlComp(data);

    var renderer = new ChromePdfRenderer();
    var pdf = renderer.RenderHtmlAsPdf(result);
    string docName = "Doc_" + authorName + "_" + currentDate + "-" + currentDate2 + ".pdf";
    pdf.SaveAs(docName);


    var obj = new GeneratorResponse
    {
        pdf = docName
    };

    var jsonResult = JsonConvert.SerializeObject(obj);
    return jsonResult;

});


// GET: api/<GeneratorController>
app.MapGet("/generator", () =>
{
    
}); 

app.Run();
