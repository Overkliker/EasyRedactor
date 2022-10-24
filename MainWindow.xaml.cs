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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace Txt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;    
        }

        private void OpFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();

            using (Stream r = File.Open(op.FileName, FileMode.Open))
            {
                using (StreamReader rd = new StreamReader(r))
                {
                    text.Text = rd.ReadToEnd();
                }
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.ShowDialog();

            using (Stream s = File.Open(sav.FileName, FileMode.OpenOrCreate))
            {
                using (StreamWriter wr = new StreamWriter(s))
                {
                    wr.Write(text.Text);
                }
            }
        }
    }
}
