using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace WPFPluginTemplate
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //Поля
        private double h1 = 250.0;
        private double h2 = 2.0;
        private double a1 = 45.0;
        private int l1 = 0;
        private int s1 = 0;


        //Свойства. Магия получения входных данных.
        [StructuresDialog("parametrh1",typeof(TD.Double))]
        
        public double H1
        {
            get => h1;
            set
            {
                h1 = value;
                OnPropertyChanged("H1");
            }
        }
        [StructuresDialog("parametrh2", typeof(TD.Double))]

        public double H2
        {
            get => h2;
            set
            {
                h2 = value;
                OnPropertyChanged("H2");
            }
        }
        [StructuresDialog("anglea1", typeof(TD.Double))]
        public double A1
        {
            get => a1;
            set
            {
                a1 = value;
                OnPropertyChanged("A1");
            }
        }
        [StructuresDialog("list1", typeof(TD.Integer))]
        public int L1
        {
            get => l1;
            set
            {
                l1 = value;
                OnPropertyChanged("L1");
            }
        }
        [StructuresDialog("parametrs1", typeof(TD.Integer))]
        public int S1
        {
            get => s1;
            set
            {
                s1 = value;
                OnPropertyChanged("S1");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler !=null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
