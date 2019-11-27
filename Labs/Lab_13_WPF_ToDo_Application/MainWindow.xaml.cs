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

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();
        Task task;
        List<Category> categories = new List<Category>();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        #region //OriginalOldCodeWhereWeListDataAsStringsNotOOP
        //void InitialiseListBoxOfStrings()
        //{
        //    ListBoxTasks.ItemsSource = items;
        //    using (var db = new TasksDBEntities())
        //    {
        //        tasks = db.Tasks.ToList();
        //    }
        //    // get description and add to list
        //    foreach(var item in tasks)
        //    {
        //        items.Add($"{item.TaskID,-10}{item.Description,-40}{item.Done,-10}{item.DateCompleted}");
        //    }
        //}
        #endregion
        #region InitialiseApplication
        void Initialise()
        {
            using (var db = new TasksDBEntities())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = tasks;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategoryName";


            // Inner Join 
            using (var db = new TasksDBEntities())
            {
                // task but it has a CATEGORYID.  INNER JOIN => CATEGORYNAME
                var taskList =
                    from task in db.Tasks
                    join category in db.Categories on
                        task.CategoryID equals category.CategoryId
                    // HAVE TO CREATE A NEW OUTPUT OBJECT (CUSTOM)
                    select new
                    {
                        taskID = task.TaskID,
                        description = task.Description,
                        category = category.CategoryName
                    };
                // PRINT LIST
                foreach (var task in taskList.ToList())
                {
                    System.Diagnostics.Trace.WriteLine($"{task.taskID,-10}{task.description,-20}{task.category}");
                }
            }
        }
        #endregion InitialiseApplication
        #region SelectATaskInTheListBox
        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
       
            // print out details of selected item
            // instance = (convert to Task) the item selected in listbox by user
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                TextBoxId.Text = task.TaskID.ToString(); ;
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID-1;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
            }
        }
        #endregion SelectATask
        #region OpenATaskForEditingByDoubleClickingTaskInListBox
        private void ListBoxTasks_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // get object
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                // set the boxes for edit conditions
                TextBoxId.Text = task.TaskID.ToString(); ;
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID - 1;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
            }
        }
        #endregion OpenATaskForEditingByDoubleClickingTaskInListBox

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
            }
            else  // ie we are in 'Save' mode
            {
                using (var db = new TasksDBEntities())
                {
                    var taskToEdit = db.Tasks.Find(task.TaskID);
                    // update description & categoryid
                    taskToEdit.Description = TextBoxDescription.Text;
                    // converting category id to integer from text box (string)
                    // tryparse is a safe way to do conversion : null if fails
                    int.TryParse(TextBoxCategoryId.Text, out int categoryid);
                    taskToEdit.CategoryID = categoryid;
                    if (task.CategoryID != null)
                    {
                        ComboBoxCategory.SelectedIndex = (int)taskToEdit.CategoryID - 1;
                    }
                    else
                    {
                        ComboBoxCategory.SelectedItem = null;
                    }
                    // update record in database
                    db.SaveChanges();
                    // update list box !!
                    ListBoxTasks.ItemsSource = null; // reset list box
                    tasks = db.Tasks.ToList();  // get fresh list
                    ListBoxTasks.ItemsSource = tasks;  // re-link the list box to new list
                }
                ButtonEdit.Content = "Edit";
                ButtonEdit.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#EEFAFF");
            }

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm";
                // set boxes to editable
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                // clear out boxes
                TextBoxId.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategoryId.Text = "";
            }
            else
            {
                ButtonAdd.Content = "Add";
                // set boxes back to read only
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                // add record to database
                int.TryParse(TextBoxCategoryId.Text, out int categoryID);

                var taskToAdd = new Task()
                {
                    Description = TextBoxDescription.Text,
                    CategoryID = categoryID

                };
                using (var db = new TasksDBEntities())
                {
                    db.Tasks.Add(taskToAdd);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null;
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;
                }

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Are You Sure?";
                TextBoxId.Background = Brushes.OrangeRed;
                TextBoxDescription.Background = Brushes.OrangeRed;
                TextBoxCategoryId.Background = Brushes.OrangeRed;
            }
            else
            {
                if (task != null)
                {
                    using (var db = new TasksDBEntities())
                    {
                        var taskToRemove = db.Tasks.Find(task.TaskID);
                        db.Tasks.Remove(taskToRemove);
                        db.SaveChanges();
                        // update list
                        ListBoxTasks.ItemsSource = null;
                        tasks = db.Tasks.ToList();
                        ListBoxTasks.ItemsSource = tasks;
                    }
                }
                ButtonDelete.Content = "Delete";
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxId.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                // clear out boxes
                TextBoxId.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategoryId.Text = "";
            }
        }
    }
}
