using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Kafka
{
    public class Dispatcher<T>
    {
        public async Task Send(string topic, T value)
        {
            using (var producer = new ProducerBuilder<Null, T>(GetConfig()).SetValueSerializer(new Serializer<T>()).Build())
            {
                try
                {
                    await producer.ProduceAsync(topic, new Message<Null, T>() { Value = value });
                    Console.WriteLine("Mensagem enviada");
                }
                catch (ProduceException<Null, T> ex)
                {
                    Console.WriteLine($"Falhou porque {ex.Message}");
                }
            }
        }

        public ProducerConfig GetConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
        }
    }
}
