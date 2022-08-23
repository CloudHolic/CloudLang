using CloudLang.Tokens;

namespace CloudLang.Lexers;

public class Lexer
{
    private readonly string _input;
    private int _position, _nextPosition;
    private char _char;

    public Lexer(string input)
    {
        _input = input;
        _position = _nextPosition = 0;
        _char = (char)0;

        ReadChar();
    }

    public Token NextToken()
    {
        var token = _char switch
        {
            '=' => new Token(TokenConstants.Assign, "="),
            ';' => new Token(TokenConstants.Semicolon, ";"),
            '(' => new Token(TokenConstants.LParen, "("),
            ')' => new Token(TokenConstants.RParen, ")"),
            ',' => new Token(TokenConstants.Comma, ","),
            '+' => new Token(TokenConstants.Plus, "+"),
            '{' => new Token(TokenConstants.LBrace, "{"),
            '}' => new Token(TokenConstants.RBrace, "}"),
            (char) 0 => new Token(TokenConstants.Eof, "")
        };

        ReadChar();
        return token;
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
}