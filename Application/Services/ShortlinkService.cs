using Application.Contracts;
using Application.ViewModels;
using Domain.Contracts;
using Domain.Messages;

namespace Application.Services
{
    public class ShortlinkService : IShortlinkService
    {
        private IRepositoryWrapper _repository;
        private IThirdPartyIntegrationQueue _thirdPartyIntegrationQueue;

        public ShortlinkService(IRepositoryWrapper repository,
            IThirdPartyIntegrationQueue thirdPartyIntegrationQueue)
        {
            _repository = repository;
            _thirdPartyIntegrationQueue = thirdPartyIntegrationQueue;
        }

        public CreateViewModelResponse Create(CreateShortlinkViewModelRequest model)
        {
            _repository.Shortlink.Create(new Domain.Entities.Shortlink()
            {
                Url = model.Url
            });

            _thirdPartyIntegrationQueue.SendMessage(new ThirdPartyIntegration() { Url = model.Url });

            return new CreateViewModelResponse();
        }
    }
}
