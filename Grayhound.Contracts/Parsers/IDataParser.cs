namespace Grayhound.Contracts.Parsers
{
    using System.Collections.Generic;

    using Grayhound.Models;

    public interface IDataParser
    {
        IEnumerable<RaceEvent> ParseDataFile(string fileName);
    }
}
