using System;

namespace Exercise2
{
    class Program
    {
        //Array to be searched
        int[] luni = new int[20];
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
                luni[i] = Int32.Parse(s1);
            }
        }
        void swap(int x, int y)
        {
            int temp;

            temp = luni[x];
            luni[x] = luni[y];
            luni[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            int pivot, i, CK;
            if (low > high)
                return;

            //Partition the list into two parts:
            //One containing elements less that or equal to pivot
            //Other containing elements greater than pivot

            i = low + 1;
            CK = high;

            pivot = luni[low];

            while (i <= CK)
            {
                //Search for an element greater than pivot
                while ((luni[i] <= pivot) && (i <= high))
                {
                    i++;
                    cmp_count++;
                }
                cmp_count++;

                //Search for an elements less then or equal to pivot
                while ((luni[CK] > pivot) && (CK >= low))
                {
                    CK--;
                    cmp_count++;
                }
                cmp_count++;


                if (i < CK) //if the greater element is on the left of the element
                {
                    //swap the element at index i with the element at index j
                    swap(i, CK);
                    mov_count++;
                }
            }
            //j now contains the index of the last element in the sorted list

            if (low < CK)
            {
                //Move the pivot to the correct position in the list
                swap(low, CK);
                mov_count++;
            }
            //sort the list on the left of pivot using quick sort
            q_sort(low, CK - 1);

            //sort the list on the right of pivot using quick sort
            q_sort(CK + 1, high);
        }
        void displayq_sort()
        {
            Console.WriteLine("\n-----------------------");
            Console.WriteLine(" Sorted array elements ");
            Console.WriteLine("-----------------------");

            for (int CK = 0; CK < n;CK++)
            {
                Console.WriteLine(luni[CK]);
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
        // function to print array
        static void PrintArray(int[] Array)
        {
            int n = Array.Length;
            for (int i = 0; i < n; i++)
                Console.Write(Array[i] + " ");
            Console.Write("\n");
        }
        public void display()
        {
            // Menampilkan array yang tersusun
            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            Console.WriteLine(" Elemen array yang telah tersusun ");
            Console.WriteLine("----------------------------------");
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(luni[j]);
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            Program myList = new Program();
            int pilihanmenu;

            Console.WriteLine("Menu Option");
            Console.WriteLine("================");
            Console.WriteLine("1.Quick Sort");
            Console.WriteLine("2.Merge Sort");
            Console.WriteLine("3.Exit");
            Console.Write("Enter your choice (1,2,3) : ");
            pilihanmenu = Convert.ToInt32(Console.ReadLine());
            switch (pilihanmenu)
            {
                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("-------------");
                    Console.WriteLine("Quick Sort");
                    Console.WriteLine("-------------");
                    myList.input();
                    myList.q_sort(0, myList.getSize() - 1);
                    myList.displayq_sort();
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("-------------");
                    Console.WriteLine("Quick Sort");
                    Console.WriteLine("-------------");
                    myList.input();
                    myList.q_sort(0, myList.getSize() - 1);
                    myList.displayq_sort();
                    break;
                case 3:
                    Console.WriteLine("exit.");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}