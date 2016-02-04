using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Security.Cryptography;
using test;

namespace test
{
    abstract class Interpreter
    {
        //public Interpreter(string s1) { }
        public virtual int GetResult(){return 0;}

        public static T List_GetRandomNumber<T>(List<T> potential_numbers)
        {
            Random rand = new Random();
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            T result = potential_numbers[index];
            return result;
        }
    }
    class MathTemplate
    {
        public static int GenerateRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            int result = BitConverter.ToInt32(buffer, 0);

            return new Random(result).Next(min, max);
        }
        public static int GenerateRandomNumber(int max)
        {
            int min = 0;
            if (max == 0) return 0;
            RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();
            // Integer 4 Byte
            byte[] randomNumber = new byte[4];
            // Array with Random Bytes
            c.GetBytes(randomNumber);
            // Byte-Array to Integer
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
            // Max. randomnumber Min. randomnumber
            return result % max + min;
        }
        public static string MathFact_Jr(string input, char sign)
        {
            jr_key_interpr key = new jr_key_interpr(input);
            return GenerateString(key, sign);
        }

        public static string MathFact_Basic(string input, char sign)
        {
            basic_key_interpr key = new basic_key_interpr(input);
            return GenerateString(key, sign);
        }

        public static string MathFact_Advanced(string input, char sign)
        {
            advanced_key_interpr key = new advanced_key_interpr(input);
            return GenerateString(key, sign);
        }

        public static string MathFact_Mixed(string input)
        {
            advanced_key_interpr key = new advanced_key_interpr(input);

            // Випадково вибираємо знак операції над числами
            Random rand = new Random();
            char[] arr_chars = { '+', '-', '*', '/' };
            List<char> potential_signs = new List<char>(arr_chars);
            int index = GenerateRandomNumber(potential_signs.Count);
            char sign = potential_signs[index];

            return GenerateString(key, sign);
        }

        public static string PlaceValue_Counting(string input)
        {
            advanced_key_interpr key = new advanced_key_interpr(input);

            return key.GetResult().ToString();
        }

        public static string PlaceValue_PlaceValue(string input)
        {
            place_depend_key_interpr key = new place_depend_key_interpr(input);

            return key.GetResult().ToString();
        }

        public static string PlaceValue_Rounding(string input, bool q)// if q == true, to ten
        {
            rounding_interpr key = new rounding_interpr(input, q);

            return key.GetResult().ToString();
        }

        public static string AdvancedMath_Regrouping(string input, char sign)
        {
            regrouping_interpr key = new regrouping_interpr(input);

            return GenerateColomnString(key, sign);
        }

        public static string AdvancedMath_NumbAndOps_Even_Odd(string input)
        {
            even_odd_interpr key = new even_odd_interpr(input);

            return key.GetResult().ToString();
        }

        public static string AdvancedMath_NumbAndOps_NumbPatterns(string input)
        {
            num_pattern_interpr key = new num_pattern_interpr(input);

            return GenerateNumberSeriesString(key, key.GetResult());
        }

        public static string AdvancedMath_NumbAndOps_PrimeOrComposite(string input)
        {
            prime_composite_interpr key = new prime_composite_interpr(input);

            return key.GetResult().ToString();
        }

        public static string AdvancedMath_NumbAndOps_GeomAndMeasur(string input)
        {
            geom_measurement_interpr key = new geom_measurement_interpr(input);

            return GenerateAnglesString(key);
        }

        public static string AdvancedMath_NumbAndOps_Quadrants(string input)
        {
            qudrant_interpr key = new qudrant_interpr(input);

            return GenerateQuadrantString(key);
        }

        public static string AdvancedMath_NumbAndOps_Shapes_Names(string input)
        {
            shape_name_interpr key = new shape_name_interpr(input);

            return GenerateShapeNameString(key);
        }

        public static string Color_By_Numb_Color_By_Numb(string input)
        {
            basic_key_interpr key = new basic_key_interpr(input);

            return key.GetResult().ToString();
        }

