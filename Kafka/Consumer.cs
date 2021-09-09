using System;
using System.Threading;
using Confluent.Kafka;

namespace Kafka
{
    public class Consumer<T>
    {
        public void Run(string topic, string groupId, Action<T> callback)
        {
            using (var consumer = new ConsumerBuilder<Ignore, T>(_getConfig(groupId)).SetValueDeserializer(new Deserializer<T>()).Build())
            {
                var cancellationTokenSource = new CancellationTokenSource();
                consumer.Subscribe(topic);

                try
                {
                    while (true)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(cancellationTokenSource.Token);
                            callback(consumeResult.Message.Value);
                        }
                        catch (ConsumeException)
                        {
                            Console.WriteLine("Erro ao tentar consumir mensagens");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }
        }

        private ConsumerConfig _getConfig(string groupId)
        {
            return new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }
    }
}
