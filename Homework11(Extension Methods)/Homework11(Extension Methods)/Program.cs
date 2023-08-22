using System;
using System.Text;
namespace Homework11_Extension_Methods_
{
    public class LargeNumber
    {
        private string value;

        public LargeNumber(string initialValue)
        {
            value = initialValue;
        }

        public static LargeNumber Add(LargeNumber num1, LargeNumber num2)
        {
            // Implement addition logic here
            // You would need to handle carrying over digits
            // and make sure both numbers have the same length
            // You can use StringBuilder to build the result string

            // Example logic (this is a simplified version and may need adjustments):
            if (num1.value.Length < num2.value.Length)
            {
                LargeNumber temp = num1;
                num1 = num2;
                num2 = temp;
            }

            // Pad num2 with leading zeros
            int lengthDiff = num1.value.Length - num2.value.Length;
            string paddedNum2 = num2.value.PadLeft(num1.value.Length, '0');

            StringBuilder result = new StringBuilder();
            int carry = 0;
            for (int i = num1.value.Length - 1; i >= 0; i--)
            {
                int digitSum = (int)char.GetNumericValue(num1.value[i]) + (int)char.GetNumericValue(paddedNum2[i]) + carry;
                carry = digitSum / 10;
                result.Insert(0, (digitSum % 10).ToString());
            }

            if (carry > 0)
                result.Insert(0, carry.ToString());

            return new LargeNumber(result.ToString());
        }
        public static LargeNumber Subtract(LargeNumber num1, LargeNumber num2)
        {
            // Ensure num1 is greater or equal to num2
            if (num1.value.Length < num2.value.Length)
            {
                LargeNumber temp = num1;
                num1 = num2;
                num2 = temp;
            }

            // Pad num2 with leading zeros
            string paddedNum2 = num2.value.PadLeft(num1.value.Length, '0');

            // Implement subtraction logic here
            StringBuilder result = new StringBuilder();
            int borrow = 0;
            for (int i = num1.value.Length - 1; i >= 0; i--)
            {
                int digitDiff = (int)char.GetNumericValue(num1.value[i]) - (int)char.GetNumericValue(paddedNum2[i]) - borrow;
                if (digitDiff < 0)
                {
                    digitDiff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                result.Insert(0, digitDiff.ToString());
            }
            result = result.Remove(0, result.ToString().IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' }));

            return new LargeNumber(result.ToString());
        }

        public override string ToString()
        {
            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LargeNumber num1 = new LargeNumber("12345678901234567890");
            LargeNumber num2 = new LargeNumber("12345678901234567780");

            LargeNumber sum = LargeNumber.Add(num1, num2);
            LargeNumber diff = LargeNumber.Subtract(num1, num2);

            Console.WriteLine("Number 1: " + num1);
            Console.WriteLine("Number 2: " + num2);
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Difference: " + diff);
        }
    }
}

