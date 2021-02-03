﻿using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ResponseConsumer.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ResponseConsumer.Receivers
{
    public class RabbitMQReceiver<TObject> : IReceiver<TObject>
    {
        private readonly ReceiverOptions _options;

        public RabbitMQReceiver(IOptions<ReceiverOptions> options)
        {
            _options = options.Value;
        }
        public Func<ICollection<TObject>, bool> OnAllReceived { get; set; }
        public ReceiverOptions Options { get => _options; }

        public void ReceiveMultiple(int count = 1)
        {
            List<TObject> objects = new List<TObject>();
            ConnectionFactory factory = new ConnectionFactory() { HostName = _options.Hostname, Port = _options.Port};
            factory.UserName = _options.Username;
            factory.Password = _options.Password;
            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queue: _options.Topic,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicQos(prefetchSize: 0, prefetchCount: (ushort) count, global: false);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received from Rabbit: {0}", json);
                objects.Add(JsonSerializer.Deserialize<TObject>(json));


                if (objects.Count >= count)
                {
                    if (OnAllReceived?.Invoke(objects) == false)
                        channel.BasicAck(ea.DeliveryTag, true);
                    else
                        channel.BasicReject(ea.DeliveryTag, true);

                    objects.Clear();
                }
                
            };
            channel.BasicConsume(queue: _options.Topic,
                                    autoAck: false,
                                    consumer: consumer);
        }
    }
}