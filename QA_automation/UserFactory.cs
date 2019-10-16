namespace HomeWork2
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            return new RegistrationUser
            {
                FirstName = "QA",
                LastName = "Tester",
                Gender = "male",
                Password = "selenium@123",
                Date = "3",
                Month = "3",
                Year = "1989",
                Address = "QA testing co.",
                City = "Sofia",
                State = "Alaska",
                PostCode = "12345",
                Phone = "456789",
                Alias = "Home sweet home!"
            };
        }
    }
}
