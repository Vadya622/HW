namespace HW_3_1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomCollection<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public CustomCollection()
        {
            items = new T[4];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                // Увеличиваем размер массива при необходимости
                Array.Resize(ref items, items.Length * 2);
            }

            items[count] = item;
            count++;
        }

        public void SetDefaultAt(int index, T defaultValue)
        {
            if (index >= 0 && index < count)
            {
                items[index] = defaultValue;
            }
        }

        public void Sort()
        {
            Array.Sort(items, 0, count);
        }

        // Реализация интерфейса IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        // Реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main()
        {
            CustomCollection<int> collection = new CustomCollection<int>();
            collection.Add(3);
            collection.Add(1);
            collection.Add(2);

            foreach (int item in collection)
            {
                Console.WriteLine(item);
            }

            collection.Sort();

            Console.WriteLine("After sorting:");

            foreach (int item in collection)
            {
                Console.WriteLine(item);
            }

            collection.SetDefaultAt(1, 10);

            Console.WriteLine("After setting default at index 1:");

            foreach (int item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }

}