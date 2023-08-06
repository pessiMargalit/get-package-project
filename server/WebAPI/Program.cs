using BL;
using Dal.Models;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<GetPackageDBSettings>(
    builder.Configuration.GetSection(nameof(GetPackageDBSettings)));
builder.Services.AddSingleton<IGetPackageDBSettings>(sp =>
sp.GetRequiredService<IOptions<GetPackageDBSettings>>().Value);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.InjectionsBL();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{
    var frontedURL = configuration.GetValue<string>("fronted_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontedURL).AllowAnyMethod().AllowAnyHeader();
    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();




