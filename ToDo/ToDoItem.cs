using System;
namespace ToDo
{
    public class ToDoItem
    {
        private string _desc;
        private bool _comp;

        public ToDoItem(string description, bool completed)
        {
            _desc = description;
            _comp = completed;
        }

        public string Desc
        {
            get
            {
                return this._desc;
            }

            set
            {
                _desc = value;
            }
        }

        public bool Completed {
            get
            {
                return this._comp;
            }
            set
            {
                _comp = value;
            }
        }
    }
}
