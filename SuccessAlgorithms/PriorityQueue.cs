using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class PriorityQueue
    {
        public enum PriorityQueueType
        {
            Min,
            Max
        };

        PriorityQueueType type;

        public PriorityQueue(PriorityQueueType type)
        {
            this.type = type;
        }

        public void Heapify(int[] arr)
        {
            int idx = 0;
            int childIdx = 0;

            while (idx <= (arr.Length -1) /2)
            {
                childIdx = idx * 2 + 1;

                if (type == PriorityQueueType.Max)
                {
                    if (childIdx < arr.Length && arr[idx] < arr[childIdx])
                    {
                        swap(arr, idx, childIdx);
                    }
                    else if (childIdx + 1 < arr.Length && arr[idx] < arr[childIdx + 1])
                    {
                        swap(arr, idx, childIdx + 1);
                    }
                }
                else
                {
                    if (childIdx < arr.Length && arr[idx] > arr[childIdx])
                    {
                        swap(arr, idx, childIdx);
                    }
                    else if (childIdx + 1 < arr.Length && arr[idx] > arr[childIdx + 1])
                    {
                        swap(arr, idx, childIdx + 1);
                    }
                }

                idx++;
            }
        }

        private void swap(int[] arr, int source, int dest)
        {
            int temp = arr[source];
            arr[source] = arr[dest];
            arr[dest] = temp;
        }
    }
}
