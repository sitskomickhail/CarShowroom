using System.Threading.Tasks;

namespace CarShowroom.Server.Handlers.Base
{
    public interface IHandler
    {
        Task<string> ExecuteAction(string jsonModel);
    }
}