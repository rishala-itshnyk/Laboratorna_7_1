namespace Laboratorna_7_1
{
    public class Program
    {
        static void Main()
        {
            int Low = -12;
            int High = 37;
            int rowCount = 7;
            int colCount = 9;

            int[][] r = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
                r[i] = new int[colCount];

            Create(r, rowCount, colCount, Low, High);
            Print(r, rowCount, colCount);
            Sort(r, rowCount, colCount);
            Print(r, rowCount, colCount);

            int S = 0;
            int k = 0;

            Calc(r, rowCount, colCount, ref S, ref k);
            Console.WriteLine($"S = {S}");
            Console.WriteLine($"k = {k}");

            Print(r, rowCount, colCount);

            for (int i = 0; i < rowCount; i++)
                Array.Clear(r[i], 0, colCount);
        }

        public static void Create(int[][] r, int rowCount, int colCount, int Low, int High)
        {
            Random rand = new Random();
            for (int i = 0; i < rowCount; i++)
            for (int j = 0; j < colCount; j++)
                r[i][j] = Low + rand.Next(High - Low + 1);
        }

        public static void Print(int[][] r, int rowCount, int colCount)
        {
            Console.WriteLine();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                    Console.Write($"{r[i][j],4}");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void Change(int[][] a, int row1, int row2, int colCount)
        {
            int tmp;
            for (int j = 0; j < colCount; j++)
            {
                tmp = a[row1][j];
                a[row1][j] = a[row2][j];
                a[row2][j] = tmp;
            }
        }

        public static void Sort(int[][] r, int rowCount, int colCount)
        {
            for (int i0 = 0; i0 < rowCount - 1; i0++)
            {
                for (int i1 = 0; i1 < rowCount - i0 - 1; i1++)
                {
                    if ((r[i1][0] > r[i1 + 1][0]) ||
                        (r[i1][0] == r[i1 + 1][0] && r[i1][1] > r[i1 + 1][1]) ||
                        (r[i1][0] == r[i1 + 1][0] && r[i1][1] == r[i1 + 1][1] && r[i1][3] < r[i1 + 1][3]))
                    {
                        Change(r, i1, i1 + 1, colCount);
                    }
                }
            }
        }

        public static void Calc(int[][] r, int rowCount, int colCount, ref int S, ref int k)
        {
            S = 0;
            k = 0;
            for (int i = 0; i < rowCount; i++)
            for (int j = 0; j < colCount; j++)
                if (r[i][j] > 0 && r[i][j] % 3 != 0)
                {
                    S += r[i][j];
                    k++;
                    r[i][j] = 0;
                }
        }
    }
}