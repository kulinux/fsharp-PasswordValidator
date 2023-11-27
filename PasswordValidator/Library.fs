namespace PasswordValidator

module PasswordValidator =
    let validate (password: string): bool =
        password.Length > 8
