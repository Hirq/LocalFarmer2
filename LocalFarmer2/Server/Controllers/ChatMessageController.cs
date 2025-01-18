using LocalFarmer2.Server.Repositories.Interfaces;
using LocalFarmer2.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChatMessageService _chatMessageService;

        public ChatMessageController(IMapper mapper, IChatMessageService chatMessageService)
        {
            _mapper = mapper;
            _chatMessageService = chatMessageService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatMessageDto dto)
        {
            var message = await _chatMessageService.SendMessage(dto);

            return Ok(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages(ChatMessageDto dto)
        {
            var allMessages = await _chatMessageService.GetMessages(dto);

            return Ok(allMessages);
        }
    }
}
