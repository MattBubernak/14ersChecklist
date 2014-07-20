using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14ers_Checklist.ViewModels
{
    class ChecklistViewModel : BaseViewModel
    {
        private ChecklistViewModel _checkListViewModel;
        public ObservableCollection<MountainViewModel> mountains; 
        
        private ChecklistViewModel()
        {
            this._checkListViewModel = new ChecklistViewModel();
            populate_mountains(); 
        }

        public ChecklistViewModel getInstance()
        {
            return _checkListViewModel; 
        }

        public void populate_mountains()
        {
            //populate the mountains list from the DB 
        }
    }
}
