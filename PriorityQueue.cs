namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> dataHeap;

        public PriorityQueue()
        {
            this.dataHeap = new List<T>();
        }

        public void Enqueue(T value)
        {
            this.dataHeap.Add(value);
            BubbleUp();
        }

        public T Dequeue()
        {
            if (this.dataHeap.Count <= 0)
            {
                throw new ArgumentException("Cannot Dequeue from empty queue!");
            }
      
            T result = dataHeap[0];
            int count = this.dataHeap.Count - 1;
            dataHeap[0] = dataHeap[count];
            dataHeap.RemoveAt(count);
            ShiftDown();

            return result;
        }

        private void BubbleUp()
        {
            int childIndex = dataHeap.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (dataHeap[childIndex].CompareTo(dataHeap[parentIndex]) >= 0)
                {
                    break;
                }

                SwapAt(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        private void ShiftDown()
        {
            int count = this.dataHeap.Count - 1;
            int parentIndex = 0;

            while (true)
            {
                int childIndex = parentIndex * 2 + 1;
                if (childIndex > count)
                {
                    break;
                }

                int rightChild = childIndex + 1;
                if (rightChild <= count && dataHeap[rightChild].CompareTo(dataHeap[childIndex]) < 0)
                {
                    childIndex = rightChild;
                }
                if (dataHeap[parentIndex].CompareTo(dataHeap[childIndex]) <= 0)
                {
                    break;
                }

                SwapAt(parentIndex, childIndex);
                parentIndex = childIndex;
            }
        }

        public T Peek()
        {
            if (this.dataHeap.Count == 0)
            {
                throw new ArgumentException("Queue is empty.");
            }

            T frontItem = dataHeap[0];
            return frontItem;
        }

        public int Count()
        {
            return dataHeap.Count;
        }

        public void Clear()
        {
            this.dataHeap.Clear();
        }

        public void CopyToArray(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array");
            }

            int length = array.Length;
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index must be between zero and array length.");
            }
            if (length - index < this.dataHeap.Count-1)
            {
                throw new ArgumentException("Queue is bigger than array");
            }

            T[] data = this.dataHeap.ToArray();
            Array.Copy(data, 0, array, index, data.Length);
        }

        public bool IsConsistent()
        {
            // is the heap property true for all data?
            if (dataHeap.Count == 0)
            {
                return true;
            }

            int lastIndex = dataHeap.Count - 1; // last index

            for (int parentIndex = 0; parentIndex < dataHeap.Count; ++parentIndex) // each parent index
            {
                int leftChildIndex = 2 * parentIndex + 1; // left child index
                int rightChildIndex = 2 * parentIndex + 2; // right child index

                if (leftChildIndex <= lastIndex && dataHeap[parentIndex].CompareTo(dataHeap[leftChildIndex]) > 0) return false; // if lc exists and it's greater than parent then bad.
                if (rightChildIndex <= lastIndex && dataHeap[parentIndex].CompareTo(dataHeap[rightChildIndex]) > 0) return false; // check the right child too.
            }

            return true; // passed all checks
        }

        private void SwapAt(int first,int second)
        {
            T value = dataHeap[first];
            dataHeap[first] = dataHeap[second];
            dataHeap[second] = value;
        }

        public override string ToString()
        {
            string queueString = string.Join(" ", dataHeap.ToArray());
            return queueString;
        }
    }
}