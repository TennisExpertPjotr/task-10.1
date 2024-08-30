using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    public interface IAddClient
    {
        void AddClient(ObservableCollection<ClientForManager> clients, ClientForManager client);
    }
}
