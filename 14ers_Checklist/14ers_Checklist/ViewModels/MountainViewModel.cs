using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _14ers_Checklist.Models; 

namespace _14ers_Checklist.ViewModels
{
    class MountainViewModel
    {
        private DataBaseContext.Mountain databaseInstance; 
        
        public MountainViewModel(DataBaseContext.Mountain mountain)
        {
            this.databaseInstance = mountain; 
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
        public DateTime Date
        {
            get { return databaseInstance.Date; }
        }

    }
}
