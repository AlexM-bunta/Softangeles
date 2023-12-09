using Microsoft.VisualBasic.CompilerServices;
using WebAPI.Contracts;
using WebAPI.Extensions;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Models.Views;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankRepository;
    private readonly ISessionsRepository _sessionsRepository;

    public BankAccountService(IBankAccountRepository bankRepo, ISessionsRepository sessionsRepo)
    {
        _bankRepository = bankRepo;
        _sessionsRepository = sessionsRepo;
    }
    
    public async Task<GetBankAccountsResponse> GetBankAccountDetailsBySessionId(Guid guid)
    {
        var bankAccountResponse = new GetBankAccountsResponse()
        {
            AccountResponseCode = AccountResponseCode.Success
        };
        
        var userId = await _sessionsRepository.GetActiveUserIdBySession(guid);

        var bankAccountList = await _bankRepository.GetBankAccountsByUser(userId);

        if (bankAccountList == null || bankAccountList.Count == 0)
            bankAccountResponse.AccountResponseCode = AccountResponseCode.NoObjectsFound;
        else
        {
            var bankAccountTypesList = await _bankRepository.GetBankAccountTypes();

            bankAccountResponse.BankAccountDetailsList = new List<BankAccountDetails>();
        
            await Task.Run(() =>
            {
                foreach (var account in bankAccountList)
                {
                    var typeString = bankAccountTypesList.FirstOrDefault(bat => bat.Id == account.TypeId).Name;
                    bankAccountResponse.BankAccountDetailsList.Add(BankAccountExtensions.ToView(account, typeString));
                }
            });
        }
        
        return bankAccountResponse;
    }

    public async Task<AccountAddResponseCode> AddAccount(AccountAddContract accountContract)
    {
        var typeList = await _bankRepository.GetBankAccountTypes();

        var type = typeList.FirstOrDefault(t => t.Name.Equals(accountContract.Type));

        if (type == null)
            return AccountAddResponseCode.TypeNotFound;
        
        var account = new BankAccount()
        {
            TypeId = type.Id,
            Balance = 0,
            IBAN = Utils.GenerateIBAN()
        };
        
        var response = await _bankRepository.AddAccount(account);

        return response;
    }
}