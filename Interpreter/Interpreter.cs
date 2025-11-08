


public class Interpreter : Expr.Visitor<Object>
{
    public object VisitBinaryExpr(Expr.Binary expr)
    {
        var left = Evaluate(expr.left);
        var right = Evaluate(expr.right);

        switch (expr.op.TokenType)
        {
            case TokenType.MINUS: return (double)left - (double)right;
            case TokenType.STAR: return (double)left * (double)right;
            case TokenType.SLASH: return (double)left / (double)right;
            case TokenType.PLUS: 
                if (left is double && right is double) { return (double)left + (double)right; }
                if (left is string && right is string) { return (string)left + (string)right; }
                break;
            case TokenType.GREATER: return (double)left > (double)right;
            case TokenType.GREATER_EQUAL: return (double)left >= (double)right;
            case TokenType.LESS: return (double)left < (double)right;
            case TokenType.LESS_EQUAL: return (double)left <= (double)right;
            case TokenType.EQUAL: return IsEqual(left, right);
            case TokenType.BANG_EQUAL: return !IsEqual(left, right);
        }

        return null;
    }

    public object VisitGroupingExpr(Expr.Grouping expr)
    {
        return Evaluate(expr.expression);
    }

    public object VisitLiteralExpr(Expr.Literal expr)
    {
        return expr.value;
    }

    public object VisitUnaryExpr(Expr.Unary expr)
    {
        var right = Evaluate(expr.right);
        switch (expr.op.TokenType)
        {
            case TokenType.MINUS:
                return -(double)right;
            case TokenType.BANG:
                return !IsTruthy(right);
        }
        return null;
    }

    private object Evaluate(Expr expr)
    {
        return expr.Accept(this);
    }

    private bool IsTruthy(Object obj)
    {
        if (obj == null) { return false; }
        if (obj is bool) { return (bool)obj; }
        return true;
    }

    private bool IsEqual(object a, object b)
    {
        if (a == null && b == null) { return true; }
        if (a == null) { return false; }
        return a.Equals(b);
    }
}