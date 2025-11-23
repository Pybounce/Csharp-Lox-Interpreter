**Rough Plan**

// So to begin, push the array of statements that make the program onto the statement stack
// When I run Step(), eval a statement
// If a statement contains a statement, just push those onto the step
// If I run Step() with no statements in the stack, program complete.

revised below

make a stack
replace execute method with pushing something to the top of the stack
BUT, will need to change the ordering such that a block pushes things in reverse order since the stack is evaluated from the top.
Might not be able to just replace execute given we still need a way to actually execute statements in the stack but can RENAME it?

so program is a list of statements.
push them onto the stack in reverse order
while stack has values, take the top one, execute it.
that execution may push more statements onto the stack

**While Statements**

```cs
// push the following
var whileBlock = new Stmt.Block(new List<Stmt>()
{
    stmt.Body,
    stmt,
});
var ifStatement = new Stmt.If(stmt.Condition, whileBlock, null);
```

example

```cs
while (x > 5) {
    print "larger";
    x -= 1;
}
```

the while statement is raised
condition is

```cs
x > 5
```

body is

```cs
    print "larger";
    x -= 1;
```

statment pushed to the stack is

```cs
if (x > 5) {
    print "larger";
    x -= 1;
    while (x > 5) {
        print "larger";
        x -= 1;
    }
}
```

which starts a loop until x is not greater than 5.

**alternate while statements**

this is the original while

```cs
public Nothing VisitWhileStmt(Stmt.While stmt)
{
    while (IsTruthy(Evaluate(stmt.Condition)))
    {
        Execute(stmt.Body);
    }

    return new Nothing();
}
```

so using the stack I would usually do something like

````cs
public Nothing VisitWhileStmt(Stmt.While stmt)
{
    PushToStack(stmt);
    return new Nothing();
}
```cs
public Nothing ExecuteWhileStmt(Stmt.While stmt)
{
    if (IsTruthy(Evaluate(stmt.Condition)) == false) {
        StatementStackPop();
        // remove the while from the stack
    }
    else if (IsTruthy(Evaluate(stmt.Condition)))    // can just be else
    {
        PushToStack(stmt.Body);
    }

    return new Nothing();
}
````

this way, the while statement is only popped when it becomes false. otherwise we push the body
then the body is executed since it's on top of the stack, it is eventually popped, and then we hit the while loop again
