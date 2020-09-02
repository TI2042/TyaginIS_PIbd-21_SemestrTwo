using SecuritySystemBusinessLogic.BindingModels;
using SecuritySystemBusinessLogic.Interfaces;
using SecuritySystemBusinessLogic.ViewModels;
using SecuritySystemFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecuritySystemFileImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly FileDataListSingleton source;

        public ClientLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client client = source.Clients.FirstOrDefault(rec => rec.Login == model.Login && rec.Id != model.Id);
            if (client != null)
            {
                throw new Exception("Уже есть клиент с таким логином");
            }
            if (model.Id.HasValue)
            {
                client = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client == null)
                {
                    throw new Exception("клиент не найден");
                }
            }
            else
            {
                int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
                client = new Client { Id = maxId + 1 };
                source.Clients.Add(client);
            }
            client.ClientFIO = model.ClientFIO;
            client.Login = model.Login;
            client.Password = model.Password;
        }

        public void Delete(ClientBindingModel model)
        {
            Client client = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (client != null)
            {
                source.Clients.Remove(client);
            }
            else
            {
                throw new Exception("клиент не найден");
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            return source.Clients
            .Where(
            rec => model == null
           || (rec.Id == model.Id)
           || (rec.Login == model.Login && rec.Password == model.Password))
           .Select(rec => new ClientViewModel
            {
                Id = rec.Id,
                ClientFIO = rec.ClientFIO,
                Login = rec.Login,
                Password = rec.Password
            })
            .ToList();
        }
    }
}
