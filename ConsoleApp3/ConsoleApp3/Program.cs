using System;

class VectorLong
{
    // Поля
    protected long[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vl;

    // Конструктори
    public VectorLong()
    {
        IntArray = new long[1];
        size = 1;
        num_vl++;
    }

    public VectorLong(uint size)
    {
        IntArray = new long[size];
        this.size = size;
        num_vl++;
    }

    public VectorLong(uint size, long initValue)
    {
        IntArray = new long[size];
        this.size = size;
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        num_vl++;
    }

    // Деструктор
    ~VectorLong()
    {
        Console.WriteLine("Деструктор викликаний.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент {i}: ");
            IntArray[i] = long.Parse(Console.ReadLine());
        }
    }

    public void PrintElements()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Елемент {i}: {IntArray[i]}");
        }
    }

    public void SetAllElements(long value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint CountVectors()
    {
        return num_vl;
    }

    // Властивості
    public uint Size
    {
        get { return size; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public long this[int index]
    {
        get
        {
            if (index >= 0 && index < size)
                return IntArray[index];
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            codeError = -1;
        }
    }

    // Перевантаження операторів
    public static VectorLong operator ++(VectorLong vl)
    {
        for (int i = 0; i < vl.size; i++)
        {
            vl.IntArray[i]++;
        }
        return vl;
    }

    public static VectorLong operator --(VectorLong vl)
    {
        for (int i = 0; i < vl.size; i++)
        {
            vl.IntArray[i]--;
        }
        return vl;
    }

    public static bool operator true(VectorLong vl)
    {
        for (int i = 0; i < vl.size; i++)
        {
            if (vl.IntArray[i] == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorLong vl)
    {
        for (int i = 0; i < vl.size; i++)
        {
            if (vl.IntArray[i] == 0)
                return true;
        }
        return false;
    }

    public static bool operator !(VectorLong vl)
    {
        for (int i = 0; i < vl.size; i++)
        {
            if (vl.IntArray[i] == 0)
                return true;
        }
        return false;
    }

    public static VectorLong operator +(VectorLong vl1, VectorLong vl2)
    {
        if (vl1.size != vl2.size)
            throw new ArgumentException("Розміри векторів не співпадають.");

        VectorLong result = new VectorLong(vl1.size);
        for (int i = 0; i < vl1.size; i++)
        {
            result.IntArray[i] = vl1.IntArray[i] + vl2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator -(VectorLong vl1, VectorLong vl2)
    {
        if (vl1.size != vl2.size)
            throw new ArgumentException("Розміри векторів не співпадають.");

        VectorLong result = new VectorLong(vl1.size);
        for (int i = 0; i < vl1.size; i++)
        {
            result.IntArray[i] = vl1.IntArray[i] - vl2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator *(VectorLong vl, long scalar)
    {
        VectorLong result = new VectorLong(vl.size);
        for (int i = 0; i < vl.size; i++)
        {
            result.IntArray[i] = vl.IntArray[i] * scalar;
        }
        return result;
    }

    // Додаткові перевантаження, можна додати за необхідності

}

class Program
{
    static void Main(string[] args)
    {
        VectorLong vec1 = new VectorLong(3, 5);
        VectorLong vec2 = new VectorLong(3, 3);

        VectorLong vec3 = vec1 + vec2;
        vec3.PrintElements();

        ++vec3;
        vec3.PrintElements();

        VectorLong vec4 = new VectorLong(3);
        if (!vec4)
            Console.WriteLine("Вектор порожній.");

        Console.WriteLine("Кількість векторів: " + VectorLong.CountVectors());
    }
}
