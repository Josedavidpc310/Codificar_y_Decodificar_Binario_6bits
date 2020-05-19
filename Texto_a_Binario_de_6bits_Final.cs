using System;

namespace Texto_a_Binario_de_6bits_Final
{
    class Program
    {
    static void Main(string[] args)
        {
            string m = "";
            Console.WriteLine("Escribe Texto");
            String cadena = Console.ReadLine().Replace(" ","_").ToUpper();
            for (int f10 = 0; f10 < cadena.Length; f10++)
            {
              m += BINARIO(cadena[f10].ToString())+" ";
            }
            Console.Write("Su texto en binario de 6Bits es: \r\n" + m+ "\r\n");
            Console.WriteLine("Escribe Binario de 6Bits");
            String codigo= Console.ReadLine();
            codigo = codigo.Replace(" ","");//quitando espacios en caso de que hayan
            for (int i = 0; i < codigo.Length; i++)//Verificando que este compuesto por unos y ceros
            {
                if (codigo[i].ToString() == "0" || codigo[i].ToString() == "1")
                {
                }
                else {
                    Console.WriteLine("El codigo ingresado no corresponde a binario de 6bits");
                    break;
                }
            }
            if ((codigo.Length+1)%6==0)//verificando que sus cadenas sean de 6 bits
            {
                Console.WriteLine("El codigo ingresado no corresponde a binario de 6bits");
            }
            Console.WriteLine(Decodificar(codigo));
            Console.Read();
        }
            public static String BINARIO(String Letra)
            {
            String[] Character = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "[", "#", "@", ":", ">", "?", "_", "A", "B", "C", "D", "E", "F", "G", "H", "I", "&", ".", "]", "(", "<", "\\", "^", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "-", "$", "*", ")", ";", "'", "+", "/", "S", "T", "U", "V", "W", "X", "Y", "Z", "<", ",", "%", "=", "\"", "!" };
            int CharacterCode=65,CodePart1,CodePart2;
            String binario="";
            for (int C = 0; C < Character.Length; C++)
                {
                    if (Letra==Character[C])
                    {
                    CharacterCode = C;
                    break;
                    }
                }

            if (CharacterCode == 65)//si el caracter no esta en la lista
            {
                Console.WriteLine("Imposible codificar " + Letra);
                CharacterCode = 20;
            }

            if (CharacterCode>55)
            {
                CharacterCode += 14;
            }
            else if (CharacterCode >47)
            {
                CharacterCode += 12;
            }
            else if (CharacterCode >39)
            {
                CharacterCode += 10;
            }
            else if (CharacterCode >31)
            {
                CharacterCode += 8;
            }
            else if (CharacterCode >23)
            {
                CharacterCode += 6;
            }
            else if (CharacterCode >15)
            {
                CharacterCode += 4;
            }
            else if (CharacterCode >7)
            {
                CharacterCode += 2;
            }
            if (CharacterCode > 7) {
                CodePart1=CharacterCode.ToString()[0];
                CodePart2 = CharacterCode.ToString()[1];
            }
            else
            {
                CodePart1 = 0;
                CodePart2 = CharacterCode;
            }
            binario = BITS(CodePart1)+BITS(CodePart2);
            return binario;
        }

        public static string BITS(int Code) {
            string resto = "";
            string bits = "";

            while (true)
            {
                if (Code%2==0)
                {
                    resto = resto + "0";
                }
                else
                {
                    resto = resto + "1";
                }
                Code /= 2;
                if (Code<1)
                {
                    break;
                }
            }

            for (int i = resto.Length; i >= 1; i += -1)
            {
                bits = bits + resto.Substring(i - 1, 1);
            }
            while (true)
            {
                if (bits.Length<3)
                {
                    bits = "0"+bits;
                }
                else
                {
                    break;
                }
            }
            if (bits.Length > 3)//si el binario exede los 3 bits
            {
                bits=bits.Remove(0,3);
            }          
            return bits;
        }
        public static String Decodificar(String codigo) {
            String[] Character = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "[", "#", "@", ":", ">", "?", "_", "A", "B", "C", "D", "E", "F", "G", "H", "I", "&", ".", "]", "(", "<", "\\", " ^ ", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "-", "$", "*", ")", ";", "'", "+", "/", "S", "T", "U", "V", "W", "X", "Y", "Z", "<", ",", "%", "=", "\"", "!" };
            int Caracteres = codigo.Length / 6;
            string Caracter = "",Palabra="";
            int CodigoCaracter1, CodigoCaracter2;

            for (int i = 0; i < Caracteres; i++)
            {
                CodigoCaracter1 = 0;
                CodigoCaracter2 = 0;
                Caracter = "";
                Caracter = codigo.Substring(0,6);
                codigo=codigo.Remove(0,6);
                if (Caracter[0].ToString()=="1")
                {
                    CodigoCaracter1+=4;
                }
                if (Caracter[1].ToString() == "1")
                {
                    CodigoCaracter1 += 2;
                }
                if (Caracter[2].ToString() == "1")
                {
                    CodigoCaracter1 += 1;
                }
                if (Caracter[3].ToString() == "1")
                {
                    CodigoCaracter2 += 4;
                }
                if (Caracter[4].ToString() == "1")
                {
                    CodigoCaracter2 += 2;
                }
                if (Caracter[5].ToString() == "1")
                {
                    CodigoCaracter2 += 1;
                }
                Caracter = CodigoCaracter1 + "" + CodigoCaracter2;


                if (Convert.ToInt32(Caracter) > 67)
                {
                    Caracter = (Convert.ToInt32(Caracter) - 14).ToString();
                }
                else if (Convert.ToInt32(Caracter) > 57)
                {
                    Caracter = (Convert.ToInt32(Caracter) - 12).ToString();
                }
                else if (Convert.ToInt32(Caracter) > 47)
                {
                    Caracter = (Convert.ToInt32(Caracter) - 10).ToString();
                }
                else if (Convert.ToInt32(Caracter) > 37)
                {
                    Caracter = (Convert.ToInt32(Caracter) - 8).ToString();
                }
                else if (Convert.ToInt32(Caracter) > 27)
                {
                    Caracter = (Convert.ToInt32(Caracter) - 6).ToString();
                }
                else if (Convert.ToInt32(Caracter) > 17)
                {
                    Caracter = (Convert.ToInt32(Caracter) - 4).ToString();
                }
                else if (Convert.ToInt32(Caracter) > 7)
                {
                    Caracter=(Convert.ToInt32(Caracter)- 2).ToString();
                }

                for (int j = 0; j < Character.Length; j++)
                {
                    if (j==Convert.ToInt32(Caracter))
                    {
                        Palabra += ""+Character[j];
                    }
                }
            }
        return Palabra;
        }
    }
}