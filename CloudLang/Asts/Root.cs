namespace CloudLang.Asts;

public class Root : INode
{
    private readonly List<IStatement> _statements;

    public Root()
    {
        _statements = new List<IStatement>();
    }

    public string TokenLiteral()
    {
        return _statements.Count > 0 ? _statements[0].TokenLiteral() : "";
    }
}