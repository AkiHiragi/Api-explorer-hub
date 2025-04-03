using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Api списка контактов",
    });
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IStorage, InMemoryStorage>();

builder.Services.AddCors(
opt => opt.AddPolicy("CorsPolicy", policy => {
    policy.AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("http://localhost:3000");
}));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
