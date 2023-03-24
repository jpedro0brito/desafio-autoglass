using AppService.Dtos;
using AutoMapper;
using Domain.Entities;

namespace AppService.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(p => p.DataDeValidade, x => x.MapFrom(y => y.DataDeValidade.ToShortDateString()))
                .ForMember(p => p.DataDeFabricacao, x => x.MapFrom(y => y.DataDeFabricacao.ToShortDateString()));
            CreateMap<Fornecedor, FornecedorDto>().ForMember(p => p.Cnpj, x => x.MapFrom(y => y.Cnpj.Codigo));
        }
    }
}
