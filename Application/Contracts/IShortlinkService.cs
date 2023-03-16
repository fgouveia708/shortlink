using Application.ViewModels;

namespace Application.Contracts
{
    public interface IShortlinkService
    {
        CreateShortlinkViewModelResponse Create(CreateShortlinkViewModelRequest model);
        ShorlinkViewModelResponse Get(GetShorlinkViewModelRequest model);
    }
}
