using System.Text.Json;
using ConsoleApp;

var person = new Person
{
    Name = "skif",
    Age = 28,
    Email = "skif@example.com"
};

var jsonString = JsonSerializer.Serialize(person);
File.WriteAllText("person.json", jsonString); 
Console.WriteLine($"Person: {jsonString}");

var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
if (deserializedPerson == null)
    throw new NullReferenceException("Person could not be deserialized");

Console.WriteLine($"Name: {deserializedPerson.Name}, " +
                  $"Age: {deserializedPerson.Age}, " +
                  $"Email: {deserializedPerson.Email}");



namespace ConsoleApp
{
    internal class Person
    {
        public string Name { get; init; } = null!;
        public int Age { get; init; }
        public string Email { get; init; } = null!;
    }
}