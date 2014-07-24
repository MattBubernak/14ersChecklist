using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace _14ers_Checklist.Models
{
    public class DataBaseContext : DataContext
    {

        // Pass the connection string to the base class.
        public DataBaseContext(string connectionString)
            : base(connectionString)
        { }


        // Specify a table for the to-do items.
        public Table<Mountain> Mountains;
        public Table<Note> Notes;
       


        #region Mountain
        //player
        [Table]
        public class Mountain : INotifyPropertyChanged, INotifyPropertyChanging
        {

            
            // Define ID: private field, public property, and database column.
            private int _mountainID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int MountainID
            {
                get { return _mountainID; }
                set
                {
                    if (_mountainID != value)
                    {
                        NotifyPropertyChanging("MountainID");
                        _mountainID = value;
                        NotifyPropertyChanged("MountainID");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private int _height;

            [Column]
            public int Height
            {
                get { return _height; }
                set
                {
                    if (_height != value)
                    {
                        NotifyPropertyChanging("Height");
                        _height = value;
                        NotifyPropertyChanged("Height");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private string _range;

            [Column]
            public string Range
            {
                get { return _range; }
                set
                {
                    if (_range != value)
                    {
                        NotifyPropertyChanging("Range");
                        _range = value;
                        NotifyPropertyChanged("Range");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private string _name;

            [Column]
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        NotifyPropertyChanging("Name");
                        _name = value;
                        NotifyPropertyChanged("Name");
                    }
                }
            }

            private DateTime _date;

            public DateTime Date
            {
                get { return _date; }
                set
                {
                    if (_date != value)
                    {
                        NotifyPropertyChanging("Date");
                        _date = value;
                        NotifyPropertyChanged("Date");
                    }
                }
            }

            private Boolean _check; 
            [Column]
            public Boolean Check
            {
                get { return _check;  }
                set
                {
                    if (_check != value)
                    {
                        NotifyPropertyChanging("Check");
                        _check = value;
                        NotifyPropertyChanged("Check");
                    }
                }
            }


 #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            // Used to notify that a property changed
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion

            #region INotifyPropertyChanging Members

            public event PropertyChangingEventHandler PropertyChanging;

            // Used to notify that a property is about to change
            private void NotifyPropertyChanging(string propertyName)
            {
                if (PropertyChanging != null)
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
                }
            }

            #endregion

        }
        #endregion


        #region note
        //player
        [Table]
        public class Note : INotifyPropertyChanged, INotifyPropertyChanging
        {
            public Note()
            {

            }

            // Define ID: private field, public property, and database column.
            private int _noteID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int NoteID
            {
                get { return _noteID; }
                set
                {
                    if (_noteID != value)
                    {
                        NotifyPropertyChanging("NoteID");
                        _noteID = value;
                        NotifyPropertyChanged("NoteID");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
            private string _name;

            [Column]
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        NotifyPropertyChanging("Name");
                        _name = value;
                        NotifyPropertyChanged("Name");
                    }
                }
            }

            private string _message;

            [Column]
            public string Message
            {
                get { return _message; }
                set
                {
                    if (_message != value)
                    {
                        NotifyPropertyChanging("Message");
                        _message = value;
                        NotifyPropertyChanged("Message");
                    }
                }
            }

            private DateTime _date;

            [Column]
            public DateTime Date
            {
                get { return _date; }
                set
                {
                    if (_date != value)
                    {
                        NotifyPropertyChanging("Date");
                        _date = value;
                        NotifyPropertyChanged("Date");
                    }
                }
            }
         #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;

            // Used to notify that a property changed
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            #endregion

            #region INotifyPropertyChanging Members

            public event PropertyChangingEventHandler PropertyChanging;

            // Used to notify that a property is about to change
            private void NotifyPropertyChanging(string propertyName)
            {
                if (PropertyChanging != null)
                {
                    PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
                }
            }

            #endregion
        }
        #endregion



    }
}
