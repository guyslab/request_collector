namespace ResponseConsumer.Options
{
    public class ReceiverOptions
    {
        public int ProcessInParallelCount { get; set; }

        public string Topic { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }
    }
}
