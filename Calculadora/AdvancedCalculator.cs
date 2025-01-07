namespace Calculadora
{
    public class AdvancedCalculator(ICalculator _calculator) : IAdvancedCalculator
    {
        public double Average(double[] a)
        {
            var sum = 0.0;
            foreach (var number in a)
            {
                sum = _calculator.Add(number, sum);
            }
            return _calculator.Divide(sum, a.Length);
        }
    }
}
