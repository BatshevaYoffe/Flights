using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.VM.Command
{
    public class SelectDatesCommand:ICommand 
    {
        public event Action read;


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {

            return true;
        }

        public void Execute(object parameter) => read();
    }
}
