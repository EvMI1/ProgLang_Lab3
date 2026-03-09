open System

let rec inputSize() =
    printf "Введите количество элементов: "
    match Int32.TryParse(Console.ReadLine()) with
    | (true, value) when value > 0 -> value
    | _ ->
        printfn "ОШИБКА: некорректный ввод. Введите целое положительное число."
        inputSize()

let inputUserString n =
    seq {
        for i=1 to n do
            printfn "Введите строку: "
            let s = Console.ReadLine()
            yield s
    }

let inputChar() =
    printf "Введите символ, который добавить к строкам: "
    let input = Console.ReadLine()
    match input with
    | "" -> ""
    | _ -> string(input[0])

[<EntryPoint>]
let main _ =
    let size = inputSize()
    let symb = inputChar()
    let sq = inputUserString size
    let new_seq = Seq.map (fun s -> s + symb) sq
    printfn "ВВОД СТРОК И ВЫВОД ПОСЛЕДОВАТЕЛЬНОСТИ\n%A" (Seq.toList new_seq)
    0