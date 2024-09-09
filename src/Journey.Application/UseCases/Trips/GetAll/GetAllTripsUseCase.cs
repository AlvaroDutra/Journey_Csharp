using Journey.Communication.Responses;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetAll;

public class GetAllTripsUseCase
{
    public ResponseTripsJson Execute()
    {

        var dbContext = new JourneyDbContext();
        var trips = dbContext.Trips.ToList();


        return new ResponseTripsJson
        {
            Trips = trips.Select(t => new ResponseShortTripJson
            {
                Id = t.Id,
                EndDate = t.EndDate,
                Name = t.Name,
                StartDate = t.StartDate
            }).ToList()
        };
    }
}
