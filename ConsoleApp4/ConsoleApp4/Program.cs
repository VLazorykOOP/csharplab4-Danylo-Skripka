using System;

class MatrixLong
{
    // Поля
    protected long[,] LongArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_m;

    // Конструктори
    public MatrixLong()
    {
        LongArray = new long[1, 1];
        n = 1;
        m = 1;
        num_m++;
    }

    public MatrixLong(uint n, uint m)
    {
        LongArray = new long[n, m];
        this.n = n;
        this.m = m;
        num_m++;
    }

    public MatrixLong(uint n, uint m, long initValue)
    {
        LongArray = new long[n, m];
        this.n = n;
        this.m = m;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                LongArray[i, j] = initValue;
            }
        }
        num_m++;
    }

    // Деструктор
    ~MatrixLong()
    {
        Console.WriteLine("Деструктор викликаний.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Введіть елемент [{i}, {j}]: ");
                LongArray[i, j] = long.Parse(Console.ReadLine());
            }
        }
    }

    public void PrintElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.WriteLine($"Елемент [{i}, {j}]: {LongArray[i, j]}");
            }
        }
    }

    public void SetAllElements(long value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                LongArray[i, j] = value;
            }
        }
    }

    public static int CountMatrices()
    {
        return num_m;
    }

    // Властивості
    public uint N
    {
        get { return n; }
    }

    public uint M
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатори
    public long this[int i, int j]
    {
        get
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
                return LongArray[i, j];
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

    public long this[int k]
    {
        get
        {
            if (k >= 0 && k < n * m)
                return LongArray[k / m, k % m];
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
    public static MatrixLong operator ++(MatrixLong ml)
    {
        for (int i = 0; i < ml.n; i++)
        {
            for (int j = 0; j < ml.m; j++)
            {
                ml.LongArray[i, j]++;
            }
        }
        return ml;
    }

    public static MatrixLong operator --(MatrixLong ml)
    {
        for (int i = 0; i < ml.n; i++)
        {
            for (int j = 0; j < ml.m; j++)
            {
                ml.LongArray[i, j]--;
            }
        }
        return ml;
    }

    public static bool operator true(MatrixLong ml)
    {
        for (int i = 0; i < ml.n; i++)
        {
            for (int j = 0; j < ml.m; j++)
            {
                if (ml.LongArray[i, j] == 0)
                    return false;
            }
        }
        return true;
    }

    public static bool operator false(MatrixLong ml)
    {
        for (int i = 0; i < ml.n; i++)
        {
            for (int j = 0; j < ml.m; j++)
            {
                if (ml.LongArray[i, j] == 0)
                    return true;
            }
        }
        return false;
    }

    public static bool operator !(MatrixLong ml)
    {
        for (int i = 0; i < ml.n; i++)
        {
            for (int j = 0; j < ml.m; j++)
            {
                if (ml.LongArray[i, j] == 0)
                    return true;
            }
        }
        return false;
    }

    public static MatrixLong operator +(MatrixLong ml1, MatrixLong ml2)
    {
        if (ml1.n != ml2.n || ml1.m != ml2.m)
            throw new ArgumentException("Розміри матриць не співпадають.");

        MatrixLong result = new MatrixLong(ml1.n, ml1.m);
        for (int i = 0; i < ml1.n; i++)
        {
            for (int j = 0; j < ml1.m; j++)
            {
                result.LongArray[i, j] = ml1.LongArray[i, j] + ml2.LongArray[i, j];
            }
        }
        return result;
    }

}

class Program
{
    static void Main(string[] args)
    {
        MatrixLong mat1 = new MatrixLong(2, 2, 5);
        MatrixLong mat2 = new MatrixLong(2, 2, 3);

        MatrixLong mat3 = mat1 + mat2;
        mat3.PrintElements();

        ++mat3;
        mat3.PrintElements();

        MatrixLong mat4 = new MatrixLong(2, 2);
        if (!mat4)
            Console.WriteLine("Матриця порожня.");

        Console.WriteLine("Кількість матриць: " + MatrixLong.CountMatrices());
    }
}
