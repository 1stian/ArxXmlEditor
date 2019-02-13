using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace TestWpf
{

    //Made by Stian "1stian" Tofte


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public ObservableCollection<Doors> doors = new ObservableCollection<Doors>();

        public MainWindow()
        {
            InitializeComponent();

            versionBlock.Text = "Ver: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //Sets where doorList gets its data from.
            doorList.ItemsSource = doors;
        }

        //Number check.
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public class Doors
        {
            public string DoorName { get; set; }
            public string Number { get; set; }
            public string Group { get; set; }
            public string Description { get; set; }
            public string mac { get; set; }
        }

        //Adding doors to Collection.
        private void ButtonAddDoor_Click(object sender, RoutedEventArgs e)
        {
            doors.Add(new Doors()
            {
                DoorName = textDoorname.Text,
                Number = textDoornumber.Text,
                Group = textDoorgroup.Text,
                Description = textDesc.Text,
                mac = textMac.Text
            });

            if (autoInc.IsChecked == true)
            {
                int nr = Int32.Parse(textDoornumber.Text);
                nr++;
                textDoornumber.Text = nr.ToString();

                int grp = Int32.Parse(textDoorgroup.Text);
                grp++;
                textDoorgroup.Text = nr.ToString();
            }

            int count = Int32.Parse(textDoorCount.Text);
            count++;
            textDoorCount.Text = count.ToString();
        }

        private void ButtonUpdateDoor_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            doors.Remove(new Doors()
            {
                DoorName = textDoorname.Text,
                Number = textDoornumber.Text,
                Group = textDoorgroup.Text,
                Description = textDesc.Text,
                mac = textMac.Text
            });
        }

        private void DoorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                textDoorname.Text = row_selected["0"].ToString();
                textDoornumber.Text = row_selected["1"].ToString();
                textDoorgroup.Text = row_selected["Group"].ToString();
                textDesc.Text = row_selected["Description"].ToString();
                textMac.Text = row_selected["mac"].ToString();
            }
        }
    }
}
