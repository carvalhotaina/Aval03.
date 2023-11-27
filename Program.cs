using System;

class Program
{
    static void Main()
    {
        //taina carvalho 2 semetre sistemas
        string textoCifrado = "Lu0s z q0tm0uƒ€q~x ƒ40t ‚uy~t (~ 0†w|q~„mPe}q(†ytq(q‚q‚i0…}0uy~…„w0y‚‚m|u†qv„uPeu0q„qy…u0tm0 † (u}0†é‚yqƒ(s ‚u{0u0„i}q~xwƒPTqvt 0ri|qƒ0m0sywi‚‚ ƒ(u0sqz ~qƒ(q0uƒ|‚q~xwƒPSqz‚ ƒ0wƒƒ 0lyŠu~l 0ƒyuP_0ƒq~q|0o‚y„qvt 0~ë PTu~u0ƒuz0yƒƒw0 …u(sxq}i}0tu(‚uƒƒ}‚uy÷ë PPSi€y„qt0Y~ykyq|PZuƒƒ…z‚uy÷ë ";

        string textoDecifrado = DecifrarDeTeusPulos(textoCifrado);

        textoDecifrado = textoDecifrado.Replace('@', '\n');

        string[] palindromos = { "deed", "level", "civic" }; 
        for (int i = 0; i < palindromos.Length; i++)
        {
            textoDecifrado = SubstituirPalindromo(textoDecifrado, palindromos[i], new[] { "gloriosa", "bondade", "passam" }[i]);
        }

        Console.WriteLine("Conteúdo do texto cifrado:");
        Console.WriteLine(textoCifrado);

        Console.WriteLine("\nPalíndromos encontrados:");
        foreach (var palindromo in palindromos)
        {
            Console.WriteLine(palindromo);
        }

        Console.WriteLine("\nNúmero de caracteres do texto decifrado:");
        Console.WriteLine(textoDecifrado.Length);

        Console.WriteLine("\nNúmero de palavras do texto decifrado:");
        Console.WriteLine(ContarPalavras(textoDecifrado));

        // Exibe o texto decifrado em maiúsculo
        Console.WriteLine("\nTexto decifrado em maiúsculo:");
        Console.WriteLine(textoDecifrado.ToUpper());
    }

    static string DecifrarDeTeusPulos(string textoCifrado)
    {
        char[] caracteresCifrados = textoCifrado.ToCharArray();
        char[] caracteresDecifrados = new char[caracteresCifrados.Length];

        for (int i = 0; i < caracteresCifrados.Length; i++)
        {
            if (i % 5 == 0)
            {
                caracteresDecifrados[i] = (char)(caracteresCifrados[i] - 8);
            }
            else
            {
                caracteresDecifrados[i] = (char)(caracteresCifrados[i] - 16);
            }
        }

        return new string(caracteresDecifrados);
    }

    static string SubstituirPalindromo(string texto, string palindromo, string substituicao)
    {
        return texto.Replace(palindromo, substituicao);
    }

    static int ContarPalavras(string texto)
    {
        string[] palavras = texto.Split(new[] { ' ', '\t', '\n', '\r', '\f' }, StringSplitOptions.RemoveEmptyEntries);

        return palavras.Length;
    }
}
