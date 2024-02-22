using System;
using System.IO;
using NUnit.Framework;

namespace Laboratorna_7_1.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCreate()
        {
            const int rowCount = 7;
            const int colCount = 9;
            int[][] r = new int[rowCount][];
            for (int i = 0; i < rowCount; ++i)
                r[i] = new int[colCount]; 

            Program.Create(r, rowCount, colCount, -12, 37);

            for (int i = 0; i < rowCount; ++i)
            for (int j = 0; j < colCount; ++j)
                Assert.IsTrue(r[i][j] >= -12 && r[i][j] <= 37);
        }

        [Test]
        public void TestSort()
        {
            const int rowCount = 7;
            const int colCount = 9;
            int[][] r = new int[rowCount][];
            for (int i = 0; i < rowCount; ++i)
                r[i] = new int[colCount];

            int[][] testArray = new int[][]
            {
                new int[] {5, 3, 4, 2, 1, 6, 8, 7, 9},
                new int[] {1, 2, 3, 4, 5, 6, 8, 7, 9},
                new int[] {6, 5, 4, 3, 2, 1, 8, 7, 9},
                new int[] {4, 3, 6, 5, 1, 2, 8, 7, 9},
                new int[] {1, 2, 3, 4, 5, 6, 8, 7, 9},
                new int[] {6, 5, 4, 3, 2, 1, 8, 7, 9},
                new int[] {5, 3, 4, 2, 1, 6, 8, 7, 9},
            };

            for (int i = 0; i < rowCount; ++i)
                r[i] = (int[])testArray[i].Clone();

            Program.Sort(r, rowCount, colCount);

            for (int i = 0; i < rowCount - 1; ++i)
            {
                bool condition =
                    (r[i][0] < r[i + 1][0]) ||
                    (r[i][0] == r[i + 1][0] && r[i][1] < r[i + 1][1]) ||
                    (r[i][0] == r[i + 1][0] && r[i][1] == r[i + 1][1] && r[i][3] >= r[i + 1][3]);

                Assert.IsTrue(condition);
            }
        }

        [Test]
        public void TestPrint()
        {
            const int rowCount = 7;
            const int colCount = 9;
            int[][] r = new int[rowCount][];
            for (int i = 0; i < rowCount; ++i)
                r[i] = new int[colCount];

            int[][] testArray = new int[][]
            {
                new int[] {1, 2, 3, 4, 5, 6, 8, 7, 9},
                new int[] {7, 8, 9, 10, 11, 12, 8, 7, 9},
                new int[] {13, 14, 15, 16, 17, 18, 8, 7, 9},
                new int[] {19, 20, 21, 22, 23, 24, 8, 7, 9},
                new int[] {25, 26, 27, 28, 29, 30, 8, 7, 9},
                new int[] {31, 32, 33, 34, 35, 36, 8, 7, 9},
                new int[] {37, 38, 39, 40, 41, 42, 8, 7, 9},
            };

            for (int i = 0; i < rowCount; ++i)
                r[i] = (int[])testArray[i].Clone();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Print(r, rowCount, colCount);
                Console.SetOut(Console.Out);

                string printedOutput = sw.ToString();
                string expectedOutput = "\n   1   2   3   4   5   6   8   7   9\n"
                                        + "   7   8   9  10  11  12   8   7   9\n"
                                        + "  13  14  15  16  17  18   8   7   9\n"
                                        + "  19  20  21  22  23  24   8   7   9\n"
                                        + "  25  26  27  28  29  30   8   7   9\n"
                                        + "  31  32  33  34  35  36   8   7   9\n"
                                        + "  37  38  39  40  41  42   8   7   9\n\n";
                Assert.AreEqual(expectedOutput, printedOutput);
            }
        }

        [Test]
        public void TestCalc()
        {
            const int rowCount = 7;
            const int colCount = 9;
            int[][] r = new int[rowCount][];
            for (int i = 0; i < rowCount; ++i)
                r[i] = new int[colCount];

            int[][] testArray = new int[][]
            {
                new int[] {1, 2, 3, 4, 5, 6, 8, 7, 9},
                new int[] {-1, -2, -3, -4, -5, -6, 8, 7, 9},
                new int[] {0, 0, 0, 0, 0, 0, 8, 7, 9},
                new int[] {1, -1, 2, -2, 3, -3, 8, 7, 9},
                new int[] {2, 4, 6, 8, 10, 12, 8, 7, 9},
                new int[] {-2, -4, -6, -8, -10, -12, 8, 7, 9},
                new int[] {1, 3, 5, 7, 9, 11, 8, 7, 9},
            };

            for (int i = 0; i < rowCount; ++i)
                r[i] = (int[])testArray[i].Clone();

            int S = 0, k = 0;
            Program.Calc(r, rowCount, colCount, ref S, ref k);

            Assert.AreEqual(S, 168);
            Assert.AreEqual(k, 28);
        }
    }
}