using Microsoft.EntityFrameworkCore;
using W5iChamados.Data;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (conexão com SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// opcional (evita warning de HTTPS por enquanto)
// app.UseHttpsRedirection();


// 🔹 Endpoint de teste do banco
app.MapGet("/teste-db", (AppDbContext db) =>
{
    var setores = db.Setores.ToList();
    return Results.Ok(setores);
});

app.Run();