using System;
using Kafka;
using Log.DTOs;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumerLogDto = new Consumer<LogDTO>();
            consumerLogDto.Run("LOG_CREATED", typeof(Program).AssemblyQualifiedName, (l) => ShowLog(l));
        }

        public static void ShowLog(LogDTO log)
        {
            Console.WriteLine($"{log.Action} às {log.Time}");
        }
    }
}
