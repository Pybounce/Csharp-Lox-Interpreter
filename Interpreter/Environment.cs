

public class Environment
{
    private readonly Dictionary<string, object> _values = new Dictionary<string, object>();


    public void Define(string name, object value)
    {
        _values[name] = value;
    }

    public object Get(Token token)
    {
        if (_values.TryGetValue(token.Lexeme, out var value))
        {
            return value;
        }

        throw new RuntimeError(token, $"Undefined variable '{token.Lexeme}'.");
    }
}