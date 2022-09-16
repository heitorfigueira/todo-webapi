using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Tests.Domain.Mocks
{
    public static class MapperMocks
    {
        public static Mock<IMapper> Mock()
        {
            return new Mock<IMapper>();
        }

        public static Mock<IMapper> SetupMapBetween<TSource, TDestination>(this Mock<IMapper> mock, TDestination destinationObject)
        {
            mock.Setup(mapper => 
                mapper.Map<TSource, TDestination>(It.IsAny<TSource>()))
                .Returns(destinationObject);

            return mock;
        }
    }
}
