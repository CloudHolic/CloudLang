using CloudLang.Lexers;
using CloudLang.Tokens;

namespace CloudLang.Test;

public class LexerTest
{
    [Fact]
    public void Test1()
    {
        const string testCode = "=+(){},;";

        var expectedResult = new Token[]{
            new (TokenConstants.Assign, "="),
            new (TokenConstants.Plus, "+"),
            new (TokenConstants.LParen, "("),
            new (TokenConstants.RParen, ")"),
            new (TokenConstants.LBrace, "{"),
            new (TokenConstants.RBrace, "}"),
            new (TokenConstants.Comma, ","),
            new (TokenConstants.Semicolon, ";"),
        };

        var lexer = new Lexer(testCode);

        foreach (var expected in expectedResult)
        {
            var token = lexer.NextToken();
            
            Assert.Equal(expected.Type, token.Type);
            Assert.Equal(expected.Literals, token.Literals);
        }
    }
}