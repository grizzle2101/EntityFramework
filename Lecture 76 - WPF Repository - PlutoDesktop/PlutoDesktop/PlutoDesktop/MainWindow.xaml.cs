using PlutoDesktop.Core;
using PlutoDesktop.Core.Domain;
using PlutoDesktop.Persistence;
using System;
using System.Data.Entity;
using System.Windows;

namespace PlutoDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Old Way
        private PlutoContext _context = new PlutoContext();

        //New Way - Unit of Work
        private IUnitOfWork unitofwork = new UnitOfWork(new PlutoContext());

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource courseViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("courseViewSource")));

            //Old Way - Eager Load the Courses & Authors
            _context.Courses.Include(c => c.Author).Load();

            //New Way - Unit of Work
            var courses = unitofwork.Courses.GetAll();

            //Add Courses to View
            //courseViewSource.Source = _context.Courses.Local;

            courseViewSource.Source = courses;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            
            //_context.Dispose();
            unitofwork.Dispose();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            //Old Way
            ////Adding a Hardcoded Course on ButtonClick.
            //_context.Courses.Add(new Course
            //{
            //    AuthorId = 1,
            //    Name = "New Course at " + DateTime.Now.ToShortDateString(),
            //    Description = "Description",
            //    FullPrice = 49,
            //    Level = 1

            //});
            ////Save Course
            //_context.SaveChanges();

            //New Way - Unit of Work
            unitofwork.Courses.Add(new Course
            {
                AuthorId = 2,
                Name = "Conor Mc",
                Description = "Ma Description",
                FullPrice = 420,
                Level = 3
            });
            unitofwork.Complete();
        }
    }
}
