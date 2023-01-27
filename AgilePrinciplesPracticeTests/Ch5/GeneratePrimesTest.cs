using AgilePrinciplesPractice.Ch5;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch5;

[TestFixture]
public class GeneratePrimesTest
{
    [Test]
    public void TestPrimes()
    {
        Assert.Multiple(() =>
        {
            int[] nullArray = GeneratorPrime.GeneratePrimeNumbers(0);
            Assert.That(nullArray, Has.Length.EqualTo(0));

            int[] minArray = GeneratorPrime.GeneratePrimeNumbers(2);
            Assert.That(minArray, Has.Length.EqualTo(1));
            Assert.That(minArray[0], Is.EqualTo(2));

            int[] threeArray = GeneratorPrime.GeneratePrimeNumbers(3);
            Assert.That(threeArray, Has.Length.EqualTo(2));
            Assert.That(threeArray[0], Is.EqualTo(2));
            Assert.That(threeArray[1], Is.EqualTo(3));

            int[] centArray = GeneratorPrime.GeneratePrimeNumbers(100);
            Assert.That(centArray, Has.Length.EqualTo(25));
            Assert.That(centArray[24], Is.EqualTo(97));
        });
    }

    public void TestExhaustive()
    {
        for (int i = 2; i < 500; i++)
        {
            VerifyPrimeList(GeneratorPrime.GeneratePrimeNumbers(i));
        }
    }

    private void VerifyPrimeList(int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            VerifyPrime(list[i]);
        }
    }

    private void VerifyPrime(int n)
    {
        for (int factor = 2; factor < n; factor++)
        {
            Assert.IsTrue(n % factor != 0);
        }
    }
}