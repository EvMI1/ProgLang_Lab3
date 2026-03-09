open System

let rec inputSize() =
    printf "Введите количество элементов: "
    match Int32.TryParse(Console.ReadLine()) with
    | (true, value) when value > 0 -> value
    | _ ->
        printfn "ОШИБКА: некорректный ввод. Введите целое положительное число."
        inputSize()

let rec inputSuffix() =
    printf "Введите строку-правило (добавляется в конец на каждом шаге): "
    let suffix = Console.ReadLine()
    if suffix = "" then
        printfn "ОШИБКА: строка-правило не может быть пустой."
        inputSuffix()
    else
        suffix

let generateSequence (initial: string) (suffix: string) (n: int) =
    seq {
        let rec loop current count =
            seq {
                if count > 0 then
                    yield current
                    yield! loop (current + suffix) (count - 1)
            }
        yield! loop initial n
    }

let shortest_string (ls: string seq) =
    Seq.fold (fun (acc: string) (s: string) ->
        if s.Length < acc.Length then s else acc)
        (Seq.head ls) (Seq.tail ls)

[<EntryPoint>]
let main _ =
    let n = inputSize ()
    printf "Введите начальную строку: "
    let initial = Console.ReadLine()
    let suffix = inputSuffix()
    let sq = generateSequence initial suffix n
    printfn "Последовательность: %A" sq
    printfn "Кратчайшая строка: %A" (shortest_string sq)
    0