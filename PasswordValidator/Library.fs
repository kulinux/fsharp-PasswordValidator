namespace PasswordValidator

open System

type ValidationType =
    | ValidationOne
    | ValidationTwo

module private Validations =
    let validLength (length: int) (password: string) : bool = password.Length > length

    let containsCapitalLetters (password: string) : bool = password |> String.exists Char.IsUpper

    let containsLowerLetters (password: string) : bool = password |> String.exists Char.IsLower

    let containsUnderscore (password: string) : bool =
        password |> String.exists (fun (c: char) -> c = '_')


module private PasswordValidatorTypeOne =

    open Validations

    let validations =
        [ validLength 8
          containsCapitalLetters
          containsLowerLetters
          containsUnderscore ]


module private PasswordValidatorTypeTwo =

    open Validations

    let validations =
        [ validLength 6
          containsCapitalLetters
          containsLowerLetters
          containsUnderscore ]



module PasswordValidator =
    let validate (validations: (string -> bool) list) (password: string) : bool =
        let valids = validations |> List.filter (fun pred -> pred password)

        valids.Length = validations.Length


    let validation (validationType: ValidationType) : string -> bool =
        match validationType with
        | ValidationOne -> validate (PasswordValidatorTypeOne.validations)
        | ValidationTwo -> validate (PasswordValidatorTypeTwo.validations)
