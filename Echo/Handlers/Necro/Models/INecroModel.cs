using System;

namespace Echo.Handlers.Necro.Models
{
    public interface INecroModel
    {
        ulong Id { get; set; }
        string Username { get; set; }
        string Nickname { get; set; }
        string Game { get; set; }
        DateTime CreatedAt { get; set; }
        NecroStatus Status { get; set; }
    }
}
