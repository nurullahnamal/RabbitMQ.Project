using EDevlet.Document.Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EDevlet.Document.Creator
{
    public class Program
    {

        static IConnection connection;

        private static readonly string createDocument = "create_document_queue";
        private static readonly string documentCreated = "document_created_queue";
        private static readonly string documentCreatedExchange = "document_created_exchange";

        static IModel _channel;
        static IModel channel => _channel ?? (_channel = GetChannel());


        static void Main(string[] args)
        {

            connection = GetConnection();

            channel.ExchangeDeclare(documentCreatedExchange, "direct");

            channel.QueueDeclare(createDocument, false, false, false);
            channel.QueueBind(createDocument, documentCreatedExchange, createDocument);

            channel.QueueDeclare(documentCreated, false, false, false);
            channel.QueueBind(documentCreated, documentCreatedExchange, documentCreated);

            var consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var modelJson = Encoding.UTF8.GetString(ea.Body.ToArray());
                var model = JsonConvert.DeserializeObject<CreateDocumentModel>(modelJson);
                Console.WriteLine($"Receiver Data : {modelJson}");

                //create doc.
                Task.Delay(5000).Wait();


                model.Url = "http://www.turkiye.gov.tr/docs/x.pdf";
                WriteToQueue(documentCreated, model);
            };

            channel.BasicConsume(createDocument, true, consumerEvent);

            Console.WriteLine($"{documentCreatedExchange} listinig");
            Console.ReadLine();
        }



        private static void WriteToQueue(string queueName, CreateDocumentModel model)
        {
            var messageArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            channel.BasicPublish(documentCreatedExchange, queueName, null, messageArray);
            Console.WriteLine("Message Published");
        }

        private static IModel GetChannel()
        {
            return connection.CreateModel();
        }


        private static IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            return connectionFactory.CreateConnection();
        }
    }
}
