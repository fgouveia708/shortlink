using Application.ViewModels;

namespace Application.Contracts
{
    public interface IShortlinkService
    {
        void Create(CreateShortlinkViewModelRequest model);
        ShorlinkViewModelResponse Get(GetShorlinkViewModelRequest model);
    }
}
