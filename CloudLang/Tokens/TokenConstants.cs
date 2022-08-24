namespace CloudLang.Tokens;

public class TokenConstants
{
    public const TokenType Illegal = "ILLEGAL";
    public const TokenType Eof = "EOF";

    // Identifiers + Literals
    public const TokenType Ident = "IDENT";
    public const TokenType Int = "INT";

    // Operators
    public const TokenType Assign = "=";
    public const TokenType Plus = "+";
    public const TokenType Minus = "-";
    public const TokenType Asterisk = "*";
    public const TokenType Slash = "/";
    public const TokenType Bang = "!";

    public const TokenType Lt = "<";
    public const TokenType Gt = ">";

    public const TokenType Eq = "==";
    public const TokenType NotEq = "!=";

    // Delimiters
    public const TokenType Comma = ",";
    public const TokenType Semicolon = ";";

    public const TokenType LParen = "(";
    public const TokenType RParen = ")";
    public const TokenType LBrace = "{";
    public const TokenType RBrace = "}";

    // Keywords
    public const TokenType Function = "FUNCTION";
    public const TokenType Let = "LET";
    public const TokenType True = "TRUE";
    public const TokenType False = "FALSE";
    public const TokenType If = "IF";
    public const TokenType Else = "ELSE";
    public const TokenType Return = "RETURN";
}