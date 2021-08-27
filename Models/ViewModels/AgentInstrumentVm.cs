using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicDating.Models.Entities;

namespace MusicDating.Models.ViewModels {
    public class AgentInstrumentVm {
        public Agent Agent { get; set; }
        public SelectList Instruments { get; set; } 
    }
}