using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureApp.Models
{
    public class ChatMessageModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
