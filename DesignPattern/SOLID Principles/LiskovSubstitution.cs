using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.SOLID_Principles
{
    public class LiskovSubstitution
    {
        public abstract class Calculator
        {
            protected readonly int[] _numbers;

            public Calculator(int[] numbers)
            {
                _numbers = numbers;
            }

            public abstract int Calculate();
        }
        public class SumCalculator : Calculator
        {
            public SumCalculator(int[] numbers)
                : base(numbers)
            {
            }

            public override int Calculate() => _numbers.Sum();
        }
        public class EvenNumbersSumCalculator : Calculator
        {
            public EvenNumbersSumCalculator(int[] numbers)
               : base(numbers)
            {
            }

            public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
        }
        public class OddNumbersSumCalculator : Calculator
        {
            public OddNumbersSumCalculator(int[] numbers)
               : base(numbers)
            {
            }

            public override int Calculate() => _numbers.Where(x => x % 2 != 0).Sum();
        }

    }
}
