namespace Grayhound.Contracts.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using Grayhound.Models;

    public interface IRaceEventDataService
    {
        IQueryable<RaceEvent> GetRaceEventsData(string filePath);
    }
}
