using AppService.Dtos;
using AutoMapper;
using Domain.Entities;

namespace AppService.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Produto, ProdutoDto>();
            CreateMap<Fornecedor, FornecedorDto>();
        }
    }
}
