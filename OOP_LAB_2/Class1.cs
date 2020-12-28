using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proLVL
{
    class Example : IDisposable
    {
        private readonly int _state;
        public Example(int state)
        {
            _state = state;
        }
        public int GetState() => _state;
        public void Dispose()
        {

        }
    }
}
