using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class TaskManager
    {
        private int _taskIdCounter = 0;
        private int _categoryIdCounter = 0;
        private int _priorityIdCounter = 0;

        private List<MyTask> _tasks = null;
        private List<Category> _categories = null;
        private List<Priority> _priorities = null;

        public TaskManager()
        {
            _tasks = new List<MyTask>();
            _categories = new List<Category>();
            _priorities = new List<Priority>();
        }

        public void CreatePriority(int level)
        {
            _priorityIdCounter += 1;
            var pr = new Priority() { ID = _priorityIdCounter, Power = level };
            _priorities.Add(pr);
        }

        public void RemovePriority(int id)
        {
            try
            {
                _priorities.Remove(_priorities.Where(x => x.ID == id).First());
            }
            catch
            {
                Console.WriteLine("Not found!");
            }   
        }

        public void CreateCategory(string name)
        {
            _categoryIdCounter += 1;
            var cat = new Category() { ID = _categoryIdCounter, Name = name };
            _categories.Add(cat);
        }

        public void RemoveCategory(int id)
        {
            try
            {
                _categories.Remove(_categories.Where(x => x.ID == id).First());
            }
            catch
            {
                Console.WriteLine("Not found!");
            }
        }

        public void CreateTask(string name, string desc)
        {
            _taskIdCounter+= 1;
            var task = new MyTask() { ID = _taskIdCounter, Name = name, Description = desc};
            _tasks.Add(task);
        }

        public void RemoveTask(int id)
        {
            try
            {
                _tasks.Remove(_tasks.Where(x => x.ID == id).First());
            }
            catch
            {
                Console.WriteLine("Not found!");
            }
        }

        public void AssignCategoryToTask(Category cat, MyTask task)
        {
            cat.Tasks.Add(task);
            task.Category = cat;
        }

        public void AssignPriorityToTask(Priority pr, MyTask task) 
        {
            task.Priority = pr;
        }

        public void UnWrapBox(string content)
        {

        }

        public string WrapBox()
        {
            string content = $"[[Priority->{_priorityIdCounter}]]\r\n";
            for (int i = 0; i < _priorities.Count; i++)
            {
                content += $"/==[Priority]\r\n{_priorities[i].ID}-+-{_priorities[i].Power}\r\n";
            }
            content += $"[[Category->{_categoryIdCounter}]]\r\n";
            for (int i = 0; i < _categories.Count; i++)
            {
                content += $"/==[Category]\r\n{_categories[i].ID}-+-{_categories[i].Name}-+-";
                for (int j = 0; j < _categories[i].Tasks.Count; j++)
                {
                    content += $"({_categories[i].Tasks[j].ID})";
                }
                content += "\r\n";
            }
            content += $"[[Task->{_taskIdCounter}]]\r\n";
            for (int i = 0; i < _tasks.Count; i++)
            {
                content += $"/==[Task]\r\n{_tasks[i].ID}-+-{_tasks[i].Name}-+-{_tasks[i].Description}-+-{_tasks[i].Priority.ID}-+-{_tasks[i].Category}";
            }
            return content;
        }
    }
}