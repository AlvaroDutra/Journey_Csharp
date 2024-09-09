using Journey.Communication.Responses;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;


namespace Journey.Application.UseCases.Trips.GetById;

public class GetByIdUseCase
{
    public ResponseTripJson Execute(Guid id) 
    {
        var dbContext = new JourneyDbContext();

        var trip = dbContext.Trips.Include(t => t.Activities).FirstOrDefault(t => t.Id == id);

        if (trip == null) 
        {
            throw new NotFoundException(ResourceErrorMenssages.TRIP_NOT_FOUND);
        }

        return new ResponseTripJson
        {
            Id = trip.Id,
            Name = trip.Name,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            Activities = trip.Activities.Select(a => new ResponseActivityJson 
            {
                Id = a.Id,
                Name = a.Name,
                Date = a.Date,
                Status = (Communication.Enums.ActivityStatus)a.Status
            }).ToList()
        };
    }
}
