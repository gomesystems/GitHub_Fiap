using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq
{
   public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://user:fiap@40.65.216.220:5672");
            factory.ConsumerDispatchConcurrency = 100;

            var connection = factory.CreateConnection();

           // Publish(connection, "fabricio");
            Subscribe(connection, "Carlos");
            Console.WriteLine("THE END");

        }

        //envia as menssagens 
        static void Publish(IConnection connection, string exchangeName)
        {
            using (var channel = connection.CreateModel())
            {
                channel.ConfirmSelect();

                for (int i = 0; i < 1000; i++)
                {
                    var body = Encoding.UTF8.GetBytes("Hello Rabbit");

                    channel.BasicPublish(exchange: exchangeName + i, routingKey: "", body: body);
                    channel.WaitForConfirms();
                }
            }
        }

        //recebe as menssagens 
        static void Subscribe(IConnection connection, string queueName)
        {
            int count = 0;

            var channel = connection.CreateModel();

            var consumidor = new EventingBasicConsumer(channel);

            consumidor.Received += (model, eventArg) => {
                string msg = Encoding.UTF8.GetString(eventArg.Body.Span);
                Console.WriteLine($"{count++}: recebido {msg}");

                Task.Delay(1000).Wait();

                channel.BasicAck(eventArg.DeliveryTag, false);
            };

            channel.BasicConsume(queueName, autoAck: false, consumidor);

            Console.ReadKey();
        }
    }
}
