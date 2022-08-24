using CloudLang.Lexers;
using CloudLang.Tokens;

namespace CloudLang.Repls;

public static class Repl
{
    private const string Prompt = ">> ";

    public static void Start(StreamReader reader, StreamWriter writer)
    {
        for (;;)
        {
            writer.Write(Prompt);
            var line = reader.ReadLine();
            if (string.IsNullOrEmpty(line))
                break;

            var lexer = new Lexer(line);
            for (var token = lexer.NextToken(); token.Type != TokenConstants.Eof; token = lexer.NextToken())
                writer.WriteLine(token);
        }
    }
}