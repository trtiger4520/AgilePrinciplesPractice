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
            int[] nullArray = GeneratorPrimes.GeneratePrimeNumbers(0);
            Assert.That(nullArray, Has.Length.EqualTo(0));

            int[] minArray = GeneratorPrimes.GeneratePrimeNumbers(2);
            Assert.That(minArray, Has.Length.EqualTo(1));
            Assert.That(minArray[0], Is.EqualTo(2));

            int[] threeArray = GeneratorPrimes.GeneratePrimeNumbers(3);
            Assert.That(threeArray, Has.Length.EqualTo(2));
            Assert.That(threeArray[0], Is.EqualTo(2));
            Assert.That(threeArray[1], Is.EqualTo(3));

            int[] centArray = GeneratorPrimes.GeneratePrimeNumbers(100);
            Assert.That(centArray, Has.Length.EqualTo(25));
            Assert.That(centArray[24], Is.EqualTo(97));
        });
    }

    [Test]
    public void TestPrimesV2()
    {
        Assert.Multiple(() =>
        {
            int[] nullArray = PrimeGeneratorV2.GeneratePrimeNumbers(0);
            Assert.That(nullArray, Has.Length.EqualTo(0));

            int[] minArray = PrimeGeneratorV2.GeneratePrimeNumbers(2);
            Assert.That(minArray, Has.Length.EqualTo(1));
            Assert.That(minArray[0], Is.EqualTo(2));

            int[] threeArray = PrimeGeneratorV2.GeneratePrimeNumbers(3);
            Assert.That(threeArray, Has.Length.EqualTo(2));
            Assert.That(threeArray[0], Is.EqualTo(2));
            Assert.That(threeArray[1], Is.EqualTo(3));

            int[] centArray = PrimeGeneratorV2.GeneratePrimeNumbers(100);
            Assert.That(centArray, Has.Length.EqualTo(25));
            Assert.That(centArray[24], Is.EqualTo(97));
        });
    }


    [Test]
    public void TestExhaustive()
    {
        for (int i = 2; i < 500; i++)
        {
            VerifyPrimeList(GeneratorPrimes.GeneratePrimeNumbers(i));
        }
    }

    private static void VerifyPrimeList(int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            VerifyPrime(list[i]);
        }
    }

    private static void VerifyPrime(int n)
    {
        for (int factor = 2; factor < n; factor++)
        {
            Assert.That(n % factor, Is.Not.EqualTo(0));
        }
    }
}