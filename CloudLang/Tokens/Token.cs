using System.Collections.Immutable;

namespace CloudLang.Tokens;

public record Token
{
    public TokenType Type { get; init; }

    public string Literals { get; init; }

    private ImmutableDictionary<string, TokenType> _keywords = ImmutableDictionary<string, TokenType>.Empty;

    public Token(TokenType type, string literals)
    {
        BuildDictionary();
        
        Type = type;
        Literals = literals;
    }

    public Token(string literals)
    {
        BuildDictionary();

        Type = Lookup(literals);
        Literals = literals;
    }

    private void BuildDictionary()
    {
        _keywords = 
            ImmutableDictionary<string, TokenType>.Empty
                .Add("fn", TokenConstants.Function)
                .Add("let", TokenConstants.Let)
                .Add("true", TokenConstants.True)
                .Add("false", TokenConstants.False)
                .Add("if", TokenConstants.If)
                .Add("else", TokenConstants.Else)
                .Add("return", TokenConstants.Return);
    }

    private TokenType Lookup(string ident)
    {
        return _keywords.ContainsKey(ident) ? _keywords[ident] : TokenConstants.Ident;
    }
}