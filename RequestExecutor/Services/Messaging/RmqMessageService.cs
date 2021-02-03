using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RequestExecutor.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestExecutor.Services
{
    public class RmqMessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly MessageOptions _options;
        private readonly ILogger _logger;
        public RmqMessageService(
            IOptions<MessageOptions> opt, 
            ILogger<RmqMessageService> logger)
        {
            _logger = logger;
            _options = opt.Value;
            if (_options == null || string.IsNullOrEmpty(_options.Topic))
                throw new ArgumentNullException("empty message options or topic");

            _logger.LogInformation("About to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = _options.Hostname ?? "rabbitmq", Port = _options.Port == 0 ? 5672 : _options.Port };
            _factory.UserName = _options.Username;
            _factory.Password = _options.Password;
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: _options.Topic,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }
        public bool Enqueue(string messageString)
        {
            var body = Encoding.UTF8.GetBytes(messageString);
            _channel.BasicPublish(exchange: "",
                                routingKey: _options.Topic,
                                basicProperties: null,
                                body: body);
            _logger.LogTrace(" [x] Published {0} to RabbitMQ", messageString);
            return true;
        }
    }
}
