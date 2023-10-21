using IlustraApp.Core.Entities;
using IlustraApp.Infrastructure.Data;
using IlustraApp.Infrastructure.Repository.Interfaces;

namespace IlustraApp.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IlustraContext Context;
        public PersonRepository(IlustraContext context)
        {
            Context = context;
        }
        public async Task CreatePerson(Person person)
        {
            await Context.Person.AddAsync(person);
        }
    }
}
