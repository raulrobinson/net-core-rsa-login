var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    string[] methods = { "GET", "POST", "PUT", "DELETE" };
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().WithMethods(methods).AllowCredentials());

});

builder.Services.AddControllers();
builder.Services.AddScoped<Interfaces.IRSAHelper, Helpers.RSAHelper>();
builder.Services.AddScoped<Interfaces.IAESHelper, Helpers.AESHelper>();

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

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
