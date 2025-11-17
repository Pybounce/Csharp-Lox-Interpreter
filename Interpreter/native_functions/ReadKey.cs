
namespace lox.native_functions;


public class ReadKey : LoxCallable
{
    public int Arity() => 0;

    public object Call(Interpreter interpreter, Token paren, List<object> args)
    {
        return Console.ReadKey(true).KeyChar.ToString();
    }
}