using WalletApp.Business.Dto;
using WalletApp.Data.Entities;

namespace WalletApp.Business.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> CreateAsync(TransactionDto transaction);
        List<TransactionDto> GetTransactions(int userId);
    }
}
