namespace SampleConsoleApp.Examples
{
    internal class Beginner
    {
        public static void Start()
        {
            Console.WriteLine("Please enter your name:");

            var inputName = Console.ReadLine();

            Console.WriteLine($"Your name is {inputName}");
            Console.WriteLine($"Choose name style:");
            Console.WriteLine($"1: UPPERCASE");
            Console.WriteLine($"2: F L U F F Y");
            Console.WriteLine($"3: ---=== Awesome ===--");
            Console.WriteLine($"4: AlTeRnAtInG cApS");
            Console.WriteLine($"5: Snake_Case");
            Console.WriteLine($"6: CamelCase");
            Console.WriteLine($"7: H4rd C0d3d");
            Console.WriteLine($"8: Onlo oso o for vowols [only use letter o for all vowels]");


            var chosenStyle = Console.ReadLine();

            while (!int.TryParse(chosenStyle, out var result))
            {
                Console.WriteLine($"{result} is not a valid selection, only numeric values is accepted");
                Console.WriteLine($"Try again - Choose name style:");

                chosenStyle = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine(Format(int.Parse(chosenStyle), inputName));
            Console.WriteLine();

            Console.WriteLine("Press any key to start over. Press X to exit");

            var restart = Console.ReadLine();
            if (restart.ToLower() != "x")
                Start();

        }

        static string Format(int style, string name)
        {
            switch (style)
            {
                case 1:
                    return name.ToUpper();
                case 2:
                    return string.Join(' ', name.ToCharArray()).ToUpper();
                case 3:
                    return $"--==={name}===---";
                case 4:
                    return FormatToAlternatingCaps(name);
                case 5:
                    return SnakeCase(name);
                case 6:
                    return CamelCase(name);
                case 7:
                    return FormatToHardCoded(name);
                case 8:
                    return OnlyO(name);

                default: return name;
            }
        }

        static string FormatToAlternatingCaps(string name)
        {
            var stringToReturn = "";
            for (int i = 0; i < name.Length; i++)
            {
                if (i%2 == 0)
                {
                    stringToReturn += name[i].ToString().ToUpper();
                }
                else
                {
                    stringToReturn += name[i].ToString().ToLower();
                }
            }
            return stringToReturn;
        }

        static string SnakeCase(string name){
            var stringToReturn = "";

            for (int i = 0; i < name.Length; i++)
            {
                if(name[i] == ' ')
                {
                    stringToReturn += '_';
                }
                else
                {
                    stringToReturn += name[i];
                }
            }

            return stringToReturn;
        }

        static string CamelCase(string name){
            
            var interString = "";
            var stringToReturn = "";

            for (int i = 1; i < name.Length; i++)
            {
                if(name[i-1] == ' ')
                {
                    interString += name[i].ToString().ToUpper();
                }
                else
                {
                    interString += name[i];
                }
            }

            for (int i = 0; i < interString.Length; i++)
            {
                if(name[i] != ' ')
                {
                    stringToReturn += name[i];
                }
            }

            return stringToReturn;
        }

        static string FormatToHardCoded(string name)
        {
            //TODO: change letter a to 4, o to 0 and e to 3
            var stringToReturn = "";
            for (int i = 0; i < name.Length; i++)
            {
                if(name[i] == 'a')
                {
                    stringToReturn += '4';
                }
                else if(name[i] == 'o')
                {
                    stringToReturn += '0';
                }
                else if(name[i] == 'e')
                {
                    stringToReturn += '3';
                }
                else
                {
                    stringToReturn += name[i];
                }
            }
            return stringToReturn;
        }

        static string OnlyO(string name)
        {
            var stringToReturn = "";

            for(int i = 0; i < name.Length; i++){
                if(name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u' || name[i] == 'y')
                {
                    stringToReturn += 'o';
                }
                else{
                    stringToReturn += name[i];
                }
            }
            return stringToReturn;
        }
    }
}
