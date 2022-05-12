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

namespace TrashgamePicker
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


        #region Methods

        public static void Message(string message)
        {
            MessageBox.Show(message);
        }

        private void Startup()
        {
            Button_Delete.IsEnabled = false;
            Button_Pick.IsEnabled = false;

            Settings.Load();
            Manager.GAMES = new(FileManager.LoadGames()!);

            Button_Pick.IsEnabled = true;
        }

        #endregion

        #region UI

        private void Button_Pick_Click(object sender, RoutedEventArgs e)
        {
            Manager.PickGame();
            TextBox_Trashgame.Text = $"Nr:{Trashgame.ID + 1} - {Trashgame.NAME}";
            Button_Delete.IsEnabled = true;
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button_Delete.IsEnabled = false;
            Button_Pick.IsEnabled= false;

            FileManager.DeleteGame();

            TextBox_Trashgame.Text = "";
            Button_Pick.IsEnabled = true;
        }

        private void Button_Reload_Click(object sender, RoutedEventArgs e)
        {
            Button_Delete.IsEnabled = false;
            Button_Pick.IsEnabled = false;
            Button_Reload.IsEnabled = false;
            TextBox_Trashgame.Text = "";

            Manager.GAMES = new(FileManager.LoadGames()!);

            Button_Pick.IsEnabled = true;
            Button_Reload.IsEnabled = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Startup();
        }

        #endregion
    }
}
