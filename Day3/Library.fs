namespace Day3

module Say =
let charToInt (c: char) =
    int c - int '0'

let processCode (a, b, c, d, e) (code: string) =
    ( a + charToInt code.[0] , b + charToInt code.[1], c + charToInt code.[2], d + charToInt code.[3], e + charToInt code.[4] )

let determineBit threshold value =
    match value with
    | v when v >= threshold -> 1
    | _ -> 0
    
let determineFinalCode threshold (a, b, c, d, e) =
    (determineBit a threshold, determineBit b threshold, determineBit c threshold, determineBit d threshold, determineBit e threshold )
    
let findMostCommonBits (codes: seq<string>) =
    Seq.fold processCode (0, 0, 0, 0, 0) codes
    |> determineFinalCode (Seq.length codes / 2)
    
    
 
let test = seq {"00100"; "11110"; "10110"; "10111"; "10101"; "01111"; "00111"; "11100"; "10000"; "11001"; "00010"; "01010"}

findMostCommonBits test