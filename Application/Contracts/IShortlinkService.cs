using Application.ViewModels;

namespace Application.Contracts
{
    public interface IShortlinkService
    {
        CreateViewModelResponse Create(CreateShortlinkViewModelRequest model);
    }
}
