namespace DataStructureLibrary
{
    public class ThreeSum
    {
        public static int CountIntegers(int[] values)
        {
            int nValue = values.Length;
            int counter = 0;

            // 1,3,-2,1,-3,0,2

            //1
            for (int i = 0; i < nValue; i++)
            {
                //3
                for (int j = i + 1; j < nValue; j++)
                {

                    //-2
                    for (int k = j + 1; k < nValue; k++)
                    {
                        //1+3-2
                        if (IsSumOfThreeValuesEqualToZero(values, i, j, k))
                        {
                            counter++;
                        }
                    }
                }
            }

            return counter;

            static bool IsSumOfThreeValuesEqualToZero(int[] values, int i, int j, int k)
            {
                return values[i] + values[j] + values[k] == 0;
            }
        }
    }
}
