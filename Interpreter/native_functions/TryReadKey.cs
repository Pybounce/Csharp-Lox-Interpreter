
namespace lox.native_functions;


public class TryReadKey : LoxCallable
{
    public int Arity() => 0;

    public object Call(Interpreter interpreter, Token paren, List<object> args)
    {
        return Console.KeyAvailable ? Console.ReadKey() : null;
    }
}