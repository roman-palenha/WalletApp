using WalletApp.Business.Dto;
using WalletApp.Data.Entities;

namespace WalletApp.Business.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardBalance> CreateCardAsync(CardDto card);
        Task<CardDto> GetCardAsync(int userId, int cardId);
    }
}
