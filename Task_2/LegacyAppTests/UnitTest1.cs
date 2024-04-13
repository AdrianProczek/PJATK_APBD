namespace LegacyAppTests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;

        public UserServiceTests()
        {
            var clientRepository = new PredictableClientRepository();
            var userCreditService = new PredictableUserCreditService();
            _userService = new UserService(clientRepository, userCreditService);
        }

        [Theory]
        [InlineData("Jan", "", "jan@example.com", "2008-04-01", 1, false)]
        [InlineData("", "Kowalski", "jan@example.com", "1990-01-01", 1, false)]
        [InlineData("Jan", "Kowalski", "not-an-email", "1999-03-07", 1, false)]
        [InlineData("Jan", "Kowalski", "jan@example.com", "2025-12-24", 1, false)]
        public void AddUser_ShouldReturnFalse_WhenValidationFails(string firstName, string lastName, string email, string dob, int clientId, bool expected)
        {
            var dateOfBirth = DateTime.Parse(dob);
            var result = _userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
            Assert.Equal(expected, result);
        }


        public class PredictableClientRepository : IClientRepository
        {
            public Client GetById(int clientId)
            {
                return new Client { Id = clientId, Type = "StandardClient" };
            }
        }

        public class PredictableUserCreditService : IUserCreditService, IDisposable
        {
            public int GetCreditLimit(string lastName, DateTime dateOfBirth)
            {
                return 1000;
            }

            public void Dispose()
            {
            }
        }
    }
}