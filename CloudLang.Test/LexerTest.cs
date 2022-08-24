using CloudLang.Lexers;
using CloudLang.Tokens;

namespace CloudLang.Test;

public class LexerTest
{
    [Fact]
    public void Test1()
    {
        const string testCode = @"let five = 5;
let ten = 10;

let add = fn(x, y)
{
    x + y;
};

let result = add(five, ten);
!-/*5;
5 < 10 > 5;

if (5 < 10) {
	return true;
} else {
	return false;
}

10 == 10;
10 != 9;
";

        var expectedResult = new Token[]
        {
            new(TokenConstants.Let, "let"),
            new(TokenConstants.Ident, "five"),
            new(TokenConstants.Assign, "="),
            new(TokenConstants.Int, "5"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Let, "let"),
            new(TokenConstants.Ident, "ten"),
            new(TokenConstants.Assign, "="),
            new(TokenConstants.Int, "10"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Let, "let"),
            new(TokenConstants.Ident, "add"),
            new(TokenConstants.Assign, "="),
            new(TokenConstants.Function, "fn"),
            new(TokenConstants.LParen, "("),
            new(TokenConstants.Ident, "x"),
            new(TokenConstants.Comma, ","),
            new(TokenConstants.Ident, "y"),
            new(TokenConstants.RParen, ")"),
            new(TokenConstants.LBrace, "{"),
            new(TokenConstants.Ident, "x"),
            new(TokenConstants.Plus, "+"),
            new(TokenConstants.Ident, "y"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.RBrace, "}"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Let, "let"),
            new(TokenConstants.Ident, "result"),
            new(TokenConstants.Assign, "="),
            new(TokenConstants.Ident, "add"),
            new(TokenConstants.LParen, "("),
            new(TokenConstants.Ident, "five"),
            new(TokenConstants.Comma, ","),
            new(TokenConstants.Ident, "ten"),
            new(TokenConstants.RParen, ")"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Bang, "!"),
            new(TokenConstants.Minus, "-"),
            new(TokenConstants.Slash, "/"),
            new(TokenConstants.Asterisk, "*"),
            new(TokenConstants.Int, "5"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Int, "5"),
            new(TokenConstants.Lt, "<"),
            new(TokenConstants.Int, "10"),
            new(TokenConstants.Gt, ">"),
            new(TokenConstants.Int, "5"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.If, "if"),
            new(TokenConstants.LParen, "("),
            new(TokenConstants.Int, "5"),
            new(TokenConstants.Lt, "<"),
            new(TokenConstants.Int, "10"),
            new(TokenConstants.RParen, ")"),
            new(TokenConstants.LBrace, "{"),
            new(TokenConstants.Return, "return"),
            new(TokenConstants.True, "true"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.RBrace, "}"),
            new(TokenConstants.Else, "else"),
            new(TokenConstants.LBrace, "{"),
            new(TokenConstants.Return, "return"),
            new(TokenConstants.False, "false"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.RBrace, "}"),
            new(TokenConstants.Int, "10"),
            new(TokenConstants.Eq, "=="),
            new(TokenConstants.Int, "10"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Int, "10"),
            new(TokenConstants.NotEq, "!="),
            new(TokenConstants.Int, "9"),
            new(TokenConstants.Semicolon, ";"),
            new(TokenConstants.Eof, "")
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