using AppService.AppServices;
using AppService.AutoMapper;
using AppService.Interfaces;
using DataCore.Context;
using DataCore.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ConfigMapper().Mapper);
            services.AddDbContext<GestaoProdutosContext>(options => options.UseSqlite(configuration.GetConnectionString(GestaoProdutosContext.GestaoProdutosDB)));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
        }
    }
}
