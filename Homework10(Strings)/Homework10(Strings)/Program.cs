using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Homework10_Strings_
{
    internal class Program
    {
        public static string Calculate(string str)
        {
            
            var charsToRemove = new string[]{"(",")"," "};
            foreach (var c in charsToRemove)
            {
                str=str.Replace(c, string.Empty);
            }
            var subs = str.Split('+', '-', '*', '/');
            var operandsRegex = new Regex(@"[-+*/]");
            var operands = new List<string>();
            var match = operandsRegex.Matches(str);
            
            foreach (var operand in match) operands.Add(operand.ToString());

            var expression = new List<string>();
            for (var i = 0; i < subs.Length; i++)
            {
                expression.Add(subs[i]);
                if (i <= operands.Count - 1)
                    expression.Add(operands[i]);
            }

            //foreach (var VARIABLE in expression) Console.Write(VARIABLE);
            double calcResult = 0;
            while (expression.Contains("*"))
                for (var i = 0; i < expression.Count; i++)
                    if (expression[i] == "*")
                    {
                        calcResult = double.Parse(expression[i - 1]) * double.Parse(expression[i + 1]);
                        expression.RemoveAt(i - 1);
                        expression.RemoveAt(i);
                        expression[i - 1] = calcResult.ToString();
                    }

            while (expression.Contains("/"))
                for (var i = 0; i < expression.Count; i++)
                    if (expression[i] == "/")
                    {
                        calcResult = double.Parse(expression[i - 1]) / double.Parse(expression[i + 1]);
                        expression.RemoveAt(i - 1);
                        expression.RemoveAt(i);
                        expression[i - 1] = calcResult.ToString();
                    }


            while (expression.Contains("-"))
                for (var i = 0; i < expression.Count; i++)
                    if (expression[i] == "-")
                    {
                        expression[i+1] ="-" + expression[i + 1];
                        expression[i] = "+";
                    }
            //foreach (var VARIABLE in expression) Console.WriteLine(VARIABLE);
            while (expression.Contains("+"))
                for (var i = 0; i < expression.Count; i++)
                    if (expression[i] == "+")
                    {
                        calcResult = double.Parse(expression[i - 1]) + double.Parse(expression[i + 1]);
                        expression.RemoveAt(i - 1);
                        expression.RemoveAt(i);
                        expression[i - 1] = calcResult.ToString();
                    }
            return expression[0];
        }

        public static void RemoveRoundBracketsAndCalculate(string str)
        {
            Regex regex = new Regex(@"(?:\()([^\()\)]+)(?:\))");
            List<string> _matchList = new List<string>();
            while (str.Contains("("))
            {


                var matches = regex.Matches(str);
                foreach (var result in matches)
                {
                    _matchList.Add(result.ToString());
                }

                foreach (var item in _matchList)
                {
                    //Console.WriteLine(item);
                    var counter = Calculate(item);
                    //Console.WriteLine(counter);
                    str = str.Replace(item, counter);

                }
            }
            Console.WriteLine("Result: " + Calculate(str));
        }
        static void Main(string[] args)
        {
            string expr =
                   "((50 + 25) * 2 - 40) / 5 + (10 * 3 - 15) + 30 - (8 + 4) * 2 + 60 / 2 - 10 + (12 * 2 - 18) - 5 + 40 * 1 + (16 - 8) / 2 + 25 - (30 + 15) * 1 + 50 / 2 - (6 * 3 - 12) + 15";
            Console.WriteLine(expr);
            var t1 = Stopwatch.StartNew();
            t1.Start();
            RemoveRoundBracketsAndCalculate(expr);
            t1.Stop();
            Console.WriteLine("Time: " +  t1.Elapsed.Milliseconds + "ms");
        }
    }
}
