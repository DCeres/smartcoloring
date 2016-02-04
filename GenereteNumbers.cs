using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace test
{
    public static class GenereteNumbers
    {
        public static Workspace workspace = new Workspace();
        private static int key_count = workspace.keys.Count;
        static Random rand = new Random();

        public static T Get_AND_Remove_Random_Element<T>(List<T> element_list)
        {
            int index = rand.Next(element_list.Count);
            T output = element_list[index];
            element_list.Remove(output);
            return output;
        }


        public static void Generate_Number()
        {
            
            
            switch(workspace.op.game_mod)
            {
                case Workspace.options.g_mod.BASIC_EVEN_ODD:
                    {
                        Fill_key_BASIC_EVEN_ODD();
                        break;
                    }
                case Workspace.options.g_mod.BASIC_PRIM_COMP:
                    {
                        Fill_key_BASIC_PRIM_COMP();
                        break;
                    }
                case Workspace.options.g_mod.BASIC_MYST:
                    {
                        Fill_key_BASIC_MYST();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_SIMP:
                    {
                        Fill_key_ALGEBRA_SIMP();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_MIDD_REGROPING:
                    {
                        Fill_key_ALGEBRA_MIDDLE_REGROUPING();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_MIDD_ROUNDING:
                    {
                        Fill_key_ALGEBRA_MIDDLE_ROUNDING();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_HARD_FRAC:
                    {
                        Fill_key_ALGEBRA_HARD_FRAC();
                        break;
                    }
                case Workspace.options.g_mod.GEOM_ANGLES:
                    {
                        Fill_key_GEOM_ANGLES();
                        break;
                    }
                case Workspace.options.g_mod.GEOM_QUADR:
                    {
                        Fill_key_GEOM_QUADR();
                        break;
                    }
                case Workspace.options.g_mod.GEOM_SHAPES:
                    {
                        Fill_key_GEOM_SHAPES();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_HARD_DEC:
                    {
                        Fill_key_ALGEBRA_HARD_DEC();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_HARD_PERC:
                    {
                        Fill_key_ALGEBRA_HARD_PERC();
                        break;
                    }
            }

        }

        private static void Fill_key_BASIC_EVEN_ODD()
        {
            workspace.keys[0].str = Get_AND_Remove_Random_Element<string>(new List<string>() { "Even", "Odd" });
            workspace.keys[1].str = workspace.keys[0].str == "Odd" ? "Even" : "Odd";
        }

        private static void Fill_key_BASIC_PRIM_COMP()
        {
            workspace.keys[0].str = Get_AND_Remove_Random_Element<string>(new List<string>() { "Prime", "Composite" });
            workspace.keys[1].str = workspace.keys[0].str == "Prime" ? "Composite" : "Prime";
        }

        private static void Fill_key_BASIC_MYST()
        {
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;
            List<int> counters = new List<int>();

            for (int i = first_num; i <= last_num; i++)
                counters.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                workspace.keys[i].str = "Add ";
                int current_counter = Get_AND_Remove_Random_Element<int>(counters);
                workspace.keys[i].str += current_counter.ToString();

                if (counters.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMP()
        {
            switch (workspace.op.active_complexity)
            {
                case Workspace.options.complexity.JUNIOR:
                    {
                        Fill_key_ALGEBRA_SIMP_JUNIOR();
                        break;
                    }
                case Workspace.options.complexity.BASIC:
                    {
                        Fill_key_ALGEBRA_SIMP_BASIC();
                        break;
                    }
                case Workspace.options.complexity.ADVANCED_COMA:
                    {
                        Fill_key_ALGEBRA_SIMPLE_COMA();
                        break;
                    }
                case Workspace.options.complexity.ADVANCED_HYPHEN:
                    {
                        Fill_key_ALGEBRA_SIMPLE_HYPHEN();
                        break;
                    }


            }
        }

        private static void Fill_key_ALGEBRA_SIMP_JUNIOR()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;
            int first_or_number = 0;
            int second_or_number = 0;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                try
                {
                    first_or_number = Get_AND_Remove_Random_Element<int>(all_numbers);
                    all_numbers.Remove(first_or_number);

                    do
                    {
                        second_or_number = Get_AND_Remove_Random_Element<int>(all_numbers);
                    } while (first_or_number == second_or_number);

                    all_numbers.Remove(second_or_number);
                }
                catch { break; }

                workspace.keys[i].str = "";
                workspace.keys[i].str += first_or_number.ToString();
                workspace.keys[i].str += " or ";
                workspace.keys[i].str += second_or_number.ToString();

                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMP_BASIC()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                workspace.keys[i].str = "";
                int current_number = Get_AND_Remove_Random_Element<int>(all_numbers);
                workspace.keys[i].str += current_number.ToString();

                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMPLE_COMA()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            const int max_numbers_in_one_string = 5;

            int start_count_all_numbers = all_numbers.Count;

            for (int i = 0; i < workspace.keys.Count; i++)
            {

                if (workspace.keys.Count >= start_count_all_numbers)
                {
                    workspace.keys[i].str = "";
                    try
                    {
                        int current_number = Get_AND_Remove_Random_Element<int>(all_numbers);
                        workspace.keys[i].str += current_number.ToString();
                    }
                    catch { break; }
                }
                else
                {
                    workspace.keys[i].str = "";
                    int current_count_numbers_in_string = rand.Next(1, max_numbers_in_one_string);

                    List<int> current_numbers_in_string = new List<int>();

                    for (int j = 0; j < current_count_numbers_in_string; j++)
                    {
                        int current_number = Get_AND_Remove_Random_Element<int>(all_numbers);
                        workspace.keys[i].str += current_number.ToString();
                        if (current_count_numbers_in_string != 1 && j != current_count_numbers_in_string - 1) workspace.keys[i].str += ",";
                    }
                }
                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMPLE_HYPHEN()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            int distance = 2;
            int start_element = first_num;

            //Рівномірний розподіл проміжків між ключами
            if (all_numbers.Count > workspace.keys.Count)
                distance = all_numbers.Count / workspace.keys.Count;

            if (distance == 1) distance = 2;
            int max_start_element = last_num - (workspace.keys.Count * distance - 1);
            if (max_start_element <= 0) max_start_element = 1;
            start_element = 1;

            int current_last_element = start_element - 1;
            int current_first_element = 0;
            List<string> temp_keys_str = new List<string>();

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                string temp_key_str = "";
                current_first_element = current_last_element + 1;
                temp_key_str += current_first_element.ToString();
                temp_key_str += "-";
                current_last_element = current_first_element + distance - 1;
                temp_key_str += current_last_element;
                temp_keys_str.Add(temp_key_str);
            }

            int key_inedex = 0;
            do
            {
                workspace.keys[key_inedex].str = Get_AND_Remove_Random_Element(temp_keys_str);
                key_inedex++;
            } while (temp_keys_str.Count != 0);
        }

        private static void Fill_key_ALGEBRA_MIDDLE_REGROUPING()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            int distance = 2;
            int start_element = first_num;

            //Рівномірний розподіл проміжків між ключами
            if (all_numbers.Count > workspace.keys.Count)
                distance = all_numbers.Count / workspace.keys.Count;

            if (distance == 1) distance = 2;
            int max_start_element = last_num - (workspace.keys.Count * distance - 1);
            if (max_start_element <= 0) max_start_element = 1;
            start_element = 1;

            int current_last_element = start_element - 1;
            int current_first_element = 0;
            List<string> temp_keys_str = new List<string>();

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                string temp_key_str = "";
                current_first_element = current_last_element + 1;
                temp_key_str += current_first_element.ToString();
                temp_key_str += " to ";
                current_last_element = current_first_element + distance - 1;
                temp_key_str += current_last_element;
                temp_keys_str.Add(temp_key_str);
            }

            int key_inedex = 0;
            do
            {
                workspace.keys[key_inedex].str = Get_AND_Remove_Random_Element(temp_keys_str);
                key_inedex++;
            } while (temp_keys_str.Count != 0);
        }

        private static void Fill_key_ALGEBRA_MIDDLE_ROUNDING()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;

            switch(workspace.op.active_algebra_middle_round)
            {
                case Workspace.options.algebra_middle_round.TENS:
                    {
                        while (first_num % 10 != 0) first_num++;

                        for (int i = first_num; i <= last_num; i += 10)
                            all_numbers.Add(i);

                        for (int i = 0; i < workspace.keys.Count; i++)
                        {
                            workspace.keys[i].str = "Rounding to ";
                            int current_counter = Get_AND_Remove_Random_Element<int>(all_numbers);
                            workspace.keys[i].str += current_counter.ToString();

                            if (all_numbers.Count == 0) break;
                        }
                        break;
                    }
                case Workspace.options.algebra_middle_round.HUNDREDS:
                    {
                        while (first_num % 100 != 0) first_num++;

                        for (int i = first_num; i <= last_num; i += 100)
                            all_numbers.Add(i);

                        for (int i = 0; i < workspace.keys.Count; i++)
                        {
                            workspace.keys[i].str = "Rounding to ";
                            int current_counter = Get_AND_Remove_Random_Element<int>(all_numbers);
                            workspace.keys[i].str += current_counter.ToString();

                            if (all_numbers.Count == 0) break;
                        }
                        break;
                    }
            }
        }

        struct fraction
        {
            public int numerator, denominator;
        }

        private static void Fill_key_ALGEBRA_HARD_FRAC()
        {
            List<int> numerators = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> denominators = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 };
            List<fraction> fractions = new List<fraction>();
            

            switch (workspace.op.active_fractions_mode)
            {
                case Workspace.options.fractions.EQUAL_NUM:
                    {
                        int keys = workspace.keys.Count;
                        int denominator = 1;
                        int numerator = rand.Next(1, 6);
                        int counter = 0;
                        while (denominator < 9)
                        {
                            denominator = numerator + counter;
                            fraction fr = new fraction() { numerator = numerator, denominator = denominator };
                            fractions.Add(fr);
                            counter++;
                            keys--;
                        }

                        for (int i = 0; i < workspace.keys.Count; i++)
                        {
                            fraction current_fraction = Get_AND_Remove_Random_Element<fraction>(fractions);
                            workspace.keys[i].str = "Equal to ";
                            workspace.keys[i].str += current_fraction.numerator.ToString();
                            workspace.keys[i].str += "/";
                            workspace.keys[i].str += current_fraction.denominator.ToString();

                            if (numerators.Count == 0 || fractions.Count == 0) break;
                        }
                        break;
                    }
                case Workspace.options.fractions.EQUAL_DEN:
                    {
                        int keys = workspace.keys.Count;
                        int denominator = rand.Next(workspace.keys.Count, workspace.keys.Count + 5);
                        int numerator = 1;
                        int counter = denominator - 1;
                        while (numerator < denominator)
                        {
                            numerator = denominator - counter;
                            fraction fr = new fraction() { numerator = numerator, denominator = denominator };
                            fractions.Add(fr);
                            counter--;
                            keys--;
                        }

                        for (int i = 0; i < workspace.keys.Count; i++)
                        {
                            fraction current_fraction = Get_AND_Remove_Random_Element<fraction>(fractions);
                            workspace.keys[i].str = "Equal to ";
                            workspace.keys[i].str += current_fraction.numerator.ToString();
                            workspace.keys[i].str += "/";
                            workspace.keys[i].str += current_fraction.denominator.ToString();

                            if (numerators.Count == 0 || fractions.Count == 0) break;
                        }
                        break;
                    }
            }
        }
        struct keys_number_place
        {
            public int number;
            public string place;
        }

        private static void Fill_key_ALGEBRA_HARD_DEC()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;
            int current_number = 0;
            List<keys_number_place> number_place = new List<keys_number_place>();
            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                workspace.keys[i].str = "";
                string potential_string = "";
                string current_place = "";
                int count = 0;
                while (true)
                {
                    workspace.keys[i].str = "";
                    potential_string = "";
                    int index = rand.Next(all_numbers.Count);
                    current_number = all_numbers[index];
                    potential_string += current_number.ToString();
                    potential_string += " in the ";
                    int rand_mode = rand.Next(1, 4);
                    switch (rand_mode)
                    {
                        case 1:
                            {
                                potential_string += "ones place";
                                current_place = "ones";
                                break;
                            }
                        case 2:
                            {
                                potential_string += "tenths place";
                                current_place = "tenths";
                                break;
                            }
                        case 3:
                            {
                                potential_string += "hundredths place";
                                current_place = "hundredths";
                                break;
                            }
                    }
                    count++;
                    if (count > 10)
                    {
                        potential_string = "";
                        break;
                    }
                    if (number_place.Contains(new keys_number_place() { number = current_number, place = current_place}))
                        continue;
                    else
                    {
                        number_place.Add(new keys_number_place() { number = current_number, place = current_place });
                        break;
                    }
                }
                
                workspace.keys[i].str = potential_string;
                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_GEOM_ANGLES()
        {
            List<string> lst = new List<string>();
            lst.Add("Straight");
            lst.Add("Right");
            lst.Add("Acute");
            lst.Add("Obtuse");
            for (int i = 0; i < 4; i++)
            {
                workspace.keys[i].str = Get_AND_Remove_Random_Element(lst);
                if (workspace.keys.Count == i + 1) break;
            }
        }

        private static void Fill_key_GEOM_QUADR()
        {
            List<string> lst = new List<string>();
            lst.Add("Quadrant 1");
            lst.Add("Quadrant 2");
            lst.Add("Quadrant 3");
            lst.Add("Quadrant 4");
            for (int i = 0; i < 4; i++)
            {
                workspace.keys[i].str = Get_AND_Remove_Random_Element(lst);
                if (workspace.keys.Count == i + 1) break;
            }
        }

        private static void Fill_key_GEOM_SHAPES()
        {
            List<string> lst = new List<string>();
            lst.Add("3 sided shapes");
            lst.Add("4 sided shapes");
            lst.Add("More than sides");
            for (int i = 0; i < 3; i++)
            {
                workspace.keys[i].str = Get_AND_Remove_Random_Element(lst);
                if (workspace.keys.Count == i + 1) break;
            }
        }

        private static void Fill_key_ALGEBRA_HARD_PERC()
        {
            List<int> all_numbers = new List<int>();
            int first_num = workspace.op.active_range_first;
            int last_num = workspace.op.active_range_second;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            switch(workspace.op.active_complexity)
            {
                case Workspace.options.complexity.BASIC:
                    {
                        for (int i = 0; i < workspace.keys.Count; i++)
                        {
                            workspace.keys[i].str = "Equal to ";
                            int current_percent = Get_AND_Remove_Random_Element<int>(all_numbers);
                            workspace.keys[i].str += current_percent.ToString();
                            workspace.keys[i].str += "%";
                            if (all_numbers.Count == 0) break;
                        }
                        break;
                    }
                case Workspace.options.complexity.ADVANCED:
                    {
                        int distance = 2;
                        int start_element = first_num;

                        //Рівномірний розподіл проміжків між ключами
                        if (all_numbers.Count > workspace.keys.Count)
                            distance = all_numbers.Count / workspace.keys.Count;

                        if (distance == 1) distance = 2;
                        int max_start_element = last_num - (workspace.keys.Count * distance - 1);
                        if (max_start_element <= 0) max_start_element = 1;
                        try
                        {
                            do
                            {
                                start_element = Get_AND_Remove_Random_Element<int>(all_numbers);
                            } while (start_element > max_start_element);
                        }
                        catch { return; }

                        int current_last_element = start_element - 1;
                        int current_first_element = 0;

                        for (int i = 0; i < workspace.keys.Count; i++)
                        {
                            workspace.keys[i].str = "From ";
                            current_first_element = current_last_element + 1;
                            workspace.keys[i].str += current_first_element.ToString();
                            workspace.keys[i].str += "% to ";
                            current_last_element = current_first_element + distance - 1;
                            workspace.keys[i].str += current_last_element;
                            workspace.keys[i].str += "%";
                            try
                            {
                                all_numbers.Remove(current_first_element);
                                all_numbers.Remove(current_last_element);
                            }
                            catch { break; }
                            if (all_numbers.Count == 0 || all_numbers.Count == 1) break;
                        }
                        break;
                    }
            }
        }
    }
}
