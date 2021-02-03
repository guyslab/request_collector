using System;

namespace RequestGenerator.Factories
{
    public class RequestModelFactory : IFactory<RequestModel>
    {
        private const short MaxPriority = 5;
        private readonly Random _random;
        private static string[] Urls = new string[5]
        {
            "https://api.exchangeratesapi.io/latest",
            "https://www.boredapi.com/api/activity",
            "https://api.countapi.xyz/hit/namespace/key",
            "https://api.ipify.org/?format=json",
            "http://api.icndb.com/jokes/random?firstName=John&lastName=Doe"
        };

        public RequestModelFactory()
        {
            _random = new Random();
        }

        public RequestModel Create()
        {
            string url = Urls[_random.Next(0, Urls.Length)];
            byte priority = (byte) _random.Next(1, MaxPriority + 1);

            return new RequestModel
            {
                Url = url,
                Priority = priority
            };
        }
    }
}
