using echo_mate_backend.Clients;
using echo_mate_backend.Services;


var builder = WebApplication.CreateBuilder(args);


// CORS policy for allowing requests from React development server
var corsPolicyName = "_allowedOrigins";
var _allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? [];
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy
            .WithOrigins(_allowedOrigins)
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

var engineBaseUrl = builder.Configuration["EngineApi:BaseUrl"];
builder.Services.AddHttpClient<EchoMateEngineHttpClient>(client => 
{
    client.BaseAddress = new Uri(engineBaseUrl);
    
});



var app = builder.Build();

app.UseRouting();


app.UseStaticFiles();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();