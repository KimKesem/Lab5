using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Lab5.Models;
using Lab5.Services;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private BindingList<ToDoModel> _todoDataList;
        private FileIOService _fileIoService;

        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                
                ShowTaskDetails();
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
              
                ShowContextMenu();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                
                ShowTaskDetails();
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                
                ShowContextMenu();
            }
        }

        private void ShowTaskDetails()
        {
            
            var selectedTask = dgToDoList.SelectedItem as ToDoModel;
            if (selectedTask != null)
            {
                
                MessageBox.Show($"Details: {selectedTask.Details}");
            }
        }

        private void ShowContextMenu()
        {
            
            var selectedTask = dgToDoList.SelectedItem as ToDoModel;
            if (selectedTask != null)
            {
              
                ContextMenu contextMenu = new ContextMenu();

              


               
                contextMenu.IsOpen = true;
            }
        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIoService = new FileIOService(PATH);
            try
            {
                _todoDataList = _fileIoService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dgToDoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;
        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIoService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}