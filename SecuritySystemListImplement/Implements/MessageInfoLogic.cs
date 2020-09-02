using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecuritySystemListImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly DataListSingleton source;

        public MessageInfoLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            MessageInfo messageInfo = new MessageInfo();
            foreach (var message in source.MessageInfoes)
                if (message.MessageId == model.MessageId)
                    throw new Exception("Уже есть письмо с таким идентификатором");
            int? clientId = null;
            foreach (var client in source.Clients)
                if (client.Login == model.FromMailAddress)
                    clientId = client.Id;
            messageInfo.Body = model.Body;
            messageInfo.ClientId = clientId;
            messageInfo.DateDelivery = model.DateDelivery;
            messageInfo.SenderName = model.FromMailAddress;
            messageInfo.Subject = model.Subject;
            source.MessageInfoes.Add(messageInfo);
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();
            foreach (var message in source.MessageInfoes)
            {
                if (model != null)
                {
                    if (message.ClientId.HasValue && message.ClientId.Value == model.ClientId.Value)
                    {
                        result.Add(new MessageInfoViewModel()
                        {
                            MessageId = message.MessageId,
                            Body = message.Body,
                            SenderName = message.SenderName,
                            DateDelivery = message.DateDelivery,
                            Subject = message.Subject
                        });
                        break;
                    }
                    continue;
                }
                result.Add(new MessageInfoViewModel()
                {
                    MessageId = message.MessageId,
                    Body = message.Body,
                    SenderName = message.SenderName,
                    DateDelivery = message.DateDelivery,
                    Subject = message.Subject
                });
            }
            return result;
        }
    }
}
