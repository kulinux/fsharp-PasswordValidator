namespace PasswordValidator

open System

type ValidationType =
    | ValidationOne
    | ValidationTwo


module private PasswordValidatorTypeOne =

    let private containsCapitalLetters (password: string) : bool = password |> String.exists Char.IsUpper

    let private containsLowerLetters (password: string) : bool = password |> String.exists Char.IsLower

    let private containsUnderscore (password: string) : bool =
        password |> String.exists (fun (c: char) -> c = '_')

    let private validLength (password: string) : bool = password.Length > 8

    let validate (password: string) : bool =
        let validations =
            [ validLength
              containsCapitalLetters
              containsLowerLetters
              containsUnderscore ]

        let valids = validations |> List.filter (fun pred -> pred password)

        valids.Length = validations.Length


module PasswordValidator =
    let validation (validationType: ValidationType): string -> bool = PasswordValidatorTypeOne.validate