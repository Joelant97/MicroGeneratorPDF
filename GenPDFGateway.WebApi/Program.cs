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

    ChromePdfRenderer renderer = new ChromePdfRenderer();

    var htmlTemplate = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<title>Carta de Solicitud</title>\r\n" +
    "</head>\r\n<body>\r\n<h1>Carta de Solicitud</h1>\r\n<p>Estimado/a [[AddresseeName]],</p>\r\n" +
    "<p>Me dirijo a usted para expresar mi interés en el puesto de [[DesiredPosition]]\r\nen su empresa. " +
    "Soy un/a profesional con experiencia en el campo y estoy\r\nentusiasmado/a con la oportunidad de formar" +
    " parte de su equipo.</p>\r\n<p>Adjunto a esta carta encontrará mi currículum vitae, que detalla mi " +
    "formación\r\nacadémica y mi experiencia laboral relevante. Estoy seguro/a de que mis\r\nhabilidades y " +
    "conocimientos en [[RelevantAreas]] serán un valioso aporte para su\r\norganización.</p>\r\n<p>Quedo a su " +
    "disposición para proporcionar cualquier información adicional que\r\npueda necesitar. Agradezco de antemano " +
    "su consideración y espero tener la\r\noportunidad de discutir cómo puedo contribuir al éxito de su empresa." +
    "</p>\r\n<p>Atentamente,</p>\r\n<p>[[AuthorName]]</p>\r\n<p>[[CurrentDate]]</p>\r\n</body>\r\n</html>";


    string addresseeName = "@Grupo Punta Cana";
    string desiredPosition = "Desarrollador";
    string relevantAreas = "Desarrollo de Software";
    string authorName = "Joel Antonio";
    string currentDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
    string currentDate2 = DateTime.Now.Millisecond.ToString();

    var htmlInstance = htmlTemplate.Replace("[[AddresseeName]]", addresseeName);
    var pdf = renderer.RenderHtmlAsPdf(htmlInstance);
    pdf.SaveAs( "Documento_"+authorName+"_"+currentDate+"-"+currentDate2+".pdf");

});


//Service to call TemplateApi Microservice
app.MapGet("/generator", () =>
{
    
}); 

app.Run();
