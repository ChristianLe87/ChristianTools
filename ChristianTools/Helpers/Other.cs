using System.Linq;
using ChristianTools.Components;
using Microsoft.Xna.Framework;

namespace ChristianTools.Helpers
{
    public partial class Other
    {
        public static T[,] Expand<T>(T[,] original, int multiply)
        {
            // From stackoverflow: https://stackoverflow.com/questions/69705678/multiply-element-in-multidimensional-array?answertab=votes#tab-top
            int sizeX = original.GetLength(0);
            int sizeY = original.GetLength(1);

            T[,] newArray = new T[sizeX * multiply, sizeY * multiply];

            for (var i = 0; i < newArray.GetLength(0); i++)
            for (var j = 0; j < newArray.GetLength(1); j++)
                newArray[i, j] = original[i / multiply, j / multiply];

            return newArray;
        }


        public static T[] FlattenArray<T>(T[,] input)
        {
            T[] result = new T[input.Length];

            int count = 0;
            for (int w = 0; w <= input.GetUpperBound(0); w++)
            for (int h = 0; h <= input.GetUpperBound(1); h++)
                result[count++] = input[w, h];

            return result;
        }


        // thanks to: https://stackoverflow.com/questions/27427527/how-to-get-a-complete-row-or-column-from-2d-array-in-c-sharp
        public static T[] GetColumn<T>(T[,] array, int columnNumber)
        {
            return Enumerable.Range(0, array.GetLength(0))
                .Select(x => array[x, columnNumber])
                .ToArray();
        }

        // thanks to: https://stackoverflow.com/questions/27427527/how-to-get-a-complete-row-or-column-from-2d-array-in-c-sharp
        public static T[] GetRow<T>(T[,] array, int rowNumber)
        {
            return Enumerable.Range(0, array.GetLength(1))
                .Select(x => array[rowNumber, x])
                .ToArray();
        }


        public static T[,] RotateArray_90_AntiClockwise<T>(T[,] array)
        {
            T[,] result = new T[array.GetLength(1), array.GetLength(0)];
            int newCol = 0;
            int newRow = 0;

            for (int col = array.GetLength(1) - 1; col >= 0; col--)
            {
                newCol = 0;
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    result[newRow, newCol] = array[row, col];
                    newCol++;
                }

                newRow++;
            }

            return result;
        }


        public static T[,] RotateArray_180_AntiClockwise<T>(T[,] array)
        {
            // todo: Do this better
            array = RotateArray_90_AntiClockwise(array);
            array = RotateArray_90_AntiClockwise(array);
            return array;
        }


        public static T[,] RotateArray_270_AntiClockwise<T>(T[,] array)
        {
            array = RotateArray_90_AntiClockwise(array);
            array = RotateArray_90_AntiClockwise(array);
            array = RotateArray_90_AntiClockwise(array);
            return array;
        }


        public static T[,] ToMultidimentional<T>(T[] array, int width, int height)
        {
            T[,] result = new T[height, width];

            int count = 0;
            for (int w = 0; w < height; w++)
            {
                for (int h = 0; h < width; h++)
                {
                    result[w, h] = array[count];
                    count++;
                }
            }

            return result;
        }

        public static void MoveTowards(Rigidbody main, Point target, int maxAproximation, float steps)
        {

            if (Vector2.Distance(main.rectangle.Center.ToVector2(), target.ToVector2()) == 0)
                return;

            if (Vector2.Distance(main.rectangle.Center.ToVector2(), target.ToVector2()) < maxAproximation)
                main.SetCenterPosition(target);


            double angleInRadians = Helpers.MyMath.GetAngleInRadians(main.rectangle.Center.ToVector2(), target.ToVector2());

            Vector2 result = Helpers.MyMath.Get_X_and_Y_BasedOnAngle_Radians(steps, angleInRadians);

            main.Move_X((int)result.X);
            main.Move_Y((int)result.Y);
        }
    }
}