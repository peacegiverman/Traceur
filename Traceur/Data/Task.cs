using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Traceur
{
    class Task
    {
        //NOTE: may need ID
        [PrimaryKey, AutoIncrement]
        public int id { get; private set; }
        public string name { get; private set; }
        public DateTime startTime { get; private set; }
        //TODO: endTime setter
        public DateTime? endTime { get; set; }

        public Task() { }

        public Task(string name)
        {
            Init(name, DateTime.Now);
        }

        public Task(string name, DateTime startTime, DateTime? endTime = null)
        {
            Init(name, startTime, endTime);
        }

        private void Init(string name, DateTime startTime, DateTime? endTime = null)
        {
            this.name = name;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public TimeSpan GetElapsedTime()
        {
            DateTime finalTime = endTime != null ? (DateTime)endTime : DateTime.Now;

            return finalTime - startTime;
        }
    }
}
