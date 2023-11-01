using System;
using System.Collections;
using System.Collections.Generic;

public class UniversalCollection<T> : IEnumerable<T>
{
    private T[] items;

    public UniversalCollection()
    {
        items = new T[0];
    }

    public int Count => items.Length;

    public void Add(T item)
    {
        Array.Resize(ref items, items.Length + 1);
        items[items.Length - 1] = item;
    }

    public void SetDefaultAt(int index)
    {
        if (index >= 0 && index < items.Length)
        {
            items[index] = default(T);
        }
    }

    public void Sort()
    {
        Array.Sort(items);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
