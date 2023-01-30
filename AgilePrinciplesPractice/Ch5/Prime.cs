namespace AgilePrinciplesPractice.Ch5;

/// <summary>
/// 質數
/// </summary>
/// <remarks>自我練習版本</remarks>
public static class Primes
{
    /// <summary>
    /// 產生最大範圍內的質數
    /// </summary>
    /// <param name="maxValue"></param>
    /// <remark>
    /// 使用的演算法是 Eratosthenes 篩選法。
    /// 給定第一個整數陣列，其內容由2開始遞增：
    /// 找第一個尚未被劃掉的整數，去劃掉他的所有倍數。
    /// 如此反覆執行，直到陣列中再也找不到最多的倍數。
    /// </remark>
    public static int[] GenerateNumbers(int maxValue)
    {
        if (maxValue < 2)
            return Array.Empty<int>();

        var crossArray = new bool[maxValue + 1]; // 0...max

        MarkAllMultiple(crossArray);

        return PickUpPrimes(crossArray);
    }

    /// <summary>
    /// 取出所有質數項目
    /// </summary>
    /// <param name="crossArray"></param>
    private static int[] PickUpPrimes(bool[] crossArray)
    {
        var primes = new List<int>();

        for (int num = 2; num < crossArray.Length; num++)
        {
            if (!crossArray[num])
                primes.Add(num);
        }

        return primes.ToArray();
    }

    /// <summary>
    /// 標示出所有倍數項目
    /// </summary>
    /// <param name="crossArray"></param>
    private static void MarkAllMultiple(bool[] crossArray)
    {
        var maxCheckNumber = (int)Math.Sqrt(crossArray.Length);

        // 0, 1 跳過，2, 3一定是質數，從2的倍數開始標記
        for (int num = 2; num <= maxCheckNumber; num++)
        {
            if (!crossArray[num])
                SetMultipleIsCross(crossArray, num);
        }
    }

    /// <summary>
    /// 標示指定數倍數項目
    /// </summary>
    /// <param name="crossArray"></param>
    /// <param name="num"></param>
    private static void SetMultipleIsCross(bool[] crossArray, int num)
    {
        for (int i = num * 2; i < crossArray.Length; i += num)
            if (!crossArray[i]) crossArray[i] = true;
    }
}