using LocalFarmer2.Server.Services;
using LocalFarmer2.Shared.Models;
using LocalFarmer2.Shared.Utilities;
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
            dto.DateSent = DateTime.Now;
            var message = await _chatMessageService.SendMessage(dto);

            return Ok(message);
        }

        [HttpGet, Route("GetMessages")]
        public async Task<IActionResult> GetMessages(string idUserSender, string idUserReceiver)
        {
            var allMessages = await _chatMessageService.GetMessages(idUserSender, idUserReceiver);

            return Ok(allMessages);
        }

        [HttpGet, Route("GetLastMessage")]
        public async Task<IActionResult> GetLastMessage(string idUserSender, string idUserReceiver)
        {
            try
            {
                var lastMessageDto = await _chatMessageService.GetLastMessage(idUserSender, idUserReceiver);
                return Ok(lastMessageDto);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet, Route("GetLastMessages")]
        public async Task<IActionResult> GetLastMessages(string idUserSender, [FromQuery] List<string> idsUserReceiver)
        {
            var lastMessagesDto = await _chatMessageService.GetLastMessages(idUserSender, idsUserReceiver);

            return Ok(lastMessagesDto);
        }
        
        [HttpGet, Route("GetUserChats")]
        public async Task<IActionResult> GetUserChats(string idUser)
        {
            var keys = await _chatMessageService.GetChatUserKeys(idUser);
            var dto = _mapper.Map<List<ChatUserKeyDto>>(keys);

            return Ok(dto);
        }

        [HttpGet, Route("GetUnreadCountForUser")]
        public async Task<IActionResult> GetUnreadCountForUser(string idUser)
        {
            var count = await _chatMessageService.GetUnreadCountForUser(idUser);
            return Ok(count);
        }


        [HttpPost, Route("MarkConversationAsRead")]
        public async Task<IActionResult> MarkConversationAsRead(string idUserReader, string idUserOther)
        {
            await _chatMessageService.MarkConversationAsRead(idUserReader, idUserOther);
            return NoContent();
        }

    }
}
