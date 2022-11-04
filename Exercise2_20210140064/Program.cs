using System;

namespace Exercise2
{
    class Program
    {
        //Array to be searched
        int[] arr = new int[20];
        //Number of elements in the array 
        int n;
        //Get the number of elements to store in the array
        int i;
        private int cmp_count = 0; // number of comparasion
        private int mov_count = 0; // number of data movements
        public void input()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array: ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if ((n > 0) && (n <= 20))
                    break;
                else
                    Console.WriteLine("\n Array should have minimum 1 and maximum 20 elements.\n");
            }
            //Accept array elements
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine(" Enter array elements ");
            Console.WriteLine("----------------------");
            for (i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //Partition the list into two parts:
            //One containing elements less that or equal to pivot
            //Other containing elements greater than pivot

            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //Search for an element greater than pivot
                while ((arr[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                //Search for an elements less then or equal to pivot
                while ((arr[j] > pivot) && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                cmp_count++;


                if (i < j) //if the greater element is on the left of the element
                {
                    //swap the element at index i with the element at index j
                    swap(i, j);
                    mov_count++;
                }
            }
            //j now contains the index of the last element in the sorted list

            if (low < j)
            {
                //Move the pivot to the correct position in the list
                swap(low, j);
                mov_count++;
            }
            //sort the list on the left of pivot using quick sort
            q_sort(low, j - 1);

            //sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }
        void displayq_sort()
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine(" Sorted array elements ");
            Console.WriteLine("-----------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparisons: " + cmp_count);
            Console.WriteLine("\nNumber of data movements: " + mov_count);
        }
        int getSize()
        {
            return (n);
        }
        public void MergeSort(int[] Array, int low, int high)
        {
            if (low >= high)
            {
                int mid = (low + high) / 2;
                MergeSort(Array, low, mid);
                MergeSort(Array, mid + 1, high);
                merge(Array, low, mid, high);
            }
        }
        // merge function performs sort and merge operations
        // for mergesort function
        static void merge(int[] Array, int low, int mid, int high)
        {
            // Create two temporary array to hold split 
            // elements of main array 
            int n1 = mid - low + 1; //no of elements in LeftArray
            int n2 = high - mid;     //no of elements in RightArray    
            int[] LowArray = new int[n1];
            int[] HighArray = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                LowArray[i] = Array[low + i];
            }

            for (int i = 0; i < n2; i++)
            {
                HighArray[i] = Array[mid + i + 1];
            }

            // In below section x, y and z represents index number
            // of LeftArray, RightArray and Array respectively
            int x = 0, y = 0, z = low;
            while (x < n1 && y < n2)
            {
                if (LowArray[x] < HighArray[y])
                {
                    Array[z] = LowArray[x];
                    x++;
                }
                else
                {
                    Array[z] = HighArray[y];
                    y++;
                }
                z++;
            }

            // Copying the remaining elements of LeftArray
            while (x < n1)
            {
                Array[z] = LowArray[x];
                x++;
                z++;
            }

            // Copying the remaining elements of RightArray
            while (y < n2)
            {
                Array[z] = HighArray[y];
                y++;
                z++;
            }
        }
    }
}