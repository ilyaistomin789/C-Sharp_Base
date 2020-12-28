using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_9
{
    public delegate void EventDelegate();

    internal class EventArgs
    {
        private EventDelegate _newEvent;
        public event EventDelegate MyEvent
        {
            add => _newEvent += value;
            remove
            {
                if (_newEvent != null)
                {
                    _newEvent -= value;
                }
            }
        }

        public void InvokeEvent()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            _newEvent.Invoke();
            Console.ResetColor();
        }

        


    }
}
