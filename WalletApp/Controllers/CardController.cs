using Microsoft.AspNetCore.Mvc;
using WalletApp.Business.Dto;
using WalletApp.Business.Services.Interfaces;

namespace WalletApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCard([FromBody] CardDto cardDto)
    {
        var card = await _cardService.CreateCardAsync(cardDto);
        return Ok(card);
    }


    [HttpGet("balance/{userId}/{cardId}")]
    public async Task<ActionResult> GetCardBalance([FromQuery] int userId, [FromQuery] int cardId)
    {
        var card = await _cardService.GetCardAsync(userId, cardId);
        return Ok(card);
    }
}