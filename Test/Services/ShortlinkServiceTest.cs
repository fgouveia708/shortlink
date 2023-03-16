using Application.Services;
using Application.ViewModels;
using Domain.Contracts;
using Domain.Entities;
using Moq;
using System;
using System.Linq.Expressions;
using Test.Fakes;
using Xunit;
using Xunit.Priority;

namespace Test.Services
{
    public class ShortlinkServiceTest
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock;
        private readonly Mock<IThirdPartyIntegrationQueue> _thirdPartyIntegrationQueueMock;
        private readonly ShortlinkService _shortlinkService;

        public ShortlinkServiceTest()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            _thirdPartyIntegrationQueueMock = new Mock<IThirdPartyIntegrationQueue>();
            _shortlinkService = new ShortlinkService(_repositoryWrapperMock.Object, _thirdPartyIntegrationQueueMock.Object);
        }

        [Fact(DisplayName = "When call create shortlink"), Priority(1)]
        [Trait("Service", "Shortlink")]
        public void When_Call_Create_Shortlink()
        {
            _repositoryWrapperMock.Setup(x => x.Shortlink.Create(It.IsAny<Shortlink>())).Returns(ShortlinkRepositoryFake.Shortlink);

            var shortlink = _shortlinkService.Create(new CreateShortlinkViewModelRequest()
            {
                Url = "http://www.google.com"
            });

            Assert.NotNull(shortlink.ShortUrl);
        }

        [Fact(DisplayName = "When call get shortlink"), Priority(2)]
        [Trait("Service", "Shortlink")]
        public void When_Call_Get_Shortlink()
        {
            _repositoryWrapperMock.Setup(x => x.Shortlink.FindByCondition(It.IsAny<Expression<Func<Shortlink, bool>>>())).Returns(ShortlinkRepositoryFake.Shortlinks);

            var shortlink = _shortlinkService.Get(new GetShorlinkViewModelRequest()
            {
                ShortUrl = "http://chr.dc/9op3"
            });

            Assert.NotNull(shortlink.Url);
        }

        [Fact(DisplayName = "When call get shortlink with shortlink invalid"), Priority(3)]
        [Trait("Service", "Shortlink")]
        public void When_Call_Get_Shortlink_With_Shortlink_Invalid()
        {
            _repositoryWrapperMock.Setup(x => x.Shortlink.FindByCondition(It.IsAny<Expression<Func<Shortlink, bool>>>()));

            var shortlink = _shortlinkService.Get(new GetShorlinkViewModelRequest()
            {
                ShortUrl = "http://chr.dc/9o32"
            });

            Assert.Null(shortlink);
        }
    }
}
