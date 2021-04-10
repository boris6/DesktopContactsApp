using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            List<Contact> contacts;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }
    }
}