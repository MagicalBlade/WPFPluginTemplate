using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tekla.Structures.Dialog;
using Tekla.Structures.Catalogs;

namespace WPFPluginTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : PluginWindowBase
    {
        public MainWindowViewModel dataModel;
        
        public MainWindow(MainWindowViewModel DataModel)
        {
            InitializeComponent();
            dataModel = DataModel;
        }
        
        private void WpfOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void WpfOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WpfOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            this.Get();

        }

        private void WpfOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void WpfOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void WpfOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (faska.SelectedIndex == 1)
            {
                zazor.IsEnabled = true;
            }
            else
            {
                zazor.IsEnabled = false;
            }
        }

        private void transition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (transition.SelectedIndex == 0)
            {
                H1_transition.IsEnabled = false;
                L1_transition.IsEnabled = false;
            }
            else
            {
                H1_transition.IsEnabled = true;
                L1_transition.IsEnabled = true;
            }
        }
    }
}
