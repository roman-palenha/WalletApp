using AutoMapper;
using WalletApp.Business.Dto;
using WalletApp.Business.Services.Interfaces;
using WalletApp.Data;
using WalletApp.Data.Entities;

namespace WalletApp.Business.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TransactionService(AppDbContext dbContext, IMapper mapper, IUserService userService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<Transaction> CreateAsync(TransactionDto transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            var recipient = await _userService.GetUserAsync(transaction.RecipientId);
            var authorizedUser = await _userService.GetUserAsync(transaction.AuthorizedUserId);

            if (recipient == null || authorizedUser == null)
                throw new InvalidOperationException(nameof(authorizedUser) + nameof(recipient));

            var result = _mapper.Map<Transaction>(transaction);
            if (result == null)
                throw new InvalidOperationException(nameof(result));

            await _dbContext.Transactions.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        public List<TransactionDto> GetTransactions(int userId)
        {
            if (userId <= 0) 
                throw new ArgumentOutOfRangeException(nameof(userId));

            var transactions = _dbContext.Transactions
                .Where(x => x.AuthorizedUserId == userId || x.RecipientId == userId)
                .TakeLast(Constants.LastTransactionsCount).ToList();

            var result = _mapper.Map<List<TransactionDto>>(transactions);

            return result;
        }
    }
}