        public static string Color_By_Numb_Number_Pairs(string input)
        {
            number_pairs_interpr key = new number_pairs_interpr(input);

            return key.GetResult().ToString();
        }

        public static string Color_By_Numb_Number_Ranges(string input)
        {
            number_pairs_interpr key = new number_pairs_interpr(input);

            return key.GetResult().ToString();
        }

        public static string FDP_Fractions_Numerators(string input)
        {
            fraction_numer_denom_interpr key = new fraction_numer_denom_interpr(input);

            return key.GetResult();
        }

        public static string FDP_Fractions_Denominators(string input)
        {
            fraction_numer_denom_interpr key = new fraction_numer_denom_interpr(input);

            return key.GetResult();
        }

        public static string FDP_Decimal_Place_Value(string input)
        {
            fraction_decimal_interpr key = new fraction_decimal_interpr(input);

            return key.GetResult();
        }

        public static string FDP_Decimal_Sense(string input)
        {
            fraction_decimal_sense_interpr key = new fraction_decimal_sense_interpr(input);

            return key.GetResult();
        }

        public static string FDP_Percent_Equivalence(string input)
        {
            fraction_percent_equiv_interpr key = new fraction_percent_equiv_interpr(input);

            return key.GetResult();
        }

        public static string FDP_Percent_Number_Sense(string input)
        {
            fraction_percent_equiv_interpr key = new fraction_percent_equiv_interpr(input);

            return key.GetResult();
        }


        //**********************************************************************
        //**********************************************************************

        // Генератор стрічки відповідно до заданого ключа
        private static string GenerateString(Interpreter key, char sign)
        {
            Random rand = new Random();
            string output = "";
            int first_nmb = 0;
            int second_nmb = 0;
            int result = key.GetResult();

            switch (sign)
            {
                case '+':
                    {
                        first_nmb = GenerateRandomNumber(0, result);
                        second_nmb = result - first_nmb;

                        output = first_nmb.ToString() + " + " + second_nmb.ToString();
                        break;
                    }
                case '-':
                    {
                        first_nmb = GenerateRandomNumber(result, result + 20);
                        second_nmb = first_nmb - result;

                        output = first_nmb.ToString() + " - " + second_nmb.ToString();
                        break;
                    }
                case '/':
                    {
                        second_nmb = GenerateRandomNumber(1, 10);
                        first_nmb = second_nmb * result;

                        output = first_nmb.ToString() + " / " + second_nmb.ToString();
                        break;
                    }
                case '*':
                    {
                        first_nmb = GetRandomDivisor(result);
                        second_nmb = result / first_nmb;
                        output = first_nmb.ToString() + " * " + second_nmb.ToString();
                        break;
                    }
            }

            return output;
        }

        // Генератор стрічки виконання дій у стовпчик
        private static string GenerateColomnString(Interpreter key, char sign)
        {
            Random rand = new Random();
            string output = "";
            int first_nmb = 0;
            int second_nmb = 0;
            int result = key.GetResult();

            switch (sign)
            {
                case '+':
                    {
                        first_nmb = GenerateRandomNumber(0, result);
                        second_nmb = result - first_nmb;

                        output = first_nmb.ToString() + "\n + " + second_nmb.ToString();
                        break;
                    }
                case '-':
                    {
                        first_nmb = GenerateRandomNumber(result, result + 20);
                        second_nmb = first_nmb - result;

                        output = first_nmb.ToString() + "\n - " + second_nmb.ToString();
                        break;
                    }
                case '*':
                    {


                        first_nmb = GetRandomDivisor(result);
                        second_nmb = result / first_nmb;
                        output = first_nmb.ToString() + "\n * " + second_nmb.ToString();
                        break;
                    }
            }

            return output;
        }

