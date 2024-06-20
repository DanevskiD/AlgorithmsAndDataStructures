using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class CustomList : IEnumerable<int>
    {
        private int[] _array;

        public CustomList()
        {
            this._array = new int[5];
        }

        public int this[int index]
        {
            get
            { /* return the specified index here */
                this.ValidateIndex(index);
                return this._array[index];
            }
            set
            { /* set the specified index to value here */
                this.ValidateIndex(index);
                this._array[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(int element)
        {
            this.GrowIfNeeed();

            this._array[this.Count] = element;
            this.Count++;
        }

        public void Insert(int index, int element)
        {
            if (index == this.Count)
            {
                this.Add(element);
                return;
            }

            this.ValidateIndex(index);
            this.GrowIfNeeed();
            this.ShiftRight(this.Count - 1, index);

            this._array[index] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            /*for (int i = index + 1; i < this.Count; i++)
                this._array[i - 1] = this._array[i];*/

            this.ShiftLeft(index + 1, this.Count - 1);
            //this[this.Count - 1] = 0;
            this.Count--;
        }

        private void GrowIfNeeed()
        {
            if (this.Count == this._array.Length) this.Grow();
        }
        private void Grow()
        {
            int[] newArray = new int[this._array.Length * 2];
            Array.Copy(this._array, newArray, this._array.Length);

            this._array = newArray;
        }

        private void ShiftRight(int start, int end)
        {
            for (int i = end; i >= start; i--)
                this._array[i + 1] = this._array[i];
        }

        private void ShiftLeft(int start, int end)
        {
            for (int i = start; i < end; i++)
                this._array[i - 1] = this._array[i];
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException("Index is out of range!");
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++) yield return this._array[i];
            
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
