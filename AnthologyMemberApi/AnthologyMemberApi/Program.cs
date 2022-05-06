using AnthologyMemberApi.Models;
using AnthologyMemberApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MemberStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MemberDBConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository<MemberDemographic>, MemberRepository>();
builder.Services.AddCors(p => p.AddPolicy("devApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("devApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
