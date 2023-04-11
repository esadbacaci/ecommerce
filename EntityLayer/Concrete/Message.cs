using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string? MessageSender { get; set; }
        public string? MessageSubject { get; set; }
        public string? MessageContent { get; set; }
        public string? MessageMail { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus{ get; set; }

    }
}
