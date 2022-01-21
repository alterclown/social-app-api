using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialAppApi.Database.SocialAppContext;
using SocialAppApi.Entities.AppSettings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//var appSettingsSection = Configuration.GetSection("AppSettings");
//builder.Services.Configure<AppSettings>(appSettingsSection);

//var appSettings = appSettingsSection.Get<AppSettings>();
//var key = Encoding.ASCII.GetBytes(appSettings.Key);

//builder.Services.AddAuthentication(a => {
//    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).
//AddJwtBearer(j => {
//    j.RequireHttpsMetadata = false;
//    j.SaveToken = true;
//    j.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };

//});


//builder.Services.AddDbContext<SocialAppContext>(options =>
//{
//    options.UseSqlServer(Configuration.GetConnectionString("OptocoderHrmContext"));
//});


builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//Register your Services Here

//builder.Services.AddScoped<ICompanyService, CompanyService>();
//builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
