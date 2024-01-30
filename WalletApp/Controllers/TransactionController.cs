using Microsoft.AspNetCore.Mvc;
using WalletApp.Business.Dto;
using WalletApp.Business.Services.Interfaces;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        [HttpGet("{userId}")]
        public IActionResult GetTransaction([FromQuery] int userId)
        {
            var transactions = _transactionService.GetTransactions(userId);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto transactionDto)
        {
            var transaction = await _transactionService.CreateAsync(transactionDto);
            return Ok(transaction);
        }
    }
}
