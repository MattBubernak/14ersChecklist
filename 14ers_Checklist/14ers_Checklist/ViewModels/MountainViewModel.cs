using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _14ers_Checklist.Models; 

namespace _14ers_Checklist.ViewModels
{
    class MountainViewModel : BaseViewModel
    {
        private DataBaseContext.Mountain databaseInstance;
        
        public MountainViewModel(DataBaseContext.Mountain mountain)
        {
            this.databaseInstance = mountain;
            this.db = App.DB; 
        }
        public string Name
        {
            get { return databaseInstance.Name; }
        }
        public string Range
        {
            get { return databaseInstance.Range; }
        }
        public int Height
        {
            get { return databaseInstance.Height; }
        }
        public string HeightString
        {
            get { return String.Format("{0:n0}",databaseInstance.Height); }
        }
        public DateTime Date
        {
            get { return databaseInstance.Date; }
        }

        public Boolean Check
        {
            get { return databaseInstance.Check; }
            set 
            {
                if (value == false)
                {
                    databaseInstance.Check = false;
                }
                else
                {
                    databaseInstance.Check = true; 
                }
                db.SubmitChanges();
                NotifyPropertyChanged("Check"); 
            }
        }

    }
}
