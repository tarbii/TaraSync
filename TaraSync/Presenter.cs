using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaraSync.Model;

namespace TaraSync
{
    class Presenter
    {
        private IView view;
        private Synchronizer model;
        public Presenter(IView newView)
        {
            view = newView;
            model = new Model();
            view.UpdateUserList += new EventHandler<EventArgs>(UpdateUsers);
            view.TryLogin += new EventHandler<EventArgs>(Login);
        }
        private void UpdateUsers(object sender, EventArgs e)
        {
            view.UpdateUsers(model.Users);
        }
        private void Login(object sender, EventArgs e)
        {
            string loginResult = model.TryToLogin(view.GetPathA(), view.GetPathB());
            view.ShowMessage(loginResult);
        }
    }
}
