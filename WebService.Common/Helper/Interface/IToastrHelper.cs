using Microsoft.AspNetCore.Mvc;
using WebService.Common.Helper.Model.Toastr;

namespace WebService.Common.Helper.Interface
{
    public interface IToastrHelper
    {
        void SendMessage(Controller controller, string title, string message, MessageType messageType);
        void AddMessage(string title, string message, MessageType messageType);
        void Send(Controller controller);
    }
}
