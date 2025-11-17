
namespace lox.native_functions;


public class Clear : LoxCallable
{
    public int Arity() => 0;

    public object Call(Interpreter interpreter, Token paren, List<object> args)
    {
        Console.Clear();
        return null;
    }
}