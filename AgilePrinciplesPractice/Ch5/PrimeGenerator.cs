namespace AgilePrinciplesPractice.Ch5;

/// <summary>
/// 這個類別產生使用者指定之最大範圍內的質數。
/// 使用的演算法是 Eratosthenes 篩選法。
/// 給定第一個整數陣列，其內容由2開始遞增：
/// 找第一個尚未被劃掉的整數，去劃掉他的所有倍數。
/// 如此反覆執行，直到陣列中再也找不到最多的倍數。
/// </summary>
public static class PrimeGenerator
{
    private static int s;
    private static bool[] f;
    private static int[] primes;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
        {
            return Array.Empty<int>();
        }
        InitializeSieve(maxValue);
        Sieve();
        LoadPrime();
        return primes; // 傳回primes結果陣列
    }

    private static void LoadPrime()
    {
        // 有多少個質數?
        int i, j;
        int count = 0;
        for (i = 0; i < s; i++)
        {
            if (f[i])
                count++;
        }

        primes = new int[count];

        // 把質數轉移到結果陣列中
        for (i = 0, j = 0; i < s; i++)
        {
            if (f[i])
                primes[j++] = i;
        }
    }

    private static void Sieve()
    {
        // sieve (篩選：過濾)
        int i, j;
        for (i = 2; i < Math.Sqrt(s) + 1; i++)
        {
            if (f[i])
            {
                for (j = 2 * i; j < s; j += i)
                    f[j] = false; // 倍數不是質數
            }
        }
    }

    private static void InitializeSieve(int maxValue)
    {
        // 宣告
        s = maxValue + 1; // 陣列大小
        f = new bool[s];
        int i;

        // 將陣列元素初始為true
        for (i = 0; i < s; i++)
            f[i] = true;

        // 去掉已知的非質數
        f[0] = f[1] = false;
    }
}
