using BenchmarkDotNet.Attributes;
using CodeWarsExc;

namespace Benchmarks;

[MemoryDiagnoser]
[RankColumn]
public class MyExercisesBenchmark
{
    // [Benchmark]
    public void MaskifyTestWithFourLengthInput()
    {
        var result = Exercises.Maskify("test");
    }
    
    // [Benchmark]
    public void MaskifyTestWithGreaterFourInput()
    {
        var result = Exercises.Maskify("46982377495793745923475293845");
    }
    
    // [Benchmark]
    public void MaskifyWithConcatTestWithGreaterFourInput()
    {
        var result = Exercises.MaskifyWithConcat("46982377495793745923475293845");
    }
    
    // [Benchmark]
    public void MaskifyWithSubstringTestWithGreaterFourInput()
    {
        var result = Exercises.MaskifyWithSubstring("46982377495793745923475293845");
    }
    // [Benchmark]
    public void GimmeWithCycle()
    {
        var result = Exercises.Gimme(new double[] { 3, 5, 1 });
    }
    
    // [Benchmark]
    public void GimmeWithIndexOf()
    {
        var result = Exercises.GimmeWithIndexOf(new double[] { 3, 5, 1 });
    }

    // TODO: run and check this bench
    [Benchmark]
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
}