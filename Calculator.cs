using System;
using System.Collections.Generic;
using System.Linq;

namespace QualityMetricsDemo
{
    /// <summary>
    /// Модуль калькулятора для демонстрации метрик качества
    /// </summary>
    public class Calculator
    {
        private readonly List<double> _history = new List<double>();
        private double _lastResult = 0;

        // === Базовые арифметические операции ===

        public double Add(double a, double b)
        {
            double result = a + b;
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        public double Subtract(double a, double b)
        {
            double result = a - b;
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");
            
            double result = a / b;
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        public double Power(double baseNum, double exponent)
        {
            double result = Math.Pow(baseNum, exponent);
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        public double Sqrt(double number)
        {
            if (number < 0)
                throw new ArgumentException("Корень из отрицательного числа не существует в действительных числах");
            
            double result = Math.Sqrt(number);
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        // === Статистические операции ===

        public double Sum(IEnumerable<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            
            double sum = 0;
            foreach (var num in numbers)
                sum += num;
            
            _lastResult = sum;
            _history.Add(sum);
            return sum;
        }

        public double Average(IEnumerable<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            
            var list = numbers.ToList();
            if (!list.Any())
                throw new ArgumentException("Коллекция не должна быть пустой");
            
            double avg = list.Average();
            _lastResult = avg;
            _history.Add(avg);
            return avg;
        }

        public double Min(IEnumerable<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            
            var list = numbers.ToList();
            if (!list.Any())
                throw new ArgumentException("Коллекция не должна быть пустой");
            
            double min = list.Min();
            _lastResult = min;
            _history.Add(min);
            return min;
        }

        public double Max(IEnumerable<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            
            var list = numbers.ToList();
            if (!list.Any())
                throw new ArgumentException("Коллекция не должна быть пустой");
            
            double max = list.Max();
            _lastResult = max;
            _history.Add(max);
            return max;
        }

        // === Сложные вычисления с ветвлениями (для цикломатической сложности) ===

        public double CalculateDiscount(double price, int customerLevel, bool isHoliday)
        {
            double discount = 0;

            // Базовая скидка по уровню клиента
            if (customerLevel >= 5)
                discount = 0.25;
            else if (customerLevel >= 3)
                discount = 0.15;
            else if (customerLevel >= 1)
                discount = 0.05;
            else
                discount = 0;

            // Дополнительная скидка в праздник
            if (isHoliday)
                discount += 0.05;

            // Максимальная скидка не может превышать 30%
            if (discount > 0.3)
                discount = 0.3;

            // Минимальная цена
            double finalPrice = price * (1 - discount);
            if (finalPrice < 0)
                finalPrice = 0;

            _lastResult = finalPrice;
            _history.Add(finalPrice);
            return finalPrice;
        }

        public string GetGrade(double score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentException("Оценка должна быть от 0 до 100");

            if (score >= 90)
                return "Отлично";
            else if (score >= 75)
                return "Хорошо";
            else if (score >= 50)
                return "Удовлетворительно";
            else
                return "Неудовлетворительно";
        }

        public double CalculateBMI(double weight, double height)
        {
            if (weight <= 0 || height <= 0)
                throw new ArgumentException("Вес и рост должны быть положительными");

            double bmi = weight / (height * height);
            
            // Интерпретация результата
            if (bmi < 18.5)
                _lastResult = bmi;
            else if (bmi < 25)
                _lastResult = bmi;
            else if (bmi < 30)
                _lastResult = bmi;
            else
                _lastResult = bmi;

            _history.Add(bmi);
            return bmi;
        }

        // === Работа с историей ===

        public double GetLastResult()
        {
            return _lastResult;
        }

        public IReadOnlyList<double> GetHistory()
        {
            return _history.AsReadOnly();
        }

        public void ClearHistory()
        {
            _history.Clear();
            _lastResult = 0;
        }

        public int GetHistoryCount()
        {
            return _history.Count;
        }

        public double GetAverageHistory()
        {
            if (!_history.Any())
                return 0;
            return _history.Average();
        }

        // === Вспомогательные методы ===

        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public double Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал определён только для неотрицательных чисел");
            
            if (n == 0)
                return 1;
            
            double result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            
            _lastResult = result;
            _history.Add(result);
            return result;
        }

        public int CountNumbers(IEnumerable<double> numbers, Func<double, bool> predicate)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return numbers.Count(predicate);
        }

        public double[] Normalize(IEnumerable<double> numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            var list = numbers.ToList();
            if (!list.Any())
                return Array.Empty<double>();

            double min = list.Min();
            double max = list.Max();

            if (max == min)
                return list.Select(_ => 0.5).ToArray();

            return list.Select(x => (x - min) / (max - min)).ToArray();
        }

        // === Свойства ===

        public double LastResult => _lastResult;
        public int HistorySize => _history.Count;
        public bool HasHistory => _history.Any();
    }
}
