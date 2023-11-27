namespace PasswordValidator

open System

module PasswordValidator =
    let containsCapitalLetters (password : string): bool =
        password |> String.exists Char.IsUpper

    let containsLowerLetters (password : string): bool =
        password |> String.exists Char.IsLower

    let validate (password: string): bool =
        password.Length > 8 && containsCapitalLetters password && containsLowerLetters password
