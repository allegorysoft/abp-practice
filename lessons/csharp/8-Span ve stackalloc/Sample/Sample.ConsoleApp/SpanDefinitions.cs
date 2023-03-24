﻿using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Sample.ConsoleApp;

public class SpanDefinitions
{
    public static void Do()
    {
        ValueTypeBehaviour();
        ReferenceTypeBehaviour();
    }

    static void CreateSpan()
    {
        var array = new byte[] { 1, 2, 3, 4, 5 };
        Span<byte> arraySpan = array;
        //var arraySpan =  new Span<byte>(array, 1, 2);
        //var arraySpan = array.AsSpan(1, 2);
        var arraySpan2 = arraySpan.Slice(1, 2);
        arraySpan.Fill(5);
        arraySpan.Clear();

        Span<byte> stackSpan = stackalloc byte[] { 1, 2, 3, 4, 5 };
    }

    static void ValueTypeBehaviour()
    {
        int[] array = Enumerable.Range(1, 5).ToArray();
        int[] array2 = array[1..3];
        array2[0] = 500;
        Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", array[1], array2[0]);

        int[] arraySpan = Enumerable.Range(1, 5).ToArray();
        Span<int> arraySpan2 = arraySpan.AsSpan()[1..3]; //Diğer yöntem: arraySpan.AsSpan(1,2);
        arraySpan2[0] = 500;
        Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", arraySpan[1], arraySpan2[0]);
    }

    static void ReferenceTypeBehaviour()
    {
        IntWrapper[] array = IntWrapper.Create(5).ToArray();
        IntWrapper[] array2 = array[1..3];
        array2[0] = new IntWrapper(500);
        Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", array[1].Number, array2[0].Number);

        IntWrapper[] arraySpan = IntWrapper.Create(5).ToArray();
        Span<IntWrapper> arraySpan2 = arraySpan.AsSpan()[1..3]; //Diğer yöntem: arraySpan.AsSpan(1,2);
        arraySpan2[0] = new IntWrapper(500);
        Console.WriteLine("İlk dizi: {0}, İkinci dizi: {1}", arraySpan[1].Number, arraySpan2[0].Number);
    }
}

[MemoryDiagnoser]
public class SpanBenchmark
{
    private readonly int[] _numbers = Enumerable.Range(1, 5).ToArray();

    [Benchmark]
    public void GetSubArray()
    {
        int[] numbers = _numbers[1..3];
        //RuntimeHelpers.GetSubArray(_numbers, 1..3);
    }

    [Benchmark]
    public void AsSpan()
    {
        Span<int> span = _numbers.AsSpan()[1..3];
    }
}