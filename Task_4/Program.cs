using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//Используя Visual Studio, создайте проект по шаблону Console Application.  
//Создайте расширяющий метод:  
//public static T[] GetArray<T>(this IEnumerable<T> list) {…}
//Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем задании 2 
//для  данного  урока.  Выведите  на  экран  значения  элементов  массива, который  вернул  расширяющий 
//метод GetArray(). 

namespace Task_4
{
    static class ExMethod
    {
        public static T[] GetArray<T>(this IEnumerable<T> list)
        {
            T[] a = new T[list.Count()];
            int i = 0;

            foreach (T item in list)
            {
                a[i] = item;
                i++;
            }

            return a;
        }
    }

    class MyList<T> : IEnumerable<T>
    {
        T[] elements; int length = 0;
        public int Count { get { return length; } }

        public void Add(T el)
        {
            Array.Resize(ref elements, length + 1);
            elements[elements.Length - 1] = el;
            length = elements.Length;
        }

        public T this[int index] { get { return elements[index]; } }

        // Указатель текущей позиции элемента в массиве.
        int position = -1;

        // Реализация интерфейса - IEnumerable.
        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (position < length - 1)
                {
                    position++;
                    yield return elements[position];
                }
                else
                {
                    position = -1;
                    yield break;  // Выход из цикла.       
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> number = new MyList<int>();
            number.Add(13);
            number.Add(14);
            number.Add(17);
            number.Add(22);
            number.Add(37);
            number.Add(55);
            Console.WriteLine($"Элемент под индексом 0: {number[0]}");
            Console.WriteLine($"Количество элементов в массиве: {number.Count}");
            Console.WriteLine("Вывод всех элементов:");

            var arr = number.GetArray<int>();

            foreach (var el in arr)
                Console.WriteLine(el);

            Console.WriteLine("Нажмите клавишу для выхода..");
            Console.ReadKey();
        }
    }
}
