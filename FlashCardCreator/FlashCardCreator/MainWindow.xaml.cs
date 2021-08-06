using Microsoft.Win32;
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

namespace FlashCardCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
        }

        private void TopOne_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var x = (Image)sender;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                x.Source = new BitmapImage(fileUri);
            }
        }

        void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.P) && (Keyboard.Modifiers == ModifierKeys.Control))
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog().GetValueOrDefault(false))
                {
                    printDialog.PrintVisual(this, this.Title);
                }
            }
        }
    }
}
