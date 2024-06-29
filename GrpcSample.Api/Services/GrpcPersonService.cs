using Grpc.Core;
using GrpcSample.Api.Models;
using GrpcSample.Api.Protos;

namespace GrpcSample.Api.Services
{
    public class GrpcPersonService : PersonRepository.PersonRepositoryBase
    {
        public GrpcPersonService() { }

        public override Task<PersonResponseDto> GetPerson(GetPersonRequestDto request, ServerCallContext context)
        {
            List<Person> people = new List<Person>()
            {
                new Person() {Id = 1, FirstName="Ehsan",LastName ="Lijani"},
                new Person() {Id = 2, FirstName="Ehsan2",LastName ="Lijani2"},
                new Person() {Id = 3, FirstName="Ehsa3",LastName ="Lijani3"},
            };
            var person = people.Where(x => x.Id == request.Id).FirstOrDefault();
            return Task.FromResult(new PersonResponseDto()
            {
                Age = 20,
                FirstName = person.FirstName,
                LastName = person.LastName
            });
        }
    }
}
