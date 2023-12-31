﻿namespace PasswordValidator

open System

type ValidationType =
    | ValidationOne
    | ValidationTwo

type ValidationResult =
    { Validation: string -> bool
      Reason: string }

module private Validations =

    let private withReason (validation: string -> bool, reason: string) : ValidationResult =
        { Validation = validation
          Reason = reason }


    let private validationOfValidLength (length: int) (password: string) : bool = password.Length > length

    let private validationOfContainsCapitalLetters (password: string) : bool = password |> String.exists Char.IsUpper

    let private validationOfContainsLowerLetters (password: string) : bool = password |> String.exists Char.IsLower

    let private validationOfContainsUnderscore (password: string) : bool =
        password |> String.exists (fun (c: char) -> c = '_')


    let validLength (length: int) : ValidationResult =
        withReason (validationOfValidLength length, "Length")

    let containsCapitalLetters: ValidationResult =
        withReason (validationOfContainsCapitalLetters, "Capital Letter")

    let containsLowerLetters: ValidationResult =
        withReason (validationOfContainsLowerLetters, "Lower Letter")

    let containsUnderscore: ValidationResult =
        withReason (validationOfContainsUnderscore, "Underscore")



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
    let validate (validations: ValidationResult list) (password: string) : bool =
        let valids = validations |> List.filter (fun pred -> pred.Validation password)

        valids.Length = validations.Length

    let reasonFailed (validations: ValidationResult list) (password: string) : string list =
            validations
            |> List.filter (fun pred -> pred.Validation password = false)
            |> List.map (fun pred -> pred.Reason)


    let private chooseValidation validationType : ValidationResult list =
        match validationType with
        | ValidationOne -> PasswordValidatorTypeOne.validations
        | ValidationTwo -> PasswordValidatorTypeTwo.validations

    let validation validationType : ValidationType: string -> bool =
        validationType |> chooseValidation |> validate

    let reason validationType : ValidationType: string -> string list =
        validationType |> chooseValidation |> reasonFailed
