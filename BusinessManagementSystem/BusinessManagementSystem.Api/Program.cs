using AutoMapper;
using BusinessManagementSystem.Common.Attributes;
using BusinessManagementSystem.Common.Log;
using BusinessManagementSystem.Common.Sugar;
using System.Reflection;

namespace BusinessManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSqlSugarUnitSetupSetup();
            builder.Services.AddLogSetup();
            builder.Services.RegisterAssembly(["BusinessManagementSystem.Service", "BusinessManagementSystem.Core"], typeof(IocRegisterAttribute));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
