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

slides are re-generated every time the script (/slides/index.fsx) is **changed**

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
let isOdd number =
    number % 2 = 1

let ``example 1.2`` = 
    [2 .. 10]
    |> List.filter isOdd
    |> List.map string
    |> String.concat ";"
(** #### Result: *)
(*** include-value: ``example 1.2`` ***)
(**

---

### Exercise 1.2
Define `isEven` function of type `int -> bool` and sum even numbers from 2 up to 100.
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
type FruitType =
| Banana
| Apple
| Grapefruit

type Meal = 
| Fruit of FruitType
| Sandwich
| FastFood of string

let ``example 3.1`` = 
    [Sandwich; FastFood "Bar Żuławski"; Fruit Apple]
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

### New Stuff 3.3
#### Pattern matching strings *)
let patternMatchString value =
    match value with
    | "Dog" -> "Animal"
    | "Cat" -> "Animal"
    | x     -> "Something different"

let matchAnimal = patternMatchString "Chair"
(*** include-value: matchAnimal ***)
(**

---

#### Nested `match` expressions *)
let matchFloatingPoint value =
    match value with
    | "1" -> 1.0
    | "2" -> 2.0
    | x   ->
        match x with
        | "1.0" -> 1.0
        | "2.5" -> 2.5
        | y     -> 0.0
(**

---

### Example 3.3
#### Nested `match` - checking if meal is healthy *)
let isHealthy meal =
    match meal with
    | Fruit _ -> true
    | Sandwich _ -> false
    | FastFood restaurant ->
        match restaurant with
        | "Green Way" -> true
        | _ -> false

let ``example 3.3`` = FastFood "Bar Żuławski" |> isHealthy
(** #### Result: *)
(*** include-value: ``example 3.3`` ***)
(**

---

### Exercise 3.3
Implement `parseSymbol` - try parse all operators first, and then in nested `match` expression use `parseNumber` function 

#### Your code goes below: *)
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

let ``exercise 3.3`` = List.map parseSymbol ["+"; "/"; "12"; "uups"] 
(** #### Result: *)
(*** include-value: ``exercise 3.3`` ***)
(**

---




### Exercise 3.4
Implement `parseSymbols`. Useful functions: `List.map`, `List.forAll`, `Option.isSome`, `Option.get` as well as `splitBy` and `parseSymbol` 

#### Your code goes below: *)
let parseSymbols expression =
    let symbols =
        expression
        |> splitBy ' '
        |> List.map parseSymbol
    if symbols |> List.forall Option.isSome then
        Some (symbols |> List.map Option.get)
    else
        None

let ``exercise 3.4`` = "1 2 / +" |> parseSymbols
(** #### Result: *)
(*** include-value: ``exercise 3.4`` ***)
(**





---

### Summary: Pattern Matching

---

### Links

* [Discriminated Unions - Adding types together](https://fsharpforfunandprofit.com/posts/discriminated-unions/) by Scott Wlaschin
* [Pattern matching for conciseness](http://fsharpforfunandprofit.com/posts/match-expression/) by Scott Wlaschin
* [Match expressions - The workhorse of F#](http://fsharpforfunandprofit.com/posts/match-expression/) by Scott Wlaschin
* [Exhaustive pattern matching - A powerful technique to ensure correctness](https://fsharpforfunandprofit.com/posts/correctness-exhaustive-pattern-matching/) by Scott Wlaschin

***

## Recursion





---

### New Stuff 4.1
#### Pattern matching lists *)
// code
(**

#### Pattern in pattern *)
// code
(**

#### Recursive functions *)
// code
(**

---

### Example 4.1
#### Recursive call with "accumulators" *)
let rec partitionEvenOdd even odd numbers =
    match numbers with
    | [] -> 
        (even, odd)
    | h :: tail when h % 2 = 0 ->
        partitionEvenOdd (h :: even) odd tail
    | h :: tail when h % 2 = 1 ->
        partitionEvenOdd even (h :: odd) tail

let ``example 4.1`` = partitionEvenOdd [] [] [1..10]
(** #### Result: *)
(*** include-value: ``example 4.1`` ***)
(**

---

### Exercise 4.1
Implement `compute` function

#### Your code goes below: *)
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

let ``exercise 4.1`` = compute [] [Number 4; Number 2; Op Multiply]
(** #### Result: *)
(*** include-value: ``exercise 4.1`` ***)
(**







---

### New Stuff 4.2
#### Something new *)
// code
(**

---

### Example 4.2
#### Some example *)
let ``example 4.2`` = "example"
(** #### Result: *)
(*** include-value: ``example 4.2`` ***)
(**

---

### Exercise 4.2
Implement `onp` function

#### Your code goes below: *)
let onp expression = 
    match parseSymbols expression with
    | Some symbols ->
        compute [] symbols
    | None ->
        None

let ``exercise 4.2`` = onp "2 7 + 3 / 14 3 - 4 * + 3 +"
(** #### Result: *)
(*** include-value: ``exercise 4.2`` ***)
(**

---

### Summary: Recursion

---

### Links

***

## Summary

* Immutable values
* Expressions
* Pattern matching
* Recursion

---

## Next week

### Functional Data Structures

*)
