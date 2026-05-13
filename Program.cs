using echo_mate_backend.Clients;
using echo_mate_backend.Services;


var builder = WebApplication.CreateBuilder(args);

// CORS policy for allowing requests from React development server
var corsPolicyName = "AllowReactDev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddScoped<TranslationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient<EchoMateEngineHttpClient>(client => 
{
    client.BaseAddress = new Uri("http://localhost:8002");
    
});



var app = builder.Build();

app.UseRouting();

app.UseCors("AllowReactDev");

app.UseStaticFiles();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();