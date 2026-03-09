open System
open System.IO

let getDirectoryPath() =
    printf "Введите путь к каталогу: "
    Console.ReadLine()

let validateDirectory (path: string) =
    if not (Directory.Exists(path)) then
        failwith  "ОШИБКА: каталог не существует"

let getFiles (path: string) =
    Directory.EnumerateFiles(path)
    |> Seq.map Path.GetFileName
    |> Seq.sort

[<EntryPoint>]
let main _ =
    let path = getDirectoryPath()
    validateDirectory path
    let files = getFiles path
    if Seq.isEmpty files then
        failwith "В каталоге нет файлов"
    else
        let lastFile = Seq.last files
        printfn "Последний по алфавиту файл: %s" lastFile
    0