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
using System.IO;
using Microsoft.Win32;
namespace MonitorFileSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileSystemWatcher watcher;
        public MainWindow()
        {
            InitializeComponent();
            watcher = new FileSystemWatcher();
            watcher.Deleted += (s, e) =>
              AddMessage($"File:{System.IO.Path.GetFileName(e.FullPath)} deleted");
            watcher.Renamed += (S, e) =>
              AddMessage($"File rename from {System.IO.Path.GetFileName(e.OldName)} to {System.IO.Path.GetFileName(e.FullPath)}");
            watcher.Changed += (s, e) =>
              AddMessage($"File :{System.IO.Path.GetFileName(e.FullPath)} {e.ChangeType.ToString()}");
            watcher.Created += (s, e) =>
              AddMessage($"File:{System.IO.Path.GetFileName(e.FullPath)} created");
        }
        private void AddMessage(string message)
        {
            Dispatcher.BeginInvoke(new Action(
                () => WatchOutput.Items.Insert(
                    0, DateTime.Now.ToShortTimeString()+ message)
                ));
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog(this) == true)
            {
                LocationBox.Text = dialog.FileName;
            }
        }

        private void LocationBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WatchButton.IsEnabled = !String.IsNullOrEmpty(LocationBox.Text);
        }

        private void WatchButton_Click(object sender, RoutedEventArgs e)
        {
            watcher.Path = System.IO.Path.GetDirectoryName(LocationBox.Text);
            watcher.Filter = System.IO.Path.GetFileName(LocationBox.Text);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            AddMessage("watcher: "+LocationBox.Text);
            //begin watching
            watcher.EnableRaisingEvents = true;
        }
    }
}
