using System;
using Microsoft.AspNetCore.SignalR;

namespace Chords.Server.Model.Chords
{
    public class Chord
    {
        public Guid Id { get; set; }

        public string Payload { get; set; }

        public DateTime? TouchedOn { get; set; }
    }
}