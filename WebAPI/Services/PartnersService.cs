using WebAPI.Interfaces;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Services;

public class PartnersService : IPartnersService
{
    private readonly IPartnersRepository _partnersRepository;

    public PartnersService(IPartnersRepository partnersRepo) 
    {
        _partnersRepository = partnersRepo;
    }
    
    public async Task<PartnersGetResponse> GetPartners()
    {
        return await _partnersRepository.GetPartners();
    }

    public async Task<PartnersGetResponse> GetEcoPartners()
    {
        var ecoPartnersResponse = await _partnersRepository.GetPartners();

        if (ecoPartnersResponse.BaseResponseCode == BaseResponseCode.Success)
            ecoPartnersResponse.Partners = ecoPartnersResponse.Partners.Where(ep => ep.IsEco).ToList();

        if (ecoPartnersResponse.Partners.Count == 0)
            ecoPartnersResponse.BaseResponseCode = BaseResponseCode.NoObjectsFound;
        
        return ecoPartnersResponse;
    }
}