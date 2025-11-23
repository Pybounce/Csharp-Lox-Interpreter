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
