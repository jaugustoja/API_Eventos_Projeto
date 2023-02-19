using Projeto_Final_WEb_3.Repository;
using Projeto_Final_Web_3.Service.Interface;
using Projeto_Final_Web_3.Service.Service;
using Projeto_Final_WEb_3.Filter;
using AutoMapper;
using System.Text;
using Projeto_Final_WEb_3;
using Projeto_Final_Web_3.Service.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using Projeto_Final_Web_3.Service.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExceçãoGeralFilter));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var chaveCripto = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(chaveCripto),
        ValidateIssuer = true,
        ValidIssuer = "APIPessoa.com",
        ValidateAudience = true,
        ValidAudience = "Projeto_Final_WEb_3.com"
    };
});
builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();
builder.Services.AddScoped<ICityEventService, CityEventService>();
builder.Services.AddScoped<IEventReservationService, EventReservationService>();
MapperConfiguration mapperConfig = new(mc =>
{
    mc.CreateMap<CityEventEntity, CityEventDto>().ReverseMap();
    mc.CreateMap<EventReservationEntity, EventReservationDto>().ReverseMap();
}
);


IMapper mapper = mapperConfig.CreateMapper();


builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
