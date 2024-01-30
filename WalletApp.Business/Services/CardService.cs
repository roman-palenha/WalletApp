using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WalletApp.Business.Dto;
using WalletApp.Business.Services.Interfaces;
using WalletApp.Data;
using WalletApp.Data.Entities;

namespace WalletApp.Business.Services
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CardService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CardBalance> CreateCardAsync(CardDto card)
        {
            if (card == null) 
                throw new ArgumentNullException(nameof(card));

            if (card.Balance > Constants.MaxBalance)
                throw new InvalidOperationException();

            var user = _dbContext.Users.FirstOrDefault(u => u.Id == card.UserId);
            if(user == null)
                throw new InvalidOperationException();

            var result = _mapper.Map<CardBalance>(card);

            await _dbContext.CardBalances.AddAsync(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<CardDto> GetCardAsync(int userId, int cardId)
        {
            var card = await _dbContext.CardBalances.FirstOrDefaultAsync(x => x.Id == cardId && x.UserId == userId);
            var result = _mapper.Map<CardDto>(card);
            return result;
        }
    }
}
