﻿namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;
    public interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; }
    }
}
