using AppService.Dtos;
using AutoMapper;
using Domain.Entities;

namespace AppService.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProdutoDto, Produto>();
            CreateMap<FornecedorDto, Fornecedor>();
        }
    }
}
