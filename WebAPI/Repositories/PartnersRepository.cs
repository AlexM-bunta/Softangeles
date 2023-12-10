using System.Data.Entity;
using WebAPI.EntityFramework.Context;
using WebAPI.Interfaces;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Repositories;

public class PartnersRepository : IPartnersRepository
{
    private readonly ApplicationDbContext _context;

    public PartnersRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<PartnersGetResponse> GetPartners()
    {
        var response = new PartnersGetResponse()
        {
            BaseResponseCode = BaseResponseCode.Success
        };
        
        var partners = await _context.Partners.ToListAsync();

        if (partners == null || partners.Count == 0)
            response.BaseResponseCode = BaseResponseCode.NoObjectsFound;
        else
            response.Partners = partners;

        return response;
    }
}