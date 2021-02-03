using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestExecutor.Options
{
    public class MessageOptions
    {
        public string Topic { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }
    }
}
