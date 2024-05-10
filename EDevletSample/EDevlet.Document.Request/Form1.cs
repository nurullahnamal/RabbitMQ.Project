using EDevlet.Document.Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDevlet.Document.Request
{
    public partial class Form1 : Form
    {
        IConnection connection;

        private readonly string createDocument = "create_document_queue";
        private readonly string documentCreated = "document_created_queue";
        private readonly string documentCreatedExchange = "document_created_exchange";

        IModel _channel;
        IModel channel => _channel ?? (_channel = GetChannel());
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connection == null || !connection.IsOpen)
                connection = GetConnection();

            btnCreateDocument.Enabled = true;

            channel.ExchangeDeclare(documentCreatedExchange, "direct");

            channel.QueueDeclare(createDocument, false, false, false);
            channel.QueueBind(createDocument, documentCreatedExchange, createDocument);

            channel.QueueDeclare(documentCreated, false, false, false);
            channel.QueueBind(documentCreated, documentCreatedExchange, documentCreated);




            AddLog("Connection is open Now");

        }

        private void btnCreateDocument_Click(object sender, EventArgs e)
        {
            var model = new CreateDocumentModel()
            {
                UserId = 1,
                DocumentType = DocumentType.Pdf
            };

            WriteToQueue(createDocument, model);

            var consumerEvent =new   EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var modelStr = JsonConvert.DeserializeObject<CreateDocumentModel>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                AddLog($"Receiver Data url:{modelStr.Url}");

                
            };

            channel.BasicConsume(documentCreated, true, consumerEvent);
        }


        private void WriteToQueue(string queueName, CreateDocumentModel model)
        {
            var messageArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            channel.BasicPublish(documentCreatedExchange, queueName, null, messageArray);
            AddLog("Message Published");
        }

        private IModel GetChannel()
        {
            return connection.CreateModel();
        }


        private IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(txtConnectionString.Text)
            };
            return connectionFactory.CreateConnection();
        }

        private void AddLog(string logStr)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => { AddLog(logStr); }));
                return;
            }
            logStr = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logStr}";

            txtLog.AppendText($"{logStr}\n");

            txtLog.SelectionStart = txtConnectionString.Text.Length;
            txtLog.ScrollToCaret();
        }
    }
}
