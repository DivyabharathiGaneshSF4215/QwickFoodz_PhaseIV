using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public partial class CustomList<Type>
    {
        //field for size
        private static int _size;
        
        //field for count
        private static int _count;

        public int Size { get { return _size;} }
        public int Capacity { get{ return _count;}}
        private static Type[] _array;

        public Type this[int index]
        {
            get {return _array[index]; }
            set {_array[index] = value;  }
        }
        //create a class for custom list
        public CustomList()
        {
            _size = 4;
            _count = 0;
            Type[] _array = new Type[_size];
        }
        //Add method to add element in the list
        public static void Add(Type data)
        {
            //checks if the array has space for store that one data
            if(_size == _count)
            {
                //if the number of elements and the size of the array is same..need to increase the size
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }
        //GrowSizze method for increasing size of the array
        public static void GrowSize()
        {
            _size *=2; 
            Type[] temp = new Type[_size];
            for(int i =0;i<_count;i++)
            {
                temp[i] = _array[i];
            }

        }
        //AddRange method for adding one list to another list
        public static void AddRange(CustomList<Type> dataList)
        {
            //identify the size of the resultant list
            _size = _size + dataList.Capacity+4;

            //create a temporary list for storing the resultant list
            Type[] temp = new Type[_size];

            //store the first list in temporary array
            for(int i =0;i<_count;i++)
            {
                temp[i] = _array[i];
            }
            int k=0;
            //Now continue to add on the temporary array
            for(int j=_count;j<_size;j++)
            {
                temp[j] = _array[k];
                k++;
            }
        }

    }
}