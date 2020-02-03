using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace zajecia10
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");

            List<Person> people = lines.Select(x =>
            {
                string[] data = x.Split(",");
                return new Person(Convert.ToInt32(data[0]), data[1], data[2], data[3]);
            }).ToList();

            var sortedPeople = people.OrderBy(x => x.LastName)
                .ThenBy(x => x.Name);

            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach (var item in sortedPeople)
                {
                    writer.WriteLine($"[{item.Id}] {item.Name} {item.LastName}: {item.Phone}");
                }
            }
        }
    }
}