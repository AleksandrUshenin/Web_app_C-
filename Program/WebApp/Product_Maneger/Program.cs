using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Product_Maneger.Repositories;
using Product_Maneger.Repositories.Interface;

namespace Product_Maneger
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

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> add config

            builder.Services.AddAutoMapper(typeof(MapperProfiles));
            builder.Services.AddMemoryCache(x => x.TrackStatistics = true);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder => {
                contaierBuilder.RegisterType<ProductManager>().As<IProductManager>();
            });
            builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder => {
                contaierBuilder.RegisterType<CategoryManager>().As<ICategoryManager>();
            });

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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
        }
    }
}
