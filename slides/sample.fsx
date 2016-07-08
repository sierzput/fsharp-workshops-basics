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

or download the package from [here](https://github.com/theimowski/fsharp-workshops-basics/archive/master.zip)

---

### Agenda

1. Immutable values
2. Recursion
3. Expressions

***

## Immutable values

---

### New Stuff 1.1
#### Let bindings *)

let value = 5

(**
#### Type inference *)

let stringValue = "Hi there"
let integerValue = 100

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
***

## Recursion

***

## Expression

***
*)

let a = 5
let factorial x = [1..x] |> List.reduce (*)
let c = factorial a
(** 
`c` is evaluated for you
*)
(*** include-value: c ***)
(**

--- 

#### More F#

*)
[<Measure>] type sqft
[<Measure>] type dollar
let sizes = [|1700<sqft>;2100<sqft>;1900<sqft>;1300<sqft>|]
let prices = [|53000<dollar>;44000<dollar>;59000<dollar>;82000<dollar>|] 
(**

#### `prices.[0]/sizes.[0]`

*)
(*** include-value: prices.[0]/sizes.[0] ***)
(**


*)