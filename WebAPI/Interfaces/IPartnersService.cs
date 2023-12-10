using WebAPI.Responses;

namespace WebAPI.Interfaces;

public interface IPartnersService
{
    Task<PartnersGetResponse> GetPartners();
    Task<PartnersGetResponse> GetEcoPartners();
}