        // Генератор стрічки з рядом чисел
        private static string GenerateNumberSeriesString(Interpreter key, int distance)
        {
            const int numbers_in_string = 4;
            Random rand = new Random();
            int startNumber = 0;
            List<int> potential_numbers = new List<int>();
            string output = "";

            for (int i = 0; i < 100 - (numbers_in_string * distance); i++ )
            {
                potential_numbers.Add(i);
            }
            int index = GenerateRandomNumber(potential_numbers.Count);
            startNumber = potential_numbers[index];

            output = String.Format("{0},{1},\n{2},{3}", startNumber, startNumber + distance, 
                startNumber + (distance * 2), startNumber + (distance*3));
            return output;
        }

        // Генератор стрічки з кутовими значеннями
        private static string GenerateAnglesString(Interpreter key)
        {
            List<int> angles = new List<int>();
            Random rand = new Random();
            int final_angle = 0;

            switch(key.GetResult())
            {
                //Випадок розгорнутого кута
                case 0:
                    {
                        final_angle = 180;
                        return final_angle.ToString() + (char)176;
                    }

                //Випадок прямого кута
                case 1:
                    {
                        final_angle = 90;
                        return final_angle.ToString() + (char)176;
                    }

                //Випадок гострого кута
                case 2:
                    {
                        final_angle = GenerateRandomNumber(1, 89);
                        return final_angle.ToString() + (char)176;
                    }

                //Випадок тупого кута
                case 3:
                    {
                        final_angle = GenerateRandomNumber(91, 179);
                        return final_angle.ToString() + (char)176;
                    }
            }
            return "";
        }

        // Генератор стрічки з координатами
        private static string GenerateQuadrantString(Interpreter key)
        {
            Random rand = new Random();
            int quadrant = key.GetResult();
            int first_coordinate = 0, second_coordinate = 0;
            string output = "";

            switch(quadrant)
            {
                case 1:
                    {
                        first_coordinate = GenerateRandomNumber(0, 999);
                        second_coordinate = GenerateRandomNumber(0, 999);
                        break;
                    }
                case 2:
                    {
                        first_coordinate = GenerateRandomNumber(0, 999);
                        second_coordinate = GenerateRandomNumber(-999, 0);
                        break;
                    }
                case 3:
                    {
                        first_coordinate = GenerateRandomNumber(-999, 0);
                        second_coordinate = GenerateRandomNumber(-999, 0);
                        break;
                    }
                case 4:
                    {
                        first_coordinate = GenerateRandomNumber(-999, 0);
                        second_coordinate = GenerateRandomNumber(0, 999);
                        break;
                    }
            }

            output = first_coordinate.ToString() + ",\n" + second_coordinate.ToString();
            return output;
        }

        // Генератор стрічки з іменем фігури
        private static string GenerateShapeNameString(Interpreter key)
        {
            int sides = key.GetResult();
            Random rand = new Random();
            string output = "";

            List<string> _3Sides = new List<string>() 
            { 
                "right", "triangle", "isoscales", "equilateral"
            };
            List<string> _4Sides = new List<string>()
            { 
                "parallelogram", "rhombus", "square", "rectangle", "trapezoid"
            };
            List<string> MoreSides = new List<string>()
            { 
                "hexagon", "pentagon", "octagon"
            };

            switch (sides)
            {
                // Ідентифікатор трикутника
                case 3:
                    {
                        int index = GenerateRandomNumber(_3Sides.Count);
                        output = _3Sides[index];
                        break;
                    }
                // Ідентифікатор чотирикутника
                case 4:
                    {
                        int index = GenerateRandomNumber(_4Sides.Count);
                        output = _4Sides[index];
                        break;
                    }
                // Ідентифікатор багатокутника
                case 5:
                    {
                        int index = GenerateRandomNumber(MoreSides.Count);
                        output = MoreSides[index];
                        break;
                    }
            }

            return output;
        }

