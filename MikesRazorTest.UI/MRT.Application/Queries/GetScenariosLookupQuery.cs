namespace Genus.OpsPortal.Business.Queries;

using MediatR;
using MRT.Application.Models;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

public record GetScenariosLookupQuery : IRequest<GetScenariosLookupQuery.Response>
{
    public class Handler : IRequestHandler<GetScenariosLookupQuery, Response>
    {

        public Handler()
        {

        }

        public async Task<Response> Handle(GetScenariosLookupQuery request, CancellationToken cancellationToken)
        {
            return new Response(await BuildData<Scenario>());
        }

        private static Task<List<Scenario>> BuildData<TEntity>()
        {
            // This should be in a blob storage...but it's not so lets go old school
            XDocument xDocument = XDocument.Load("App_Data\\Developer Technical ExerciseData.xml");
            List<Scenario> scenarios = xDocument.Descendants("Scenario").Select
                (p => new Scenario()
                {
                    ScenarioID = Convert.ToInt32(p.Element("ScenarioID")?.Value),
                    ScenarioName = p.Element("Name")?.Value,
                    Surname = p.Element("Surname")?.Value,
                    Forename = p.Element("Forename")?.Value,
                    UserID = Guid.TryParse(p.Element("UserID")?.Value, out var userId) ? userId : (Guid?)null,
                    SampleDate = DateTime.TryParse(p.Element("SampleDate")?.Value, out var sampleDate) ? sampleDate : (DateTime?)null,
                    CreationDate = DateTime.TryParse(p.Element("CreationDate")?.Value, out var creationDate) ? creationDate : (DateTime?)null,
                    NumMonths = Convert.ToInt32(p.Element("NumMonths")?.Value),
                    MarketID = Convert.ToInt32(p.Element("MarketID")?.Value),
                    NetworkLayerID = Convert.ToInt32(p.Element("NetworkLayerID")?.Value),
                }).ToList();

            return Task.FromResult(scenarios);

        }
    }
    public record Response(List<Scenario> Data);


}
