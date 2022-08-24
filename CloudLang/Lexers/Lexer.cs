using CloudLang.Tokens;

namespace CloudLang.Lexers;

public class Lexer
{
    private readonly string _input;
    private int _position, _nextPosition;
    private char _char;

    public Lexer(string input)
    {
        _input = input; //string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
        _position = _nextPosition = 0;
        _char = (char)0;

        ReadChar();
    }

    public Token NextToken()
    {
        var skipRead = false;

        SkipWhitespace();

        Func<Token> tokenGenerator = _char switch
        {
            '=' => () =>
            {
                if (PeekChar() != '=')
                    return new(TokenConstants.Assign, "=");

                ReadChar();
                return new(TokenConstants.Eq, "==");
            },
            '+' => () => new(TokenConstants.Plus, "+"),
            '-' => () => new(TokenConstants.Minus, "-"),
            '!' => () =>
            {
                if (PeekChar() != '=') 
                    return new(TokenConstants.Bang, "!");

                ReadChar();
                return new(TokenConstants.NotEq, "!=");
            },
            '/' => () => new(TokenConstants.Slash, "/"),
            '*' => () => new(TokenConstants.Asterisk, "*"),
            '<' => () => new(TokenConstants.Lt, "<"),
            '>' => () => new(TokenConstants.Gt, ">"),
            ';' => () => new(TokenConstants.Semicolon, ";"),
            ',' => () => new(TokenConstants.Comma, ","),
            '{' => () => new(TokenConstants.LBrace, "{"),
            '}' => () => new(TokenConstants.RBrace, "}"),
            '(' => () => new(TokenConstants.LParen, "("),
            ')' => () => new(TokenConstants.RParen, ")"),
            (char)0 => () => new(TokenConstants.Eof, ""),
            var c when IsLetter(c) => () =>
            {
                skipRead = true;
                return new(ReadIdentifier(IsLetter));
            },
            var c when IsDigit(c) => () =>
            {
                skipRead = true;
                return new(TokenConstants.Int, ReadIdentifier(IsDigit));
            },
            _ => () => new(TokenConstants.Illegal, "")
        };

        var token = tokenGenerator();
        if(!skipRead)
            ReadChar();
        return token;
    }

    private void SkipWhitespace()
    {
        while (_char is ' ' or '\t' or '\n' or '\r')
            ReadChar();
    }

    private void ReadChar()
    {
        _char = _nextPosition switch
        {
            var p when p >= _input.Length => (char) 0,
            _ => _input[_nextPosition]
        };

        _position = _nextPosition++;
    }

    private char PeekChar()
    {
        return _nextPosition switch
        {
            var p when p >= _input.Length => (char)0,
            _ => _input[_nextPosition]
        };
    }

    private string ReadIdentifier(Func<char, bool> checker)
    {
        var position = _position;
        while (checker(_char))
            ReadChar();

        return _input.Substring(position, _position - position);
    }

    private static bool IsLetter(char c)
    {
        return c is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or '_';
    }

    private static bool IsDigit(char c)
    {
        return c is >= '0' and <= '9';
    }
}