namespace Grayhound.Services
{
    using System.Linq;

    using Grayhound.Contracts.Parsers;
    using Grayhound.Contracts.Services;
    using Grayhound.Models;
    
    public class RaceEventDataService : IRaceEventDataService
    {
        private IDataParser parser;
        private string filePath;

        public RaceEventDataService(IDataParser parser)
        {
            this.parser = parser;
        }

        public IQueryable<RaceEvent> GetRaceEventsData(string filePath)
        {
            return this.parser.ParseDataFile(filePath).AsQueryable<RaceEvent>();
        }
    }
}
