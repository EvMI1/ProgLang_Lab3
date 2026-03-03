open System

let inputUserString n =
    printfn "Заполните последовательность"
    seq{
        for i=1 to n do
            printf "Введите строку: "
            let s = Console.ReadLine()
            yield s
    }

let shortest_string (ls: string seq) =
    Seq.fold (fun (acc:string) (s:string) -> 
    if s.Length < acc.Length then s else acc) 
        (Seq.head ls) (Seq.tail ls)

[<EntryPoint>]
let main _ =
    printf "Введите размер списка: "
    let size = 
        match Int32.TryParse(Console.ReadLine()) with
        | (true, value) -> value
        | (false, _) -> failwith "ОШИБКА: неккоретный ввод" 
    if size <= 0 then
        failwith "ОШИБКА: неккоректный ввод"
    let sq = inputUserString size |> Seq.cache
    printfn "Кратчайшая строка: %A" (shortest_string sq)
    0