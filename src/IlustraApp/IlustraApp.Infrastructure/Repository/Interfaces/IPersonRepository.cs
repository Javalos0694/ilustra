using IlustraApp.Core.Entities;

namespace IlustraApp.Infrastructure.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
    }
}
