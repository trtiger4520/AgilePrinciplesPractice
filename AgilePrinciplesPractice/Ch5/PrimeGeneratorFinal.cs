namespace AgilePrinciplesPractice.Ch5;

/// <summary>
/// 這個類別產生使用者指定之最大範圍內的質數。
/// 使用的演算法是 Eratosthenes 篩選法。
/// 給定第一個整數陣列，其內容由2開始遞增：
/// 找第一個尚未被劃掉的整數，去劃掉他的所有倍數。
/// 如此反覆執行，直到陣列中再也找不到最多的倍數。
/// </summary>
public static class PrimeGeneratorFinal
{
    /// <summary>
    /// 是否為質數
    /// </summary>
    private static bool[] crossedOut;

    /// <summary>
    /// 回應內容
    /// </summary>
    private static int[] result;

    /// <summary>
    /// 產生指定範圍內的質數
    /// </summary>
    /// <param name="maxValue">最大範圍</param>
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
        {
            return Array.Empty<int>();
        }

        UncrossIntegersUpTo(maxValue);
        CrossOutMultiples();
        PutUncrossedIntegersIntoResult();

        return result;
    }

    /// <summary>
    /// 初始化統計陣列
    /// </summary>
    /// <param name="maxValue">最大值</param>
    private static void UncrossIntegersUpTo(int maxValue)
    {
        crossedOut = new bool[maxValue + 1];
    }

    /// <summary>
    /// 篩掉倍數項目
    /// </summary>
    private static void CrossOutMultiples()
    {
        int limit = DetermineIterationLimit();
        for (int num = 2; num <= limit; num++)
        {
            if (NoCrossed(num))
                CrossOutMultiplesOf(num);
        }
    }

    /// <summary>
    /// 計算最大質因數
    /// <remark>
    /// 陣列中的每個倍數都有一個小於或等於陣列大小平方根質因數，
    /// 因此我們不用劃掉那些比這平方根還要大的倍數
    /// </remark>
    /// </summary>
    private static int DetermineIterationLimit()
        => Convert.ToInt32(Math.Sqrt(crossedOut.Length));

    /// <summary>
    /// 篩掉指定數的倍數項目
    /// </summary>
    /// <param name="num"></param>
    private static void CrossOutMultiplesOf(int num)
    {
        for (int multiple = 2 * num; multiple < crossedOut.Length; multiple += num)
            crossedOut[multiple] = true; // 倍數不是質數
    }

    /// <summary>
    /// 確定指定數是否為質數
    /// </summary>
    /// <param name="num">指定數</param>
    private static bool NoCrossed(int num)
        => crossedOut[num] == false;

    /// <summary>
    /// 整理出未為質數項目到輸出結果
    /// </summary>
    private static void PutUncrossedIntegersIntoResult()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int num = 2, j = 0; num < crossedOut.Length; num++)
        {
            if (NoCrossed(num))
                result[j++] = num;
        }
    }

    /// <summary>
    /// 統計質數數量
    /// </summary>
    private static int NumberOfUncrossedIntegers()
    {
        int count = 0;
        for (int num = 2; num < crossedOut.Length; num++)
        {
            if (NoCrossed(num))
                count++;
        }

        return count;
    }
}
