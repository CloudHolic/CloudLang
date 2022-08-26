using CloudLang.Tokens;

namespace CloudLang.Asts;

public class Let : IStatement
{
    private readonly Token _token;
    private Identifier _name;
    private IExpression _value;

    public Let()
    {
        _token = new Token(TokenConstants.Let, "let");
    }

    public string TokenLiteral()
    {
        return _token.Literals;
    }

    public void StatementNode()
    {

    }
}