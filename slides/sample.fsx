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

the slides are re-generated **every time the script is saved** 

---

### Agenda

* Workshop Format
* Immutable values
* Expressions
* Pattern matching
* Recursion

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

---

### Links

* [Immutability - Making your code predictable](https://fsharpforfunandprofit.com/posts/correctness-immutability/) by Scott Wlaschin

***

## Expressions



---

### New Stuff 2.1
#### In F# everything is an expression *)
let writeLine = System.Console.WriteLine "Hello"
let writeLineIsUnit = writeLine = ()
(*** include-value: ``writeLineIsUnit`` ***)
(**

---

#### If - then expression *)
let day =
    if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Thursday then
        "thursday"
    else
        "some other day of week"
(*** include-value: ``day`` ***)
(**

---

#### Binding values inside functions *)
let day2 =
    let today = System.DateTime.Now.DayOfWeek 
    if today = System.DayOfWeek.Thursday then
        "thursday"
    else
        "some other day of week"
(*** include-value: ``day2`` ***)
(**

---

#### Option type *)
let workDay =
    let today = System.DateTime.Now.DayOfWeek 
    if today <> System.DayOfWeek.Saturday &&
       today <> System.DayOfWeek.Sunday then
        Some today
    else
        None
(*** include-value: ``workDay`` ***)
(**


---

### Example 2.1
#### Parsing boolean value *)
let parseBool (value : string) =
    let lowercase = value.ToLowerInvariant()
    if lowercase = "true" then
        Some true
    elif lowercase = "false" then
        Some false
    else
        None

let ``example 2.1`` = parseBool "True"
(** #### Result: *)
(*** include-value: ``example 2.1`` ***)
(**

---

### Exercise 2.1
Implement `parseNumber` function of type `string -> Option<int>`

Useful functions: `Seq.forall`, `System.Char.IsDigit`, `System.Int32.Parse`

#### Your code goes below: *)
let parseNumber value =
    let onlyDigits = 
        value 
        |> Seq.forall System.Char.IsDigit
    if onlyDigits && (Seq.length value > 0) then
        Some (System.Int32.Parse value)
    else
        None

let ``exercise 2.1`` = parseNumber "42"
(** #### Result: *)
(*** include-value: ``exercise 2.1`` ***)
(**





---

### New Stuff 2.2
#### Dot notation (type annotations) *)
let length (value : string) =
    value.Length

let lengthOfWord = length "Hello word"
(*** include-value: ``lengthOfWord`` ***)
(**

---

#### Array literal *)
let intArray = [|2;4;5|]
let rangeArray = [|10..15|]
(*** include-value: ``rangeArray`` ***)
(**

---

### Example 2.2
#### No `return` statements. Last expression is the return value *)
let isPalindrome (value : string) =
    let charList = value |> Seq.toList
    let reversed = value |> Seq.rev |> Seq.toList
    charList = reversed // this boolean expression returns value

let ``example 2.2`` = isPalindrome "kajak"
(** #### Result: *)
(*** include-value: ``example 2.2`` ***)
(**

---

### Exercise 2.2
Declare `splitBy` function (with given type)

Hints: Use standard `String` object methods and `Array.toList` function to convert array to list type
#### Your code goes below: *)
let splitBy (separator : char) (str : string) : list<string> =
    str.Split([|separator|], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

let ``exercise 2.2`` = 
    "1,3,5,8,10" 
    |> splitBy ',' 
(** #### Result: *)
(*** include-value: ``exercise 2.2`` ***)
(**

---



### Summary: Expressions

---

### Links

* [Expressions and Syntax series](https://fsharpforfunandprofit.com/series/expressions-and-syntax.html) by Scott Wlaschin

***

## Pattern matching




---

### New Stuff 3.1
#### Discriminated Unions - Empty cases (enum style) *)
type Size = 
| Small
| Medium
| Large
(**

---

#### Discriminated Unions - Complex cases *)
type Shape =
| Square of edge : float
| Rectangle of width : float * height : float
| Circle of radius : float

type Result = 
| Success                // no string needed for success state
| ErrorMessage of string // error message needed 
(**

---

### Example 3.1
#### Modelling with Discriminated Union Types *)
type Fruit =
| Banana
| Apple
| Grapefruit

type Meal = 
| Healthy of Fruit
| Sandwich
| FastFood of string

let ``example 3.1`` = 
    [Sandwich; FastFood "Bar Żuławski"; Healthy Apple]
(** #### Result: *)
(*** include-value: ``example 3.1`` ***)
(**

---

### Exercise 3.1
Define `Operator` and `Symbol` Discriminated Union Types. `Symbol` should use `Operator` as field in one case

#### Your code goes below: *)
type Operator =
| Plus
| Minus
| Multiply
| Divide

type Symbol =
| Number of int
| Op of Operator

let ``exercise 3.1`` = Op Plus
(** #### Result: *)
(*** include-value: ``exercise 3.1`` ***)
(**




---

### New Stuff 3.2
#### Pattern matching expression *)
let formatOptionalValue optionalValue =
    match optionalValue with
    | Some value ->
        "Value: " + value
    | None ->
        "No value at all!"

let formattedValues = 
    [Some "nice string"; None]
    |> List.map formatOptionalValue
(*** include-value: formattedValues ***)            
(**

---

### Example 3.2
#### Calculating area of `Shape` with help of pattern matching *)
let area shape =
    match shape with
    | Square edge -> edge ** 2.0
    | Rectangle (width, height) -> width * height
    | Circle radius -> System.Math.PI * (radius ** 2.0)  

let ``example 3.2`` = area (Circle 10.0)
(** #### Result: *)
(*** include-value: ``example 3.2`` ***)
(**

---

### Exercise 3.2
With help of pattern matching, implement `apply` function which applies given `Operator` to two `Int` (operands)

#### Your code goes below: *)
let apply operator fstNum sndNum =
    match operator with
    | Plus -> fstNum + sndNum
    | Minus -> fstNum - sndNum
    | Multiply -> fstNum * sndNum
    | Divide -> fstNum / sndNum

let ``exercise 3.2`` = apply Divide 15 4
(** #### Result: *)
(*** include-value: ``exercise 3.2`` ***)
(**






---

### Summary: Pattern Matching

---

### Links

* [Discriminated Unions - Adding types together](https://fsharpforfunandprofit.com/posts/discriminated-unions/) by Scott Wlaschin

***

## Recursion

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

// Function declaration
// Pattern matching
let parseSymbol value =
    match value with
    | "+" -> Some (Op Plus)
    | "-" -> Some (Op Minus)
    | "*" -> Some (Op Multiply)
    | "/" -> Some (Op Divide)
    | str -> 
        match parseNumber str with
        | Some num -> Some (Number num)
        | None -> None

// Expression
// Immutable
let parseSymbols expression =
    let symbols =
        expression
        |> splitBy ' '
        |> List.map parseSymbol
    if symbols |> List.forall Option.isSome then
        Some (symbols |> List.map Option.get)
    else
        None

// Recursion
// Pattern matching lists
let rec compute stack symbols =
    match stack, symbols with
    | [result], [] -> 
        Some result
    | stack, Number number :: rest -> 
        compute (number :: stack) rest
    | sndNum :: fstNum :: stack, Op operator :: rest ->
        let opResult = apply operator fstNum sndNum 
        compute (opResult :: stack) rest
    | _ -> 
        None

// Recursion
let onp expression = 
    match parseSymbols expression with
    | Some symbols ->
        compute [] symbols
    | None ->
        None

let result = onp "2 7 + 3 / 14 3 - 4 * + 3 +"
(** --- 

#### Result: *)
(*** include-value: result ***)
(**


***

*)
