using UssjStream.Web;

var builder = WebApplication.CreateBuilder(args);
// Utilise Startup pour configurer les services et l'application
var startup = new Startup();
startup.ConfigureServices(builder);

var app = builder.Build();

startup.Configure(app, app.Environment);
app.Run();
