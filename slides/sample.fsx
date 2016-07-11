(**
- title : Basic concepts of Functional Programming
- description : Basic concepts of Functional Programming
- author : Tomasz Heimowski
- theme : night
- transition : default

***

## F# CAMP

### Basic concepts of Functional Programming

### Tomasz Heimowski

    [lang=bash]
    git clone https://github.com/theimowski/fsharp-workshops-basics.git

or download the package from [here](https://github.com/theimowski/fsharp-workshops-basics/archive/master.zip), and then:

    [lang=bash]
    cd fsharp-workshops-basics
    .\build.cmd KeepRunning

---

### Agenda

* Workshop Format
* Immutable values
* Recursion
* Expressions

***

## Workshop format

---

### Problem to solve: ONP notation

[ONP on Wiki](https://pl.wikipedia.org/wiki/Odwrotna_notacja_polska)

Conventional format:

    ((2+7)/3+(14-3)*4)+3

ONP format:

    2 7 + 3 / 14 3 - 4 * + 3 +

---

### New Stuff X.X
#### Something new *)
// code
(**

---

### Example X.X
#### Some example *)
let example = "example"
(** #### Result: *)
(*** include-value: ``example`` ***)
(**

---

### Exercise X.X
Exercise:

#### Your code goes below: *)
let exercise = "exercise"
(** #### Result: *)
(*** include-value: ``exercise`` ***)
(**


***

## Immutable values

---

### New Stuff 1.1
#### Let bindings *)
let value = 5
(** #### Type inference *)
let stringValue = "Hi there"
let integerValue = 100
(** #### Backticks names *)
let ``I can have spaces`` = "I really do"
(**

---

### Example 1.1
#### Processing an immutable value
``System.String`` is an example of immutable type in .NET *)
let helloWorld = "Hello World from F# program!"
let replaced = helloWorld.Replace("o", "u")
let substring = replaced.Substring(0, replaced.IndexOf("#") + 1)
let ``example 1.1`` = substring.ToLower()
(** #### Result: *)
(*** include-value: ``example 1.1`` ***)
(**

---

### Exercise 1.1
Compute below expression with help of `let` bindings for each computation step (remember about operator precedence) :

    200+(10/2)*5-50

#### Your code goes below: *)
let ``exercise 1.1`` = 0
(** #### Result: *)
(*** include-value: ``exercise 1.1`` ***)
(**



---

### New Stuff 1.2
#### Range operator  *)
let range = [28 .. 38]
(*** include-value: range ***)
(** ---
#### Function declaration *)
let add x y =
    x + y
let addResult = add 5 6
(*** include-value: addResult ***)
(** ---
#### Pipe operator *)
let pipeResult =
    10
    |> add 15
    |> add 6
(*** include-value: pipeResult ***)
(**

---

### Example 1.2
#### LINQ-like list processing
Note: a new immutable value is created in each computation step

[C# version](http://theimowski.com/fsharp-workshops-intro/#/4/3) *)
let odd number =
    number % 2 = 1

let ``example 1.2`` = 
    [2 .. 10]
    |> List.filter odd
    |> List.map string
    |> String.concat ";"
(** #### Result: *)
(*** include-value: ``example 1.2`` ***)
(**

---

### Exercise 1.2
Define `even` function of type `int -> bool` and sum even numbers from 2 up to 100.
Hint: Use `List.sum` function

    2 + 4 + 6 + ... + 100

#### Your code goes below: *)
let ``exercise 1.2`` = 0

(** #### Result: *)
(*** include-value: ``exercise 1.2`` ***)
(**





---

### Summary: Immutable Values  

***

## Expressions

---

### New Stuff 2.1
#### Type annotations *)
let stringLength (value : string) =
    value.Length

(**

---

### Example 2.1
#### No `return` statements. Last expression is the return value *)
let isPalindrome (value : string) =
    let charList = value |> Seq.toList
    let reversed = value |> Seq.rev |> Seq.toList
    charList = reversed // this boolean expression returns value

let ``example 2.1`` = isPalindrome "kajak"
(** #### Result: *)
(*** include-value: ``example 2.1`` ***)
(**

---

### Exercise 2.1
Declare `splitBy` function (with given type)

Hints: Use standard `String` object methods and `Array.toList` function to convert array to list type
#### Your code goes below: *)
let splitBy (separator : char) (str : string) : list<string> =
    str.Split([|separator|], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

let ``exercise 2.1`` = 
    "1,3,5,8,10" 
    |> splitBy ',' 
(** #### Result: *)
(*** include-value: ``exercise 2.1`` ***)
(**

***

## Pattern matching

***

## Recursion

***

## Practice

---

### New Stuff X.X
#### Something new *)
// code
(**

---

### Example X.X
#### Some example *)
//let example = "example"
(** #### Result: *)
(*** include-value: ``example`` ***)
(**

---

### Exercise X.X
Exercise:

    ((2+7)/3+(14-3)*4)+3

#### Your code goes below: *)

// Expression
let parseNumber value =
    let onlyDigits = 
        value 
        |> Seq.forall System.Char.IsDigit
    if onlyDigits then
        System.Int32.Parse value
    else
        failwithf "unable to parse %s" value


// Patern matching
// Discriminated Union
type Operator =
| Plus
| Minus
| Multiply
| Divide

type Symbol =
| Number of int
| Op of Operator

// Pattern matching
let apply operator fstNum sndNum =
    match operator with
    | Plus -> fstNum + sndNum
    | Minus -> fstNum - sndNum
    | Multiply -> fstNum * sndNum
    | Divide -> fstNum / sndNum

// Function declaration
// Pattern matching
let parseSymbol value =
    match value with
    | "+" -> Op Plus
    | "-" -> Op Minus
    | "*" -> Op Multiply
    | "/" -> Op Divide
    | num -> Number (parseNumber num)

// Expression
// Immutable
let parseSymbols expression =
    expression
    |> splitBy ' '
    |> List.map parseSymbol

// Recursion
// Pattern matching lists
let rec compute stack symbols =
    match stack, symbols with
    | [result], [] -> 
        result
    | stack, Number number :: rest -> 
        compute (number :: stack) rest
    | sndNum :: fstNum :: stack, Op operator :: rest ->
        let opResult = apply operator fstNum sndNum 
        compute (opResult :: stack) rest
    | _ -> 
        failwithf "invalid configuration %A %A!" stack symbols

// Recursion
let onp expression = 
    let symbols = parseSymbols expression
    compute [] symbols

let result = onp "2 7 + 3 / 14 3 - 4 * + 3 +"
(** --- 

#### Result: *)
(*** include-value: result ***)
(**


***

*)
