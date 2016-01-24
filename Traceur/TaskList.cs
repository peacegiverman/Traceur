using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traceur
{
    class TaskList : System.ComponentModel.IListSource
    {
        public TaskList()
        {

        }

        public bool ContainsListCollection
        {
            get { return false; }
        }

        public System.Collections.IList GetList()
        {
            return TaskHandler.Instance.GetArrayOfTasks();
        }
    }
}
