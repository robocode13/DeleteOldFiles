open System
open System.IO

let deleteOldFiles directory maxFileCount recurse = 
    let dir = new DirectoryInfo(directory)
    
    let options = 
        if recurse then SearchOption.AllDirectories
        else SearchOption.TopDirectoryOnly
    
    let files = dir.EnumerateFiles("*.*", options)
    let totalFiles = files |> Seq.length
    printfn "Total files found: %i" totalFiles
    let filesToDelete = 
        if totalFiles > maxFileCount then 
            files
            |> Seq.sortByDescending (fun f -> f.LastWriteTime)
            |> Seq.skip (maxFileCount)
        else Seq.empty
    printf "Deleting %i files..." (filesToDelete |> Seq.length)
    filesToDelete |> Seq.iter (fun f -> f.Delete())
    printfn "OK"

[<EntryPoint>]
let main argv = 
    match argv with
    | [| directory; maxFileCount |] -> deleteOldFiles directory (Int32.Parse(maxFileCount)) false
    | [| directory; maxFileCount; "-r" |] -> deleteOldFiles directory (Int32.Parse(maxFileCount)) true
    | _ -> printfn "USAGE: DeleteOldFiles.exe <directory> <maxFileCount> [-r]"
    0
    