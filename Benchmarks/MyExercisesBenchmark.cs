#define MaskifyBenchmraks
#define GimmeBecnhmark
#define CounterBitsBecnhmrak
#define PersistenceBenchmark

using BenchmarkDotNet.Attributes;
using CodeWarsExc;

namespace Benchmarks;

[MemoryDiagnoser]
[RankColumn]
public class MyExercisesBenchmark
{
    #region Maskify
    #if MaskifyBenchmraks

    [Benchmark(Baseline = true)]
    public void MaskifyTestWithFourLengthInput()
    {
        var result = Exercises.Maskify("test");
    }
    
    [Benchmark]
    public void MaskifyTestWithGreaterFourInput()
    {
        var result = Exercises.Maskify("46982377495793745923475293845");
    }
    
    [Benchmark]
    public void MaskifyWithConcatTestWithGreaterFourInput()
    {
        var result = Exercises.MaskifyWithConcat("46982377495793745923475293845");
    }
    
    [Benchmark]
    public void MaskifyWithSubstringTestWithGreaterFourInput()
    {
        var result = Exercises.MaskifyWithSubstring("46982377495793745923475293845");
    }

    #endif
    #endregion

    #region Gimme
    #if GimmeBecnhmark
    
    [Benchmark(Baseline = true)]
    public void GimmeWithCycle()
    {
        var result = Exercises.Gimme(new double[] { 3, 5, 1 });
    }
    
    [Benchmark]
    public void GimmeWithIndexOf()
    {
        var result = Exercises.GimmeWithIndexOf(new double[] { 3, 5, 1 });
    }
    
    #endif
    #endregion

    #region CounterBits
    #if CounterBitsBecnhmrak
    
    [Benchmark(Baseline = true)]
    [Arguments(0)]
    [Arguments(123)]
    [Arguments(int.MaxValue)]
    public void CounterBits(int number)
    {
        var result = Exercises.CountBits(number);
    }
    
    [Benchmark]
    [Arguments(0)]
    [Arguments(123)]
    [Arguments(int.MaxValue)]
    public void CounterBitsWithoutCycle(int number)
    {
        var result = Exercises.CountBitsWithoutCycle(number);
    }
    
    #endif
    #endregion

    #region Persistence
    #if PersistenceBenchmark
    
    
    [Benchmark]
    [Arguments(39)]
    [Arguments(4)]
    [Arguments(25)]
    [Arguments(999)]
    public void PersistenceOtherSolution_Benchmark(long number)
    {
        var result = Exercises.PersistenceOtherSolution(number);
    }

    [Benchmark]
    [Arguments(39)]
    [Arguments(4)]
    [Arguments(25)]
    [Arguments(999)]
    public void PersistenceWithRecursiveSolution_Benchmark(long number)
    {
        var result = Exercises.PersistenceWithRecursiveSolution(number);
    }
    
    #endif
    #endregion
}