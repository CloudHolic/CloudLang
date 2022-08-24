using CloudLang.Repls;

Console.WriteLine("CloudLang Sample Interpreter");

using var reader = new StreamReader(Console.OpenStandardInput());
using var writer = new StreamWriter(Console.OpenStandardOutput());

writer.AutoFlush = true;
Repl.Start(reader, writer);