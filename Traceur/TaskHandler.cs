using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Traceur
{
    class TaskHandler
    {
        private static TaskHandler instance;
        public static TaskHandler Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new TaskHandler();
                }
                return instance;
            }
        }

        static private string taskDBPath = "traceur.db";
        private SQLiteConnection db;

        public Task activeTask { get; private set; }

        private GoogleCalendarHandler calendar;

        private TaskHandler()
        {
            activeTask = null;

            //Connect to DB
            try
            {
                db = new SQLiteConnection(taskDBPath);
                //create table if not exists
                db.CreateTable<Task>();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            //Connect to Google API?
            calendar = new GoogleCalendarHandler();
        }

        public void AddNewTask(string taskName)
        {
            var task = new Task(taskName);
            AddNewTask(task);
        }

        // Create new task
        public void AddNewTask(Task task)
        {
            //TODO: Maybe refactor and move to a level above
            if (activeTask != null)
            {
                if (task.name == activeTask.name)
                {
                    EndTask(activeTask);
                    return;
                }
                else
                {
                    EndTask(activeTask);
                }
            }
            

            //Add to DB
            db.Insert(task);

            //Add to Calendar
            calendar.AddTask(task);

            //set active task
            activeTask = task;
        }

        public void EndTask(string taskName)
        {
            //if null or empty -> task = last Task
            //Below could maybe be abstracted
            // for each provider
            // -> do provider.update()
            //Modify DB entry endTime (last entry with name == taskName)
            //Modify Google calendar entry
        }

        public void EndTask(Task task)
        {
            task.endTime = DateTime.Now;
            
            db.Update(task);
            calendar.EndTask(task);

            activeTask = null;
        }

        //public void EndTask(int taskId)
        //{

        //}

		//TODO: Cache these!!
        internal System.Collections.IList GetArrayOfTasks()
        {
            return db != null ? db.Table<Task>().ToArray<Task>() : new Task[0];
        }

		internal string[] GetPreviousTaskNames()
		{
			var tasks = GetArrayOfTasks();

			var taskNames = new string[tasks.Count];
			for (int i = 0; i < tasks.Count; i++)
			{
				taskNames[i] = ((Task) tasks[i]).name;
			}

			return taskNames;
		}
	}
}
