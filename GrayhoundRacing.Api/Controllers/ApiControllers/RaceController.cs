namespace GrayhoundRacing.Api.Controllers.ApiControllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Grayhound.Contracts.Services;
    using Grayhound.Infrastructure.Constants;
    using Grayhound.Models;
    
    public class RaceController : ApiController
    {
        private IRaceEventDataService dataProvider;
        private string dataFilePath;

        public RaceController(IRaceEventDataService dataProvider)
        {
            this.dataProvider = dataProvider;
            this.dataFilePath = HttpContext.Current.Server.MapPath(ApplicationConstants.raceXMLFilePath);
        }

        public IEnumerable<RaceEvent> Get()
        {
            return this.dataProvider.GetRaceEventsData(this.dataFilePath).ToList();
        }
    }
}
