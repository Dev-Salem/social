using System.Reflection;
using Microsoft.EntityFrameworkCore;
using social.Data;
using social.Interfaces;
using social.Models;
using social.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlite(GetDbPath());
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBaseService<Post>, PostService>();
builder.Services.AddScoped<IBaseService<Answer>, AnswerService>();
builder.Services.AddScoped<IBaseService<Tag>, TagService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

static string GetDbPath()
{
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    var dbPath = Path.Join(path, "social.db");
    return $"Data Source={dbPath}";
}
