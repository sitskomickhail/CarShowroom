using System;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Server.Handlers.Interfaces;

namespace CarShowroom.Server.Handlers
{
    public class HandlerExecutor : IHandlerExecutor
    {
        public async Task<string> ExecuteAction(DataTransfer dataTransfer)
        {
            string result = String.Empty;
            
            try
            {
                switch (dataTransfer.Action)
                {
                    case RequestAction.Login: break;
                    case RequestAction.Logout: break;
                    case RequestAction.Register: break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in HandlerExecutor was thrown");
                throw e;
            }

            return result;
        }
    }
}