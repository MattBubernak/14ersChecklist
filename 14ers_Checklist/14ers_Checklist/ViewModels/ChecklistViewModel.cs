using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _14ers_Checklist.Models; 

namespace _14ers_Checklist.ViewModels
{
    class ChecklistViewModel : BaseViewModel
    {
        private ChecklistViewModel _checkListViewModel;
        public ObservableCollection<MountainViewModel> mountains; 
        
        private ChecklistViewModel()
        {
            db = App.DB; 
            populate_mountains(); 
        }

        public ChecklistViewModel getInstance()
        {
            if (_checkListViewModel == null)
            {
                this._checkListViewModel = new ChecklistViewModel(); 
            }
            return _checkListViewModel; 
        }

        public void populate_mountains()
        {
            mountains = new ObservableCollection<MountainViewModel>(from DataBaseContext.Mountain instance in db.Mountains select new MountainViewModel(instance));

            //populate the mountains list from the DB 
        }
    }
}
