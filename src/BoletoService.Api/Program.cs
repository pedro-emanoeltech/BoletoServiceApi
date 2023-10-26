using BoletoService.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBoletoContext(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.ConfigureApiServices();
builder.Services.AddControllers();
builder.Services.AutoMapperConfiguration();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.ConfigurationPostgresEscopo();
app.UseConfigureApi();





app.Run();
