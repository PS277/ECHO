using System;

namespace Echo.Handlers.Necro.Models
{
    public class NecroModel : INecroModel
    {
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get => Nickname ?? Username; set => Nickname = value; }
        public string Game { get => "Sitting Ducks"; set => Game = value; }
        public DateTime CreatedAt { get; set; }
        public NecroStatus Status { get => NecroStatus.Offline; set => Status = value; }
    }
}
