using CloudLang.Tokens;

namespace CloudLang.Asts;

public class Identifier : IExpression
{
    private readonly Token _token;
    private readonly string _value;

    public Identifier()
    {
        _token = new Token(TokenConstants.Ident, "");

    }

    public string TokenLiteral()
    {
        return _token.Literals;
    }

    public void ExpressionNode()
    {
        throw new NotImplementedException();
    }
}