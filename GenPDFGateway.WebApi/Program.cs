var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapPost("/generator", () =>
{
    //TODO:Logic to get the data from TempleManagerAPI
    //And Custom the info with the Client App info Context.

    //var htmlCode = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "TemplateFile\\cartasolicitud.html");
    var htmlCode = File.ReadAllText("C:\\WorkSpace\\MicroGeneratorPDF\\GenPDFGateway.WebApi\\TemplateFile\\cartasolicitud-JoelAntonio.html");

    SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
    SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlCode);
    //doc.Save(AppDomain.CurrentDomain.BaseDirectory + "PdfGenerated\\cartasolicitud.pdf");
    doc.Save("C:\\WorkSpace\\MicroGeneratorPDF\\GenPDFGateway.WebApi\\PdfGenerated\\cartasolicitud-JoelAntonio.pdf");
    doc.Close();

  /*
    byte[] data = doc.Save();
    var result = Convert.ToBase64String(data);
    doc.Close();
    //{status = "ok", data = "result"};
    return result;
  */
    
});


//Service to call TemplateApi Microservice
app.MapGet("/generator", () =>
{
    
}); 



app.Run();



