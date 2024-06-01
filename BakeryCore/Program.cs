using BakeryCore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BakeryContext>(options =>
    options.UseSqlite("Data Source=bakery_db.sqllite"));

builder.Services.AddCors(o => { o.AddPolicy("myCors", p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("myCors");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
