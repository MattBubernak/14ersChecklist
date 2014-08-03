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
        //public Table<Ascent> Ascents; 
       


        #region Mountain
        //player
        [Table]
        public class Mountain : INotifyPropertyChanged, INotifyPropertyChanging
        {

            public Mountain(){}
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

            // Define item name: private field, public property, and database column.
            private DateTime? _date;

            [Column]
            public DateTime? Date
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

            private int _time;

            [Column]
            public int Time
            {
                get { return _time; }
                set
                {
                    if (_time != value)
                    {
                        NotifyPropertyChanging("Time");
                        _time = value;
                        NotifyPropertyChanged("Time");
                    }
                }
            }
             

            private String _message;

            [Column]
            public String Message
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
            /*
            private EntitySet<Ascent> _ascent;

            [Association(Storage = "_ascent", OtherKey = "_linkedMountainID", ThisKey = "MountainID")]
            public EntitySet<Ascent> Ascent
            {
                get { return this._ascent; }
                set { this._ascent.Assign(value); }
            }
            // Called during an add operation
            private void attach_Instance(Ascent ascent)
            {
                NotifyPropertyChanging("ExerciseInstance");
                ascent.Mountain = this;
            }
             

            // Called during a remove operation
            private void detach_Instance(Ascent ascent)
            {
                NotifyPropertyChanging("ExerciseInstance");
                ascent.Mountain = null;
            }

            public Mountain()
            {
                _ascent = new EntitySet<Ascent>(
                new Action<Ascent>(this.attach_Instance),
                new Action<Ascent>(this.detach_Instance)
                );
            }
           */


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

        /*
        #region Ascent
        //player
        [Table]
        public class Ascent : INotifyPropertyChanged, INotifyPropertyChanging
        {
            public Ascent()
            {

            }

            // Define ID: private field, public property, and database column.
            private int _ascentID;

            [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
            public int AscentID
            {
                get { return _ascentID; }
                set
                {
                    if (_ascentID != value)
                    {
                        NotifyPropertyChanging("AscentID");
                        _ascentID = value;
                        NotifyPropertyChanged("AscentID");
                    }
                }
            }

            // Define item name: private field, public property, and database column.
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

            private TimeSpan _time;

            [Column]
            public TimeSpan Time
            {
                get { return _time; }
                set
                {
                    if (_time != value)
                    {
                        NotifyPropertyChanging("Time");
                        _time = value;
                        NotifyPropertyChanged("Time");
                    }
                }
            }

            private String _message;

            [Column]
            public String Message
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

            [Column]
            internal int _linkedMountainID;

            private EntityRef<Mountain> _mountain; 

            [Association(Storage = "_moutain", ThisKey = "_linkedMountainID", OtherKey = "MountainID", IsForeignKey = true)]
            public Mountain Mountain
            {
                get { return _mountain.Entity; }
                set
                {
                    NotifyPropertyChanging("Mountain");
                    _mountain.Entity = value;

                    if (value != null)
                    {
                        _linkedMountainID = value.MountainID;
                    }

                    NotifyPropertyChanging("Mountain");
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

        */

    }
}
