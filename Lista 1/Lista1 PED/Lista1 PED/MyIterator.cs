using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1_PED
{
    internal abstract class MyIterator<DataType>
    {
        public abstract DataType? Value { get; set; }

        public abstract void Next();

        public abstract void Previous();

        public abstract bool Valid();

        public abstract DataType? Get();

        public abstract void Set(DataType value);

        public abstract void Reset(MyIteratorList<DataType> list);
    }

    internal interface Iterable<DataType>
    {
        public MyIterator<DataType> GetMyIterator();
    }
}
