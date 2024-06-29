using System;
using AssetManagement.Models.Create;
using Bogus;

namespace AssetManagement.DataProvider
{
    public static class UserDataGenerator
    {
        private static readonly Random Random = new Random();
        private static readonly Faker Faker = new Faker();

        public static UserCreate GenerateSingleUser()
        {
            return new UserCreate
            {
                firstName = Faker.Name.FirstName(),
                lastName = Faker.Name.LastName(),
                dateOfBirth = GenerateDateOfBirth(),
                gender = Random.Next(0, 2) == 0 ? "male" : "female",
                joinedDate = GenerateJoinedDate(),
                type = "Staff"
            };
        }

        private static string GenerateDateOfBirth()
        {
            DateTime dateOfBirth;
            do
            {
                int year = Random.Next(1980, DateTime.Now.Year - 18); // Year after 1980 and ensuring age is more than 18 years
                int month = Random.Next(1, 13);
                int day = Random.Next(1, DateTime.DaysInMonth(year, month) + 1);
                dateOfBirth = new DateTime(year, month, day);
            }
            while (dateOfBirth.DayOfWeek == DayOfWeek.Saturday || dateOfBirth.DayOfWeek == DayOfWeek.Sunday);

            return dateOfBirth.ToString("MMddyyyy");
        }

        private static string GenerateJoinedDate()
        {
            DateTime joinedDate;
            do
            {
                int year = DateTime.Now.Year + Random.Next(0, 5);
                int month = Random.Next(1, 13);
                int day = Random.Next(1, DateTime.DaysInMonth(year, month) + 1);
                joinedDate = new DateTime(year, month, day);
            }
            while (joinedDate.DayOfWeek == DayOfWeek.Saturday || joinedDate.DayOfWeek == DayOfWeek.Sunday);

            return joinedDate.ToString("MMddyyyy");
        }
    }
}