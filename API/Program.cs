using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Api списка контактов",
    });
});
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("SqliteStringConnection");
builder.Services.AddSingleton<IStorage>(new SqliteStorage(connectionString));

builder.Services.AddCors(
opt => opt.AddPolicy("CorsPolicy", policy => {
    policy.AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins(builder.Configuration["client"]);
}));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
