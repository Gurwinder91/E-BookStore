using AutoMapper;
using EBookStore.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBookStore.Application.Test.Infrastructure
{
    class AutoMapperFactory
    {
        public static IMapper Create()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
