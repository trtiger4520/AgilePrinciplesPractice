
namespace AgilePrinciplesPractice.Ch5;

/// <summary>
/// 產生使用者指定之最大範圍內的質數
/// <remark>
/// 這個類別產生使用者指定之最大範圍內的質數。
/// 使用的演算法是 Eratosthenes 篩選法。
///
/// Eratosthenes，生於西元前276年利比亞的 Cyrene，西元前194年逝世於亞歷山大。
/// 他是第一個計算地球周長的人，也因研究考慮閏年的立法和掌管亞歷山大圖書館而聞名。
///
/// 這個演算法非常簡單。先給定一個整數陣列，其中由2開始遞增，先劃掉2的倍數。
/// 然後找下一個尚未被劃掉的整數，去掉他的所有倍數。如此反覆執行到傳入之最大平方根為止。
/// </remark>
/// author: Robert C. Martin
/// </summary>
public static class GeneratorPrime
{
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue >= 2)
        {
            // 宣告
            int s = maxValue + 1; // 陣列大小
            bool[] f = new bool[s];
            int i;

            // 將陣列元素初始為true
            for (i = 0; i < s; i++)
                f[i] = true;

            // 去掉已知的非質數
            f[0] = f[1] = false;

            // sieve (篩選：過濾)
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (f[i])
                {
                    for (j = 2 * i; j < s; j += i)
                        f[j] = false; // 倍數不是質數
                }
            }

            // 有多少個質數?
            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (f[i])
                    count++;
            }

            int[] primes = new int[count];

            // 把質數轉移到結果陣列中
            for (i = 0, j = 0; i < s; i++)
            {
                if (f[i])
                    primes[j++] = i;
            }

            return primes; // 傳回primes結果陣列
        }
        else
        {
            return Array.Empty<int>();
        }
    }
}

/// <summary>
/// 產生質數程式
/// </summary>
public class PrimeGenerator
{
    private static bool[] crossedOut;
    private static int[] result;

    /// <summary>
    /// 產生一個包含質數的陣列
    /// </summary>
    /// <param name="maxValue">產生的最大值</param>
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
            return Array.Empty<int>(); //若輸入不合理值，則回傳空陣列

        UncrossIntegersUpTo(maxValue);
        CrossOutMultiples();
        PutUncrossedIntegersIntoResult();
        return result;
    }

    private static void PutUncrossedIntegersIntoResult()
    {
        result = new int[NumberOfUncrossedIntegers()];
        for (int j = 0, i = 2; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
            {
                result[j++] = i;
            }
        }
    }

    private static int NumberOfUncrossedIntegers()
    {
        int count = 0;
        for (int i = 2; i < crossedOut.Length; i++)
        {
            if (NotCrossed(i))
            {
                count++;
            }
        }

        return count;
    }

    private static void CrossOutMultiples()
    {
        int limit = DetermineIterationLimit();
        for (int i = 2; i <= limit; i++)
        {
            if (NotCrossed(i))
            {
                CrossOutMultiplesOf(i);
            }
        }
    }

    private static bool NotCrossed(int i)
    {
        return crossedOut[i] == false;
    }

    private static void CrossOutMultiplesOf(int i)
    {
        for (int multiple = 2 * i; multiple < crossedOut.Length; multiple += i)
        {
            crossedOut[multiple] = true;
        }
    }

    private static int DetermineIterationLimit()
    {
        double iterationLimit = Math.Sqrt(crossedOut.Length);
        return (int)iterationLimit;
    }

    private static void UncrossIntegersUpTo(int maxValue)
    {
        crossedOut = new bool[maxValue + 1];
        //陣列元素初始為true
        for (int i = 2; i < crossedOut.Length; i++)
        {
            crossedOut[i] = false;
        }
    }
}