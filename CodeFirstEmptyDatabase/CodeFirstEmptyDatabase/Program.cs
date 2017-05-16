using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEmptyDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            //Step 1. Create the Objects (Course, Author, Tags, CourseLevel etc moved to their own file)
            //Step 2. Create the DB Conext to hide the Database Complexity
            //Step 3. Specify the Connection String in App.config
            //Step 4. Override & Specify Deault Entity Connection String in DBContext(because we broke the Entity convention)
            //Step 5. Enable "enable-migrations" & Create First Migration called "add-migration InitialModel"
            //Step 6. Finally, use the update-database command to finally apply our Very First Migration!

            Console.ReadKey();
        }
    }
}
