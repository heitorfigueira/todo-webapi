using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.WebApi.Tests.Unit.Mocks
{
    public static class MapperMocks
    {
        public static Mock<IMapper> Mock()
        {
            return new Mock<IMapper>();
        }

        public static Mock<IMapper> SetupMapAnyReturns<TSource, TDestination>
            (this Mock<IMapper> mock, TDestination mappedObject)
        {
            mock.Setup(mapper =>
                mapper.Map<TDestination>(It.IsAny<TSource>()))
                .Returns(mappedObject);

            mock.Setup(mapper =>
                mapper.Map<TSource, TDestination>(It.IsAny<TSource>()))
                .Returns(mappedObject);

            return mock;
        }

        public static Mock<IMapper> SetupMapBetween<TSource, TDestination>
            (this Mock<IMapper> mock, TSource unmappedObject, TDestination mappedObject)
        {
            mock.Setup(mapper =>
                mapper.Map<TDestination>(unmappedObject))
                .Returns(mappedObject);

            mock.Setup(mapper =>
                mapper.Map<TSource, TDestination>(unmappedObject))
                .Returns(mappedObject);

            return mock;
        }
    }
}
