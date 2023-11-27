namespace PasswordValidator

open System

module PasswordValidator =

    let containsCapitalLetters (password: string) : bool = password |> String.exists Char.IsUpper

    let containsLowerLetters (password: string) : bool = password |> String.exists Char.IsLower

    let containsUnderscore (password: string) : bool =
        password |> String.exists (fun (c: char) -> c = '_')

    let validLength (password: string) : bool = password.Length > 8

    let validate (password: string) : bool =
        let validations =
            [ validLength
              containsCapitalLetters
              containsLowerLetters
              containsUnderscore ]

        let valids = validations |> List.filter (fun pred -> pred password)

        valids.Length = validations.Length
