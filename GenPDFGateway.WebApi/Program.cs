using HandlebarsDotNet;
using IronPdf;
using IronPdf.Rendering;

var builder = WebApplication.CreateBuilder(args);

IronPdf.License.LicenseKey = builder.Configuration.GetConnectionString("LicenseKeyIronPdf");

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapPost("/generator", () =>
{

    //TODO:Logic to get the data from TempleManagerAPI
    //And Custom the info with the Client App info Context.

    var htmlTemplate = "<!DOCTYPE html>\r\n\t<html>\r\n\t<head>\r\n\t<title>Carta de Solicitud</title>" +
    "\r\n\t</head>\r\n\t<body>\r\n\t<h1>Carta de Solicitud</h1>\r\n\t<p>Estimado/a {{AddresseeName}},</p>" +
    "\r\n\t<p>Me dirijo a usted para expresar mi interés en el puesto de {{DesiredPosition}}\r\n\ten su empresa." +
    " Soy un/a profesional con experiencia en el campo y estoy\r\n\tentusiasmado/a con la oportunidad de formar " +
    "parte de su equipo.</p>\r\n\t<p>Adjunto a esta carta encontrará mi currículum vitae, que detalla mi formación" +
    "\r\n\tacadémica y mi experiencia laboral relevante. Estoy seguro/a de que mis\r\n\thabilidades y conocimientos" +
    " en {{RelevantAreas}} serán un valioso aporte para su\r\n\torganización.</p>\r\n\t<p>Quedo a su disposición para" +
    " proporcionar cualquier información adicional que\r\n\tpueda necesitar. Agradezco de antemano su consideración y" +
    " espero tener la\r\n\toportunidad de discutir cómo puedo contribuir al éxito de su empresa.</p>\r\n\t" +
    "<p>Atentamente,</p>\r\n\t<p>{{AuthorName}}</p>\r\n\t<p>{{CurrentDate}}</p>\r\n\t</body>\r\n\t</html>";


    string authorName = "Joel Antonio";
    string currentDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
    string currentDate2 = DateTime.Now.Millisecond.ToString();

    var template = Handlebars.Compile(htmlTemplate);

    var data = new { 
        AddresseeName = "Grupo Punta Cana",
        DesiredPosition = "Desarrollador",
        RelevantAreas = "Desarrollo de Software",
        AuthorName = authorName,
        CurrentDate = currentDate
        };
    var result = template(data);

    var renderer = new ChromePdfRenderer();
    var pdf = renderer.RenderHtmlAsPdf(result);
    pdf.SaveAs( "Doc_"+authorName+"_"+currentDate+"-"+currentDate2+".pdf");

});


//Service to call TemplateApi Microservice
app.MapGet("/generator", () =>
{
    
}); 

app.Run();
