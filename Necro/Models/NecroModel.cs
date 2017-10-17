using System;

namespace Necro.Models
{
    public class NecroModel
    {
        public string NecroId { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public DateTime JoinDate { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Online,
        Offline,
        DoNotDisturb,
        AFK
    }
}
