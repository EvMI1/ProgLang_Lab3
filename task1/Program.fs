open System

let inputUserString n =
    seq {
        for i=1 to n do
            printfn "Введите строку: "
            let s = Console.ReadLine()
            yield s
    }

[<EntryPoint>]
let main _ =
    printf "Введите размер списка: "
    let size =
        match Int32.TryParse(Console.ReadLine()) with
        | (true, value) -> value
        | (false, _) -> failwith "ОШИБКА: размер списка - целочисленное число" 
    if size <= 0 then
        failwith "ОШИБКА: неккоректный размер списка"
    printf "Введите символ, который добавить к строкам: "
    let input = Console.ReadLine()
    let symb = 
        if String.IsNullOrEmpty(Console.ReadLine()) then
            "" 
        else
            string(input[0])
    let sq = inputUserString size
    let new_seq = Seq.map (fun s -> s + symb) sq
    printfn "ВВОД СТРОК И ВЫВОД ПОСЛЕДОВАТЕЛЬНОСТИ\n%A" new_seq
    0