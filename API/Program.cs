using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using API.Data;
using API.Interfaces;
using API.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Newtonsoft.Json
builder.Services.AddControllers().AddNewtonsoftJson(options => 
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
 });
// Add JsonSerializerOptions
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Configure DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddHttpsRedirection(options =>
// {
//     options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//     options.HttpsPort = 1902; // Replace with your HTTPS port
// });

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Register services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure Kestrel to listen on both HTTP and HTTPS, and use HTTPS with the correct certificate
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