        private static int GetRandomDivisor(int number)
        {
            List<int> dividers = new List<int>();
            Random rand = new Random();

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0) dividers.Add(i);
            }

            int index = GenerateRandomNumber(dividers.Count);
            int divider = 1;
            if(dividers.Count != 0)
                divider = dividers[index];
            return divider;
        }
    }

    //Клас для інтерпретації ключа типу jr
    class jr_key_interpr: Interpreter
    {
        int first_nmb;
        int second_nmb;
        Random rand = new Random();

        public jr_key_interpr(string s1)
        {
            string[] arr = s1.Split(' ');
            first_nmb = int.Parse(arr[0]);
            second_nmb = int.Parse(arr[2]);
        }

        public override int GetResult()
        {
            int temp = MathTemplate.GenerateRandomNumber(0, 2);
            if (temp == 0) return first_nmb;
            else return second_nmb;
        }
    }

    //Клас для інтерпретації ключа типу basic
    class basic_key_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();

        public basic_key_interpr(string s1)
        {
            result = int.Parse(s1);
        }

        public override int GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу advanced
    class advanced_key_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();
        bool isSingleNum = false;

        public advanced_key_interpr(string s1)
        {
            if(s1.Contains('-'))
            {
                string[] str_limits_numbers = s1.Split('-');
                int first_number = int.Parse(str_limits_numbers[0]);
                int last_number = int.Parse(str_limits_numbers[1]);
                for (int i = first_number; i <= last_number; i++)
                    potential_numbers.Add(i);
            }
            else if (s1.Contains(','))
            {
                string[] str_numbers = s1.Split(',');
                for (int i = 0; i < str_numbers.Length; i++ )
                    potential_numbers.Add(int.Parse(str_numbers[i]));
            }
            else
            {
                isSingleNum = true;
                result = int.Parse(s1);
            }
        }

        public override int GetResult()
        {
            if (!isSingleNum)
            {
                int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
                result = potential_numbers[index];
            }
            return result;
        }
    }

    //Клас для інтерпретації ключа типу placeValue
    class place_depend_key_interpr: Interpreter
    {
        int number = 0;
        int result = 0;
        List<int> potential_numbers = new List<int>();
        Random rand = new Random();
        bool isOnes = false;
        bool isTens = false;
        bool isHundreds = false;

        private static bool isNumberInOnes(int final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number < 10 && final_number == peace_number) return true;
            else if (final_number >= 10 && final_number < 100 && str_final_number[1].ToString() == peace_number.ToString()) return true;
            else if (final_number >= 100 && final_number < 1000 && str_final_number[2].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static bool isNumberInTens(int final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number > 10 && final_number < 100 && str_final_number[0].ToString() == peace_number.ToString()) return true;
            else if (final_number > 100 && final_number < 1000 && str_final_number[1].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static bool isNumberInHundreds(int final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number > 100 && final_number < 1000 && str_final_number[0].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        public place_depend_key_interpr(string s1)
        {
            if(!(s1.Contains("Not") || s1.Contains("not") || s1.Contains("NOT")))
            {
                string[] all_words = s1.Split(' ');
                number = int.Parse(all_words[0]);

                for(int i = 1; i < all_words.Length; i++)
                {
                    if (all_words[i] == "ones") isOnes = true;
                    else if (all_words[i] == "tens") isTens = true;
                    else if (all_words[i] == "hundreds") isHundreds = true;
                }

                for(int i = 1; i < 1000; i++)
                {
                    if(isOnes && isNumberInOnes(i, number))
                        potential_numbers.Add(i);
                    else if(isTens && isNumberInTens(i, number))
                        potential_numbers.Add(i);
                    else if (isHundreds && isNumberInHundreds(i, number))
                        potential_numbers.Add(i);
                }
            }
            else
            {
                for(int i = 0; i < 1000; i++)
                {
                    if(!i.ToString().Contains(number.ToString()))
                    {
                        potential_numbers.Add(i);
                    }
                }
            }
        }

        public override int GetResult()
        {
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу rounding
    class rounding_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();
        public rounding_interpr(string s1, bool q)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);

            if(q == true)
            {
                for (int i = input_number - 5; i < input_number + 5; i++)
                    potential_numbers.Add(i);
            }
            else if (q == false)
            {
                for (int i = input_number - 50; i < input_number + 50; i++)
                    potential_numbers.Add(i);
            }
        }

        public override int GetResult()
        {
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу regrouping
    class regrouping_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        int first_number = 0;
        int second_number = 0;
        List<int> potential_numbers = new List<int>();
        public regrouping_interpr(string s1)
        {
            string[] all_words = s1.Split(' ');
            first_number = int.Parse(all_words[0]);
            second_number = int.Parse(all_words[2]);

            //result = MathTemplate.GenerateRandomNumber(first_number, second_number);
            //result = rand.Next(first_number, second_number +1);
        }

        public override int GetResult()
        {
            result = MathTemplate.GenerateRandomNumber(first_number, second_number);
            return result;
        }
    }

    //Клас для інтерпретації ключа типу even or odd numbers
    class even_odd_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();

        public even_odd_interpr(string s1)
        {
            for (int i = 1; i < 1000; i++)
            {
                if (s1.ToLower() == "even" && i % 2 == 0)
                {
                    potential_numbers.Add(i);
                }else if(s1.ToLower() == "odd" && i % 2 != 0)
                {
                    potential_numbers.Add(i);
                }
            }
        }

        public override int GetResult()
        {
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу number pattern
    class num_pattern_interpr : Interpreter
    {
        int result = 0;
        List<int> potential_numbers = new List<int>();

        public num_pattern_interpr(string s1)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);

            if(all_words[0].ToLower() == "add")
                result = input_number;
        }
        public override int GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу prime or composite
    class prime_composite_interpr : Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();

        public bool IsPrime(int num)
        {

            bool _isPrime = true;

            if (num % 2 == 0) return false;

            for (int i = 3; i <= Convert.ToInt32(Math.Sqrt(num)); i = i + 2)
            {

                if (num % i == 0)
                {

                    _isPrime = false;

                    break;

                }

            }

            return _isPrime;

        }

        public prime_composite_interpr(string s1)
        {
            for(int i = 0; i < 1000; i++)
            {
                if (s1.ToLower() == "prime" && IsPrime(i))
                    potential_numbers.Add(i);
                else if (s1.ToLower() == "composite" && !IsPrime(i))
                    potential_numbers.Add(i);
            }
        }

        public override int GetResult()
        {
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу geometry and measurement
    class geom_measurement_interpr : Interpreter
    {
        int result = 0;
        List<int> potential_numbers = new List<int>();

        public geom_measurement_interpr(string s1)
        {
            char first_letter = (s1.ToLower())[0];

            switch(first_letter)
            {
                case 's': result = 0; break;
                case 'r': result = 1; break;
                case 'a': result = 2; break;
                case 'o': result = 3; break;
            }
        }
        public override int GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу quadrant
    class qudrant_interpr : Interpreter
    {
        int quadrant = 0;
        List<int> potential_numbers = new List<int>();

        public qudrant_interpr(string s1)
        {
            quadrant = int.Parse((s1.Split(' '))[1]);
        }
        public override int GetResult()
        {
            return quadrant;
        }
    }

    //Клас для інтерпретації ключа типу shape name
    class shape_name_interpr : Interpreter
    {
        int result = 0;

        public shape_name_interpr(string s1)
        {
            string input_str = s1.ToLower();

            if (input_str.Contains("more"))
                result = 5;// Ідентифікатор багатокутника
            else if (input_str.Contains("4"))
                result = 4;// Ідентифікатор чотирикутника
            else if (input_str.Contains("3"))
                result = 3;// Ідентифікатор трикутника
        }

        public override int GetResult()
        {
            return result;
        }
    }



    //////////////////////////////////////////////////
    //////////////////////////////////////////////////
    //Клас для інтерпретації ключа типу number pairs
    class number_pairs_interpr : Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();

        public number_pairs_interpr(string s1)
        {
            if (s1.Contains(','))
            {
                string[] str_numbers = s1.Split(',');
                for (int i = 0; i < str_numbers.Length; i++ )
                    potential_numbers.Add(int.Parse(str_numbers[i]));
            }else if (s1.Contains('-'))
            {
                string[] str_limits_numbers = s1.Split('-');
                int first_number = int.Parse(str_limits_numbers[0]);
                int last_number = int.Parse(str_limits_numbers[1]);
                for (int i = first_number; i <= last_number; i++)
                    potential_numbers.Add(i);
            }
        }

        public override int GetResult()
        {
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }


    

    //Клас для інтерпретації ключа типу number numerators and denominators
    class fraction_numer_denom_interpr : Interpreter
    {
        string result = "";
        Random rand = new Random();
        int numerator = 0, denominator = 1;
        int final_numerator = 1, final_denominator = 1;
        List<int> potential_numerators = new List<int>();
        List<int> potential_denominators = new List<int>();

        public fraction_numer_denom_interpr(string s1)
        {
            if ((s1.ToLower()).Contains("whole"))
            {
                final_denominator = final_numerator = MathTemplate.GenerateRandomNumber(1, 999);
                return;
            }
            string[] words = s1.Split(' ');
            string[] s_numer_denom = words[2].Split('/');
            numerator = int.Parse(s_numer_denom[0]);
            denominator = int.Parse(s_numer_denom[1]);
            int multiplier = 1;
            int biggest_number = 1;

            do
            {
                multiplier = MathTemplate.GenerateRandomNumber(1, 100);
                biggest_number = numerator > denominator ? multiplier * numerator : multiplier * denominator;
            }while(biggest_number > 1000);

            final_denominator =denominator * multiplier;
            final_numerator =numerator * multiplier;
        }

        public new string GetResult()
        {
            result += final_numerator.ToString();
            result += "/\n";
            result += final_denominator.ToString();

            return result;
        }
    }
    //Клас для інтерпретації ключа типу decimal
    class fraction_decimal_interpr : Interpreter
    {
        static int number = 0;
        static string result = "";
        static List<int> potential_numbers = new List<int>();
        static Random rand = new Random();
        static bool isOnes = false;
        static bool isTens = false;
        static bool isHundreds = false;

        private static bool isNumberInOnes(double final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number > 0 && str_final_number[0].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static bool isNumberInTenths(double final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            try
            {
                str_final_number[2].ToString();
            }
            catch
            {
                return false;
            }

            if (final_number > 1 && final_number < 10 && str_final_number[2].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static bool isNumberInHundredths(double final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            try
            {
                str_final_number[3].ToString();
            }
            catch
            {
                return false;
            }

            if (final_number > 1 && final_number < 10 && str_final_number[3].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static int Ones_GetRandom()
        {
            int answer = 0;
            int start = number * 100;
            int last = number * 100 + 100;
            for (int i = start; i < number * 100 + 100; i++)
                potential_numbers.Add(i);

            answer = test.GenereteNumbers.Get_AND_Remove_Random_Element<int>(potential_numbers);
            potential_numbers.Clear();
            return answer;
        }

        private static int Tenths_GetRandom()
        {
            int answer = 0;
            int start = number * 10;
            int last = 1000;
            int count = 0;
            for (int i = start; i < last; i++)
            {
                if (count == 10)
                {
                    i += 90;
                    count = 0;
                }
                potential_numbers.Add(i);
                count++;
            }

            answer = test.GenereteNumbers.Get_AND_Remove_Random_Element<int>(potential_numbers);
            potential_numbers.Clear();
            return answer;
        }

        private static int Hundreds_GetRandom()
        {
            int answer = 0;

            for (int i = number; i < 1000; i += 10)
                potential_numbers.Add(i);

            answer = test.GenereteNumbers.Get_AND_Remove_Random_Element<int>(potential_numbers);
            potential_numbers.Clear();
            return answer;
        }

        private static string Create_Output_String(int input_number)
        {
            string input_string = input_number.ToString();
            string output_string = "";

            if (isOnes)
            {
                if (input_string.Length == 2)
                {
                    output_string += input_string[0];
                    output_string += ".";
                    output_string += input_string[1];
                    output_string += input_string[2];
                }else
                {
                    output_string += input_string[0];
                    output_string += ".";
                    output_string += input_string[1];
                }
            }
            else if (isTens)
            {
                if (input_string.Length == 2)
                {
                    output_string += "0";
                    output_string += ".";
                    output_string += input_string[0];
                    output_string += input_string[1];
                }
                else
                {
                    output_string += input_string[0];
                    output_string += ".";
                    output_string += input_string[1];
                    output_string += input_string[2];
                }
            }
            else if (isHundreds)
            {
                if (input_string.Length == 1)
                {
                    output_string += "0";
                    output_string += ".";
                    output_string += "0";
                    output_string += input_string[0];
                }
                else if (input_string.Length == 2)
                {
                    output_string += "0";
                    output_string += ".";
                    output_string += input_string[0];
                    output_string += input_string[1];
                }
                else
                {
                    output_string += input_string[0];
                    output_string += ".";
                    output_string += input_string[1];
                    output_string += input_string[2];
                }
            }

            return output_string;
        }

        public fraction_decimal_interpr(string s1)
        {
            int random_number = 0;
            if(!(s1.Contains("Not") || s1.Contains("not") || s1.Contains("NOT")))
            {
                string[] all_words = s1.Split(' ');
                number = int.Parse(all_words[0]);

                for(int i = 1; i < all_words.Length; i++)
                {
                    if (all_words[i] == "ones")
                    {
                        isOnes = true;
                        isTens = false;
                        isHundreds = false;
                    }
                    if (all_words[i] == "tenths")
                    {
                        isOnes = false;
                        isTens = true;
                        isHundreds = false;
                    }
                    if (all_words[i] == "hundredths")
                    {
                        isOnes = false;
                        isTens = false;
                        isHundreds = true;
                    }
                }

                if(isOnes)
                    random_number = Ones_GetRandom();
                else if(isTens)
                    random_number = Tenths_GetRandom();
                else if (isHundreds)
                    random_number = Hundreds_GetRandom();

                result = Create_Output_String(random_number);
            }
            else
            {
                for(int i = 1; i < 1000; i++)
                {
                    if(!i.ToString().Contains(number.ToString()))
                    {
                        potential_numbers.Add(i);
                    }
                }
            }
        }

        public new string GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу percent
    class fraction_percent_equiv_interpr : Interpreter
    {
        struct Fraction
        {
            public int numerator;
            public int denominator;
        } 


        string result = "";
        string percent = "";
        List<string> potential_numbers = new List<string>();
        Fraction input = new Fraction();
        Fraction final = new Fraction();
        Random rand = new Random();


        static Fraction ToReduce(Fraction fraction)
        {
            int nod = Nod(fraction.numerator, fraction.denominator);
            if (nod != 0)
            {
                fraction.numerator /= nod;
                fraction.denominator /= nod;
            }
            return fraction;
        }
        static int Nod(int n, int d)
        {
            int temp;
            n = Math.Abs(n);
            d = Math.Abs(d);
            while (d != 0 && n != 0)
            {
                if (n % d > 0)
                {
                    temp = n;
                    n = d;
                    d = temp % d;
                }
                else break;
            }
            if (d != 0 && n != 0) return d;
            else return 0;
        }

        public fraction_percent_equiv_interpr(string s1)
        {
            string[] words = s1.Split(' ');

            if (!(s1.ToLower()).Contains("from"))
            {
                string temp = words[2];


                for (int i = 0; i < temp.Length - 1; i++)
                    percent += temp[i];

                input.numerator = int.Parse(percent);
                input.denominator = 100;

                //Скорочення дробу для захоплення всіх можливих варіантів
                final = ToReduce(input);

                //Добавлення до потенційних чисел десяткові дроби
                for (int i = 1; i < 100; i++)
                {
                    if (i.ToString() == percent)
                    {
                        string number = "";
                        if(i < 10)
                            number = "0.0";
                        else
                            number = "0.";
                        number += i.ToString();
                        potential_numbers.Add(number);
                        break;
                    }
                }

                //Добавлення до потенційних чисел звичайні дроби
                do
                {
                    string number = final.numerator.ToString() + "/" + final.denominator.ToString();
                    potential_numbers.Add(number);
                    final.numerator *= 2;
                    final.denominator *= 2;
                } while (final.denominator < 1000);
            }
            else
            {
                string temp = words[1];
                string first_num = "";

                for (int i = 0; i < temp.Length - 1; i++)
                    first_num += temp[i];

                temp = words[3];
                string second_num = "";

                for (int i = 0; i < temp.Length - 1; i++)
                    second_num += temp[i];

                int percent = MathTemplate.GenerateRandomNumber(int.Parse(first_num), int.Parse(second_num));

                input.numerator = percent;
                input.denominator = 100;

                //Скорочення дробу для захоплення всіх можливих варіантів
                final = ToReduce(input);

                //Добавлення до потенційних чисел десяткові дроби
                for (int i = 1; i < 100; i++)
                {
                    if (i == percent)
                    {
                        string number = "";
                        if (i < 10)
                            number = "0.0";
                        else
                            number = "0.";
                        number += i.ToString();
                        potential_numbers.Add(number);
                        break;
                    }
                }

                //Добавлення до потенційних чисел звичайні дроби
                do
                {
                    string number = final.numerator.ToString() + "/" + final.denominator.ToString();
                    potential_numbers.Add(number);
                    final.numerator *= 2;
                    final.denominator *= 2;
                } while (final.denominator < 1000);
            }
        }
        public new string GetResult()
        {
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            string temp = potential_numbers[index].ToString();
            result = temp;
            return result;
        }
    }

    //Клас для інтерпретації ключа типу decimal number sense
    class fraction_decimal_sense_interpr : Interpreter
    {
        static List<string> potential_numbers = new List<string>();
        static Random rand = new Random();
        string result = "";

        private static string Create_string_to_output(string first_num,string second_num)
        {
            string final_num = "";
            string final_first = "";
            string final_second = "";

            #region Конвертуємо вхідну стрічку з дробовими у стрічку з цілими для знаходження числа з проміжку між числами
            if (first_num.Contains('.'))
            {
                for (int i = 0; i < first_num.Length; i++)
                {
                    if (first_num[i] != '.')
                        final_first += first_num[i];
                }
            }
            else
            {
                final_first = first_num;
            }

            if (second_num.Contains('.'))
            {
                for (int i = 0; i < second_num.Length; i++)
                {
                    if (second_num[i] != '.')
                        final_second += second_num[i];
                }
            }
            else
            {
                final_second = second_num;
            }
            #endregion

            #region Зрівнюємо два числа по довжині
            if (final_first.Length > final_second.Length)
            {
                do
                {
                    final_second += "0";
                } while (final_first.Length != final_second.Length);
            }
            else if (final_second.Length > final_first.Length)
            {
                do
                {
                    final_first += "0";
                } while (final_first.Length != final_second.Length);
            }

            for (int i = int.Parse(final_first); i <= int.Parse(final_second); i++ )
            {
                potential_numbers.Add(i.ToString());
            }
            #endregion

            potential_numbers = potential_numbers.Distinct().ToList();

            //Випадково вибираємо число
            int index = MathTemplate.GenerateRandomNumber(potential_numbers.Count);
            string temp = potential_numbers[index];
            final_num += temp[0];
            final_num += ".";
            for (int i = 1; i < temp.Length;i++)
                final_num += temp[i];

            return final_num;
        }

        public fraction_decimal_sense_interpr(string s1)
        {
            string[] words = s1.Split(' ');
            string s_first_num = words[1];
            string s_second_num = words[3];

            result = Create_string_to_output(s_first_num, s_second_num);
            
        }

        public new string GetResult()
        {
            return result;
        }
    }
}
