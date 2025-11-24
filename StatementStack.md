**Could have expressions in the stack**

If I maintain a value-stack for anything that expressions return
Then on assigment, instead of something like

```cs
    public object VisitAssignExpr(Expr.Assign expr)
    {
        var value = Evaluate(expr.value);
        _environment.Assign(expr.name, value);
        return value;
    }
```

It would be more like...

```cs
    public object VisitAssignExpr(Expr.Assign expr)
    {
        stack.push(StackEvent.Assign(expr.name));
        stack.push(Evaluate(expr.value));
    }
    public void Assign() {
        _environment.Assign(expr.name, valueStack.Peek());  // only peek since we return assigned values anyway in the original
    }
```

Then uh....I guess expressions always just push to the stack...but then we would need to split them up which sounds like a fucking pain ok fuck that sound maybe just some scuffed thing for functions
That...or we go the extra mile and define a new set of events that are more granular than an AST node. Similar to byte code but not as granular.
