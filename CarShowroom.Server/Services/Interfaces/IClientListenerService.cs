using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Server.Services.Interfaces
{
    public interface IClientListenerService
    {
        Task ListenClientConnections();
    }
}