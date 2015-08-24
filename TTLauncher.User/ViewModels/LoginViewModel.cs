using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TTLauncher.User.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            //this.LoginCommand = new DelegateCommand(this.)
        }

        public ICommand LoginCommand { get; private set; }

        private void Login()
        {

        }
    }
}
