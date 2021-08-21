using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace Kafka
{
    class Program
    {
        static void Main(string[] args)
        {
            var configProducer = new ProducerConfig()
            {
                BootstrapServers = "dory-01.srvs.cloudkafka.com:9094,dory-02.srvs.cloudkafka.com:9094,dory-03.srvs.cloudkafka.com:9094",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.ScramSha256,
                SaslUsername = "mus9pr80",
                SaslPassword = "ybU2YSWcDe-FmNIHbuNSxX30Plk0Boos"
            };
          
            var configConsumer = new ConsumerConfig()
            {
                BootstrapServers = "dory-01.srvs.cloudkafka.com:9094,dory-02.srvs.cloudkafka.com:9094,dory-03.srvs.cloudkafka.com:9094",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.ScramSha256,
                SaslUsername = "mus9pr80",
                SaslPassword = "ybU2YSWcDe-FmNIHbuNSxX30Plk0Boos",
                GroupId = "mus9pr80-consumer",
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            
            string topic = "mus9pr80-default";

            KafkaConsumer(configConsumer, topic);
            //KafkaProducer(configProducer, topic);

            Console.WriteLine("Conectando!");
        }

        static void KafkaConsumer(ConsumerConfig config, string topic)
        {
            int count = 0;

            var builder = new ConsumerBuilder<string, string>(config);

            using (var consumer = builder.Build())
            {
                consumer.Subscribe(topic);

                while (true)
                {
                    var result = consumer.Consume(TimeSpan.FromSeconds(1));

                    if (result != null)
                    {
                        string texto = result.Message.Value;

                        Console.WriteLine($"{count++}: recebido {texto}");
                    }
                }
            }
        }


        static async Task KafkaProducer(ProducerConfig config, string topic)
        {
            string nome = "Carlos";

            var builder = new ProducerBuilder<string, string>(config);

            using (var producer = builder.Build())
            {
                for (int i = 0; i < 10; i++)
                {
                    var message = new Message<string, string>
                    {
                        Key = nome,
                        Value = "Mensagem de " + nome + " : " + i
                    };

                    await producer.ProduceAsync(topic, message);
                }
            }

        }
    }
}
