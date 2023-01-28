namespace AgilePrinciplesPractice.Ch5;

/// <summary>
/// 這個類別產生使用者指定之最大範圍內的質數。
/// 使用的演算法是 Eratosthenes 篩選法。
/// 給定第一個整數陣列，其內容由2開始遞增：
/// 找第一個尚未被劃掉的整數，去劃掉他的所有倍數。
/// 如此反覆執行，直到陣列中再也找不到最多的倍數。
/// </summary>
public static class PrimeGeneratorV2
{
    /// <summary>
    /// 是否為質數
    /// </summary>
    private static bool[] isCrossed;

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

        InitializeArrayOfIntegers(maxValue);
        CrossOutMultiples();
        PutUncrossedIntegersIntoResult();

        return result;
    }

    /// <summary>
    /// 初始化統計陣列
    /// </summary>
    /// <param name="maxValue">最大值</param>
    private static void InitializeArrayOfIntegers(int maxValue)
    {
        isCrossed = new bool[maxValue + 1];

        // ??
        // for (int i = 2; i < isCrossed.Length; i++)
        //     isCrossed[i] = false;
    }

    /// <summary>
    /// 篩掉倍數項目
    /// </summary>
    private static void CrossOutMultiples()
    {
        int maxPrimeFactor = CalcMaxPrimeFactor();
        for (int num = 2; num < maxPrimeFactor + 1; num++)
        {
            if (NoCrossed(num))
                CrossOutMultiplesOf(num);
        }
    }

    /// <summary>
    /// 計算最大質因數
    /// </summary>
    private static int CalcMaxPrimeFactor()
        => Convert.ToInt32(Math.Sqrt(isCrossed.Length));

    /// <summary>
    /// 篩掉指定數的倍數項目
    /// </summary>
    /// <param name="num"></param>
    private static void CrossOutMultiplesOf(int num)
    {
        for (int multiple = 2 * num; multiple < isCrossed.Length; multiple += num)
            isCrossed[multiple] = true; // 倍數不是質數
    }

    /// <summary>
    /// 確定指定數是否為質數
    /// </summary>
    /// <param name="num">指定數</param>
    private static bool NoCrossed(int num)
        => isCrossed[num] == false;

    /// <summary>
    /// 整理出未為質數項目到輸出結果
    /// </summary>
    private static void PutUncrossedIntegersIntoResult()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int num = 2, j = 0; num < isCrossed.Length; num++)
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
        for (int num = 2; num < isCrossed.Length; num++)
        {
            if (NoCrossed(num))
                count++;
        }

        return count;
    }
}