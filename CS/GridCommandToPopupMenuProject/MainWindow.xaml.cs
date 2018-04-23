using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;


namespace GridCommandToPopupMenuProject {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            persViewModel = new PersonViewModel(CreatePerson());
            DataContext = persViewModel;
        }

        PersonViewModel persViewModel;

        List<Person> CreatePerson() {
            List<Person> lPers = new List<Person>();
            for(int i = 0; i < 15; i++) {
                lPers.Add(new Person(i));
            }
            return lPers;
        }
    }
}
