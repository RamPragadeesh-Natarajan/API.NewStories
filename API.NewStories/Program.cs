using API.NewStories.MIddleware;
using API.NewStories.Repository;
using API.NewStories.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<INewStoriesRepository, NewStoriesRepository>();
// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.Run();
