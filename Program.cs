using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        //taina carvalho 1 fase de sistemas
        string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        string textoDecifrado = decifrar(textoCifrado);
        textoDecifrado = textoDecifrado.Replace("@", "\n");

        string[] palindromos = palindromo(textoDecifrado);

        Console.WriteLine("Palíndromos encontrados: ");
        foreach (var p in palindromos)
        {
            if (p.Length > 2)
                Console.WriteLine(p);
        }

        textoDecifrado = SubstituirPalindromos(textoDecifrado, palindromos);
        Console.WriteLine("\nTexto decifrado em maiúsculas: \n" + textoDecifrado.ToUpper());

        // Contagem de caracteres e palavras
        int numeroCaracteres = textoDecifrado.Length;
        int numeroPalavras = textoDecifrado.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        Console.WriteLine("\nNúmero de caracteres da mensagem decifrada: " + numeroCaracteres);
        Console.WriteLine("\nQuantidade de palavras no texto decifrado: " + numeroPalavras);
    }

    static string decifrar(string textoCifrado)
    {
        char[] caracteresCifrados = textoCifrado.ToCharArray();
        for (int i = 0; i < caracteresCifrados.Length; i++)
        {
            int chave = (i % 5 == 0) ? 8 : 16;
            caracteresCifrados[i] = (char)(caracteresCifrados[i] - chave);
        }
        return new string(caracteresCifrados);
    }

    static string[] palindromo(string texto)
    {
        return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(palavra =>
            {
                char[] caracteres = palavra.ToCharArray();
                Array.Reverse(caracteres);
                return palavra.Equals(new string(caracteres), StringComparison.OrdinalIgnoreCase);
            })
            .ToArray();
    }

    static string SubstituirPalindromos(string texto, string[] palindromos)
    {
        foreach (var palavra in palindromos)
        {
            if (palavra.Length > 2)
            {
                string substituicao = "";
                switch (palavra.ToLower())
                {
                    case "arara":
                        substituicao = "gloriosa";
                        break;
                    case "ovo":
                        substituicao = "bondade";
                        break;
                    case "osso":
                        substituicao = "passam";
                        break;
                    // Adicione mais casos para outros palíndromos, se necessário
                }

                texto = texto.Replace(palavra, substituicao);
            }
        }

        return texto;
    }
}
