# Calculator Coding/Design Exercise

## Problems With Original Implementation

### Lack of Input Validation

No input parameter null checks, or format validation to ensure the command string conforms to the specification - code assumes that everything which isn't a numeric value must be an operator. 

This is addressed in the updated version by separating execution into expression parsing and evaluation phases. Issues in the input format are detected in the parse phase, and a custom exception is thrown to the caller.

### Use of Error Handling For Data Type Validation

Allowing exceptions to propagate is expensive so best avoided where possible. Safe parsing can be achieved via the framework TryParse() methods - these should be used instead of Parse() when the input is untrusted. 

### Catch-All Blocks

Catch block in original code will catch all exceptions - not just FormatExceptions from failed Parse calls. Will also catch OverflowExceptions for example, which isn't the intention.

### Unmaintainable Code

This original code is very hard to extend if/when the features change, and would therefore have to be rewritten. By applying principles of separation of concerns, a far more maintainable structure can be produced.  

### Test Coverage

The single unit test only covers a single happy-day path through the system and none of the edge cases. 

## Comments On Design

The design is fairly clear in intent, although before commencing work on the feature I would clarify a couple of points with the designer:
1. The design states:
```
decimal_number::= digits | digits ‘.’ digits
digits::= '0' | non_zero_digit digits*
```

This seems to exclude valid decimals like 0.01. However for the purposes of this exercise, I've assumed all valid decimals should be allowed.

2. It is also unclear whether the * operator means *zero or more*, or *one or more*:
```
digits::= '0' | non_zero_digit digits*
```
would suggest it means zero or more (i.e. 3.1 is a valid decimal), however:
```
expression* signed_decimal
```
suggests 1 or more (i.e. at least one expression is required).

3. The original design also encourages the use of whitespace to separate the terms in the implementation. While this will work, it would be more flexible to allow either e.g. '2 * 2' or '2*2'. The implementation included addresses this.

## Updated Solution

Created in vscode.

### Overview

The calculator works as follows: 
- The command expression is passed to an instance of SimpleCalculator
- The SimpleCalculator invokes the command parser
- The command parser first pre-processes the command to remove all whitespace characters
- The command parser invokes the StringTokenizer to split the input command into a series of tokens by identifying the operator characters and using these as the locations to split the string
- The resulting tokens are used to build a series of Nodes - of type 'Number' or 'Operator' - abstractly representing the structure of the command
- The abstract base class, and its concrete implementation 'SimpleCalcEngine' evaluates the nodes and returns the result. The result is returned as type 'object' as it could be either an int or a decimal
- The SimpleCalculatorIntegration tests show the process working end-to-end

### Areas for Improvement

- Unit Test coverage is not perfect - there are more edge cases for the command parsing which should be included in coverage.
- The CommandParser unit tests don't mock out the class dependencies. Unit tests should test the classes in isolation.
- There is a hack (marked in the code) to cope with negative/positive number symbols in the CommandParser - this would be better handled within the Tokenizer. 
- The node structure which represents the command is currently stored and evalulated in a flat list. In a real-world application, if the commands were likely to become more complex a more flexible representation could be produced using an expression tree e.g. using the Interpreter pattern.

