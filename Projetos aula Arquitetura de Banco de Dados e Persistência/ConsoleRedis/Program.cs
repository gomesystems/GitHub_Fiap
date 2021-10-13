using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace ConsoleRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "localhost";
            var redis = ConnectionMultiplexer.Connect(connectionString);
            var db = redis.GetDatabase();

            var pub = redis.GetSubscriber();

            pub.Subscribe("perguntas").OnMessage(m => {
                Console.WriteLine(m.Message);
                string texto = m.Message;
                var linhas = texto.Split(':');
                db.HashSet(linhas[0], "Grupo 3", "ñ sei");
            });


            Console.ReadLine();

        }
    }
}
