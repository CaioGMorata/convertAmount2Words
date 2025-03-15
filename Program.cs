using System;

namespace EX_1
{
    class Program
    {
        private static string convertAmount2Words(int m_integer, int m_decimals)
        {
            //if (m_integer == 0) return "zero";

            string words = ConvertInteger2Words(m_integer); //Call integer part
            string decimals;

            if (words != "") //Treats Singular and Plural
            {
                words += (words == "um" ? " real" : " reais");
            }           

            if (m_decimals > 0)
            {
                if (words != "")
                {
                    decimals = ConvertInteger2Words(m_decimals); //Call decimals part
                    if (decimals != "um") //Treats Singular and Plural
                    {
                        words += " e " + decimals + " centavos";
                    }
                    else
                    {
                        words += " e " + decimals + " centavo";
                    }
                }
                else
                {
                    decimals = ConvertInteger2Words(m_decimals); //Call decimals part
                    if (decimals != "um") //Treats Singular and Plural
                    {
                        words += decimals + " centavos";
                    }
                    else
                    {
                        words += decimals + " centavo";
                    }
                }
                
            }

            return words;
        }

        private static string ConvertInteger2Words(int number)
        {
            if (number == 0) return "";

            string[] units = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            string[] teens = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] tens = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] hundreds = { "", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

            string words = "";

            if (number >= 1000000)
            {
                int millions = number / 1000000;
                words += ConvertInteger2Words(millions) + (millions == 1 ? " milhão" : " milhões"); //Call recursion function
                number %= 1000000; //Reduce number to complete number description
                if (number > 0) words += " e "; //Treat "e" letter 
            }

            if (number >= 1000)
            {
                int thousands = number / 1000;
                if (thousands == 1)
                    words += "mil"; //Treat "mil" word
                else
                    words += ConvertInteger2Words(thousands) + " mil";  //Call recursion function
                number %= 1000; //Reduce number to complete number description
                if (number > 0) words += " e "; //Treat "e" letter
            }

            if (number >= 100)
            {
                int hundred = number / 100;
                words += (number == 100) ? "cem" : hundreds[hundred]; //Treat "cem" word
                number %= 100; //Reduce number to complete number description
                if (number > 0) words += " e "; //Treat "e" letter
            }

            if (number >= 20)
            {
                int ten = number / 10;
                words += tens[ten];
                number %= 10; //Reduce number to complete number description
                if (number > 0) words += " e "; //Treat "e" letter
            }

            if (number >= 10)
            {
                words += teens[number - 10]; //Complete description
                number = 0;
            }

            if (number > 0)
            {
                words += units[number]; //Complete description
            }

            return words;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(convertAmount2Words(123456789, 1));
            Console.WriteLine(convertAmount2Words(1, 1));
            
        }
    }
}
