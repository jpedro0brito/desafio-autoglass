using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AutoMapper
{
    public class ConfigMapper
    {
        public readonly IMapper Mapper;
        public ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToDomainMappingProfile());
            });
            Mapper = config.CreateMapper();
        }
    }
}
