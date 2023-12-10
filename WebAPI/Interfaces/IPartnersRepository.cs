using WebAPI.Responses;

namespace WebAPI.Interfaces;

public interface IPartnersRepository
{
    Task<PartnersGetResponse> GetPartners();
}