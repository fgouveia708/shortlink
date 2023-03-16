using Application.Contracts;
using Application.ViewModels;
using Domain.Contracts;
using Domain.Messages;
using System;
using System.Linq;

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

        public void Create(CreateShortlinkViewModelRequest model)
        {
            var existShortUrl = true;
            var shortUrl = string.Empty;

            while (existShortUrl)
            {
                shortUrl = $"http://chr.dc/{RandomCode(5).ToLower()}";
                existShortUrl = this.ExistShortUrl(new GetShorlinkViewModelRequest() { ShortUrl = shortUrl });
            }

            _repository.Shortlink.Create(new Domain.Entities.Shortlink()
            {
                Url = model.Url,
                ShortUrl = shortUrl
            });

            _thirdPartyIntegrationQueue.SendMessage(new ThirdPartyIntegration()
            {
                Url = model.Url,
                ShortUrl = shortUrl
            });
        }
        public ShorlinkViewModelResponse Get(GetShorlinkViewModelRequest model)
        {
            var shortlink = _repository.Shortlink.FindByCondition(c => c.ShortUrl == model.ShortUrl).FirstOrDefault();
            if (shortlink != null)
            {
                shortlink.Hint++;
                _repository.Shortlink.Update(shortlink);
                return new ShorlinkViewModelResponse() { Url = shortlink.Url };
            }
            return null;
        }
        private bool ExistShortUrl(GetShorlinkViewModelRequest model)
        {
            return _repository.Shortlink.FindByCondition(c => c.ShortUrl == model.ShortUrl).Any();
        }

        #region Helpers
        public static string RandomCode(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        #endregion
    }
}
