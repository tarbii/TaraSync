using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaraSync
{
    interface IView
    {
        string GetPathA();
        string GetPathB();
        void UpdateUsers(List<string> users);
        void ShowMessage(string message);
        event EventHandler<EventArgs> UpdateUserList;
        event EventHandler<EventArgs> TryLogin;
    }
}
