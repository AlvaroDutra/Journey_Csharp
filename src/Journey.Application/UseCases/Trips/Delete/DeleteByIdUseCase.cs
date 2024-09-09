using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete;

public class DeleteByIdUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new JourneyDbContext();

        var trip = dbContext.Trips.Include(t => t.Activities).FirstOrDefault(t => t.Id == id);

        if (trip == null)
        {
            throw new NotFoundException(ResourceErrorMenssages.TRIP_NOT_FOUND);
        }
        dbContext.Trips.Remove(trip);
        dbContext.SaveChanges();
    }
}
