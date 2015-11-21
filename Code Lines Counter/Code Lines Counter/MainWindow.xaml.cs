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
using System.Windows.Forms;
using System.IO;

namespace Code_Lines_Counter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string path = fbd.SelectedPath;
            txt_Directory.Text = path;
        }

        private void btn_Count_Click(object sender, RoutedEventArgs e)
        {
            SearchOption option;
            lst_FoundFiles.Items.Clear();
            long totalLines = 0;
            if (chk_SubDirectories.IsChecked.Value)
            {
                option = SearchOption.AllDirectories;
            }
            else
            {
                option = SearchOption.TopDirectoryOnly;
            }
            DirectoryInfo info = new DirectoryInfo(txt_Directory.Text);
            List<FileInfo> files = info.GetFiles("*", option).ToList();
            List<FileInfo> foundfiles = new List<FileInfo>();
            string[] extensions = txt_Extensions.Text.Split(new char[] { ',' });
            foreach(FileInfo file in files)
            {
                for(int i = 0; i < extensions.Length; i++)
                {
                    if (file.Extension.Equals(extensions[i]))
                    {
                        foundfiles.Add(file);
                    }
                }
            }

            foreach(FileInfo file in foundfiles)
            {
                string[] lines = File.ReadAllLines(file.Directory + "/" + file.Name);
                lst_FoundFiles.Items.Add(new FileInformation(file.Name, file.Length, lines.Length));
                totalLines += lines.Length;
            }
            txt_TotalLines.Text = Convert.ToString(totalLines);
        }
    }
}
