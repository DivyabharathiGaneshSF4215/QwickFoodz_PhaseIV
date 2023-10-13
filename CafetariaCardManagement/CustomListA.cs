using System;
using System.Collections;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public partial class CustomList<Type>:IEnumerable,IEnumerator
    {
        int i=0;
        
        public IEnumerator GetEnumerator() 
        {
            return (IEnumerator)this;
        } 
        public  object Current
        {
            get{return _array[i];}
            
        }
        public bool MoveNext()
        {
            if(i< _count-1)
            {
                i++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            i=-1;
        }
        
    }
}