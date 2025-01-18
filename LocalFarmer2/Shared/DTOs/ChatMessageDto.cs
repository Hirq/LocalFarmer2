using LocalFarmer2.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarmer2.Shared.DTOs
{
    public class ChatMessageDto
    {
        public string IdUserSender { get; set; }
        public string IdUserReceiver { get; set; }
        public string Message { get; set; }
    }
}
