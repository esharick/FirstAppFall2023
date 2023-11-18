using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FirstApp.Models {
    public class Contact : INotifyPropertyChanged {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string name;
        public string Name {
            get { return name; }
            set
            {
                if (name != value) {
                    name = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public string Status { get; set; }
        public string ImageUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
