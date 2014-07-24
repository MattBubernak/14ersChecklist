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
        private static ChecklistViewModel _checkListViewModel = null;
        public ObservableCollection<MountainViewModel> mountains { get; set; }
        
        private ChecklistViewModel()
        {
            db = App.DB; 
            populate_mountains(); 
        }

        public static ChecklistViewModel get_instance()
        {
            if (_checkListViewModel == null)
            {
                _checkListViewModel = new ChecklistViewModel(); 
            }
            return _checkListViewModel; 
        }

        public void populate_mountains()
        {

            //populate the mountains list from the DB 
            mountains = new ObservableCollection<MountainViewModel>(from DataBaseContext.Mountain instance in db.Mountains select new MountainViewModel(instance));
            
        }

        public string TotalString
        {
            get
            {
                int total = 0; 
                foreach (MountainViewModel mountain in mountains)
                {
                    if (mountain.Check == true)
                    {
                        total++; 
                    }
                }
                return total + "/" + mountains.Count; 
            }
        }
    }
}
