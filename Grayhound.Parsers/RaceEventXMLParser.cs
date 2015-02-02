namespace HoundRace.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Grayhound.Contracts.Parsers;
    using Grayhound.Models;
    
    public class RaceEventXMLParser : IDataParser
    {
        // TODO: Extract constants

        public IEnumerable<RaceEvent> ParseDataFile(string fileName)
        {
            var result = new List<RaceEvent>();
            var root = XDocument.Load(fileName);
            var raceEvents = root.Descendants("RaceEvent");

            foreach (var xmlRaceEvent in raceEvents)
            {
                var raceEvent = this.ParseRaceEvent(xmlRaceEvent);
                result.Add(raceEvent);
            }

            return result;
        }

        private RaceEvent ParseRaceEvent(XElement xmlRace)
        {
            var raceEvent = new RaceEvent();

            raceEvent.Entries = new List<Entry>();
            raceEvent.Id = this.GetIntAttributeByName(xmlRace, "ID");
            raceEvent.EventNumber = this.GetIntAttributeByName(xmlRace, "EventNumber");
            raceEvent.Distance = this.GetIntAttributeByName(xmlRace, "Distance");
            raceEvent.EventTime = this.GetDateTimeAttributeByName(xmlRace, "EventTime");
            raceEvent.FinishTime = this.GetDateTimeAttributeByName(xmlRace, "FinishTime");
            raceEvent.Name = this.GetStringAttributeByName(xmlRace, "Name");

            var entries = xmlRace.Descendants("Entry");
            foreach (var xmlEntry in entries)
            {
                var entry = this.ParseEntry(xmlEntry);
                raceEvent.Entries.Add(entry);
            }

            return raceEvent;
        }

        private Entry ParseEntry(XElement xmlEntry)
        {
            var entry = new Entry();

            entry.Id = this.GetIntAttributeByName(xmlEntry, "ID");
            entry.Name = this.GetStringAttributeByName(xmlEntry, "Name");
            entry.OddsDecimal = this.GetDecimalAttributeByName(xmlEntry, "OddsDecimal");

            return entry;
        }

        private decimal GetDecimalAttributeByName(XElement element, string name)
        {
            var value = this.GetAttributeValue(element, name);
            return decimal.Parse(value);
        }

        private int GetIntAttributeByName(XElement element, string name)
        {
            var value = this.GetAttributeValue(element, name);
            return int.Parse(value);
        }

        private DateTime GetDateTimeAttributeByName(XElement element, string name)
        {
            var value = this.GetAttributeValue(element, name);
            return DateTime.Parse(value);
        }

        private string GetStringAttributeByName(XElement element, string name)
        {
            var value = this.GetAttributeValue(element, name);
            return value;
        }

        private string GetAttributeValue(XElement element, string name)
        {
            var value = element.Attribute(name).Value;

            if (value == null)
            {
                throw new NullReferenceException(name + " value cannot be null!");
            }

            return value;
        }
    }
}
