using System.Text;

namespace CodeWarsExc;

public static class Exercises
{
    #region 5kyu

    /// <summary>
    /// Method for validate balance brackets
    /// </summary>
    /// <param name="input">have length range 0..100</param>
    /// <returns>bracket balance state</returns>
    /// <remarks>
    /// "()"            => true<br/>
    /// "((()))()"      => true<br/>
    /// "()()("         => false<br/>
    /// ""              => true<br/>
    /// </remarks>
    public static bool ValidParentheses(string input)
    {
        var balanceBrackets = 0;
        
        foreach (var t in input)
        {
            switch (t)
            {
                case '(':
                    balanceBrackets++;
                    break;
                case ')':
                    balanceBrackets--;
                    if (balanceBrackets < 0)
                        return false;
                    break;
            }
        }

        return balanceBrackets == 0;
        
    }

    /// <summary>
    /// Method to mask all except the last four digits with use string builder
    /// </summary>
    /// <param name="cc">credit card number or cardholder name</param>
    /// <returns>returned masked string</returns>
    /// <remarks>
    /// "2202201733027005"  => "############7005"<br/>
    /// "289582"            => "##9582"<br/>
    /// "1"                 => "1"<br/>
    /// ""                  => ""<br/>
    /// "James"             => "#ames"<br/>
    /// </remarks>
    public static string Maskify(string cc)
    {
        if (cc.Length <= 4)
            return cc;
        var stringBuilder = new StringBuilder();
        for (var index = 0; index < cc.Length; index++)
        {
            if (index >= cc.Length - 4)
            {
                stringBuilder.Append(cc[index]);
                continue;
            }
            stringBuilder.Append('#');
        }

        return stringBuilder.ToString();
    }
    
    /// <summary>
    /// Method to mask all except the last four digits with use concat
    /// </summary>
    /// <param name="cc">credit card number or cardholder name</param>
    /// <returns>returned masked string</returns>
    /// <remarks>
    /// "2202201733027005"  => "############7005"<br/>
    /// "289582"            => "##9582"<br/>
    /// "1"                 => "1"<br/>
    /// ""                  => ""<br/>
    /// "James"             => "#ames"<br/>
    /// </remarks>
    public static string MaskifyWithConcat(string cc)
    {
        if (cc.Length <= 4)
            return cc;
        var result = string.Empty;
        for (var index = 0; index < cc.Length; index++)
        {
            if (index >= cc.Length - 4)
            {
                result += '#';
                continue;
            }

            result += cc[index];
        }

        return result;
    }

    /// <summary>
    /// Method to mask all except the last four digits.<br/>
    /// This method faster then all
    /// </summary>
    /// <param name="cc">credit card number or cardholder name</param>
    /// <returns>returned masked string</returns>
    /// <remarks>
    /// "2202201733027005"  => "############7005"<br/>
    /// "289582"            => "##9582"<br/>
    /// "1"                 => "1"<br/>
    /// ""                  => ""<br/>
    /// "James"             => "#ames"<br/>
    /// </remarks>
    public static string MaskifyWithSubstring(string cc)
    {
        if (cc.Length <= 4)
            return cc;

        // return cc[^4..].PadLeft(cc.Length, '#');
        // that's expressions equals
        return cc.Substring(cc.Length - 4).PadLeft(cc.Length, '#');
    }
    
    #endregion

    #region 6kyu

    /// <summary>
    /// Method for counting all bits equal to one
    /// </summary>
    /// <param name="n">range of number from 0 to int.MaxValue</param>
    /// <returns>Count of bits equal to one</returns>
    /// <remarks>
    /// 0               => 0<br/>
    /// 123             => 6<br/>
    /// int.MaxValue    => 31<br/>
    /// </remarks>
    [Obsolete($"Use {nameof(CountBitsWithoutCycle)} method instead this.")]
    public static int CountBits(int n)
    {
        var result = Convert.ToString(n, 2).Count(x => x == '1');
        return result;

    }
    
    /// <summary>
    /// Method for counting all bits equal to one.<br/>
    /// Faster method with zero memory allocation.
    /// </summary>
    /// <param name="n">range of number from 0 to int.MaxValue</param>
    /// <returns>Count of bits equal to one</returns>
    /// <remarks>
    /// 0               => 0<br/>
    /// 123             => 6<br/>
    /// int.MaxValue    => 31<br/>
    /// </remarks>
    public static int CountBitsWithoutCycle(int n)
    {
        long v = (n & 0b1010101010101010101010101010101) + ((n & 0b10101010101010101010101010101010) >> 0b1);
        v = (v & 0b110011001100110011001100110011) + ((v & 0b11001100110011001100110011001100) >> 0b10);
        v = (v & 0b1111000011110000111100001111) + ((v & 0b11110000111100001111000011110000) >> 0b100);
        return (int) v % 255;
    }

    /// <summary>
    /// Method for to return counts of multiplies
    /// </summary>
    /// <param name="n">Positive number</param>
    /// <returns>Return counts of multiplies</returns>
    /// <remarks>
    /// 39      => 3  ->  (3 * 9 = 27 -> 2*7 = 14 -> 1 * 4 = 4)<br/>
    /// 4       => 0  ->  (because 4 don't have one more digit)<br/>
    /// 25      => 2  ->  (2 * 5 = 10 -> 1 * 0  = 0)<br/>
    /// 999     => 4  ->  (9 * 9 * 9 = 729 -> 7*2*9 = 126 -> 1*2*6 = 12 -> 1 * 2 = 2)<br/>
    /// </remarks>
    [Obsolete("not good solution")]
    public static int PersistenceMySolution(long n)
    {
        // BUG: Infinity cycle
        var counter = 0;
        var number = n;
        var listOfDigits = new LinkedList<long>();
        
        while (number > 10)
        {
            number %= 10;
            listOfDigits.AddLast(number);
        }
        while (listOfDigits.Count > 0)
        {
            counter++;
            
        }
        return counter;
    }
    
    /// <inheritdoc cref="PersistenceMySolution"/>
    public static int PersistenceOtherSolution(long n) {
        int count = 0;

        while (n >= 10) {
            n = GetMultiplyOfDigits(n);
            count++;
        }

        return count;
    }
    
    public static int PersistenceBetterSolution(long n) {
        if (n / 10 == 0)
            return 0;

        long multiplyOfDigits = 1;

        for (long i = n; n != 0; n /= 10) {
            multiplyOfDigits *= (n % 10);
        }

        return PersistenceBetterSolution(multiplyOfDigits) + 1;
    }

    private static long GetMultiplyOfDigits(long n) {
        long result = n % 10;

        while ((n /= 10) > 0) {
            result = result * (n % 10);
        }

        return result;
    }
    
    #endregion
    
    #region 7kyu

    public static int Gimme(double[] inputArray)
    {
        var min = inputArray.Min();
        var max = inputArray.Max();
        var result = 0;
        
        for (var i = 0; i < inputArray.Length; i++)
        {
            if (inputArray[i] > min && inputArray[i] < max)
            {
                result = i;
            }
        }

        return result;
    }
    
    public static int GimmeWithIndexOf(double[] inputArray)
    {
        return Array.IndexOf(inputArray, inputArray.OrderBy(x => x).ToArray()[1]);
    }
    
    #endregion
}