using Rookies_ASP.NETCoreAPI_2.Common;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.Models;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.RepositoryDtos;
using CsvHelper;
using System.Globalization;

namespace Rookies_ASP.NETCoreAPI_2.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private static List<Person> _people = new List<Person>();
        public PersonRepository()
        {
            _people = InitialData();
        }
        public int Add(Person person)
        {
            List<Person> peopleList = _people.ToList();
            peopleList.Add(person);
            if (peopleList.Count > _people.Count())
            {
                _people = peopleList;
                SavePeopleToCsv(_people);
                return ConstantsStatus.Success;
            }
            return 500;
        }

        public int Delete(Guid id)
        {
            var deletePerson = _people.FirstOrDefault(person => person.Id == id);
            if (deletePerson != null)
            {
                var peopleList = _people.ToList();
                if (peopleList.Remove(deletePerson))
                {
                    _people = peopleList;
                    SavePeopleToCsv(_people);
                    return ConstantsStatus.Success;
                }
                return ConstantsStatus.Failed;
            }
            return 500;
        }

        public List<Person> GetPeople(RepoFilterPersonDto filterPersonDto)
        {
            List<Person> resultPeople = _people;

            if (filterPersonDto == null)
                return resultPeople;

            if (!string.IsNullOrEmpty(filterPersonDto.FirstName))
                resultPeople = resultPeople
                    .Where(person => person.FirstName != null &&
                                     person.FirstName.ToLower().Contains(filterPersonDto.FirstName.ToLower()))
                    .ToList();

            if (!string.IsNullOrEmpty(filterPersonDto.LastName))
                resultPeople = resultPeople
                    .Where(person => person.LastName != null &&
                                     person.LastName.ToLower().Contains(filterPersonDto.LastName.ToLower()))
                    .ToList();

            if (!string.IsNullOrEmpty(filterPersonDto.BirthPlace))
                resultPeople = resultPeople
                    .Where(person => person.BirthPlace != null &&
                                     person.BirthPlace.ToLower().Contains(filterPersonDto.BirthPlace.ToLower()))
                    .ToList();

            if (filterPersonDto.Gender != null)
                resultPeople = resultPeople
                    .Where(person => person.Gender == filterPersonDto.Gender)
                    .ToList();

            return resultPeople;
        }

        public int Update(Guid id, Person person)
        {
            var updatePerson = _people.FirstOrDefault(person => person.Id == id);
            if (updatePerson == null)
            {
                return 500;
            }          
            updatePerson.BirthPlace = person.BirthPlace;
            updatePerson.FirstName = person.FirstName;
            updatePerson.LastName = person.LastName;
            updatePerson.DateOfBirth = person.DateOfBirth;
            updatePerson.Gender = person.Gender;
            SavePeopleToCsv(_people);
            return ConstantsStatus.Success;
        }
        private List<Person> InitialData()
        {
            try
            {
                using var reader = new StreamReader("./Data/DataApi2.csv");
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var people = csv.GetRecords<Person>().ToList();
                return people;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from CSV: {ex.Message}");
                return new List<Person>();
            }
        }
        private void SavePeopleToCsv(List<Person> peopleToSave)
        {
            try
            {
                using var writer = new StreamWriter("./Data/DataApi2.csv");
                using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(peopleToSave);
                Console.WriteLine($"Successfully saved {peopleToSave.Count()} people to CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving people to CSV: {ex.Message}");
            }
        }
    }
}
