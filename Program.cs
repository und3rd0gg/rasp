public static int FindElement(int[] array, int element)
{
    for (var i = 0; i < array.Length; i++)
        if (array[i] == element)
            return i;

    return -1;
}