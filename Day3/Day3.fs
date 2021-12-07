namespace FSharp.Code

module Day3 =
    let charToInt (c: char) =
        int c - int '0'

    let convertCodeToDigitSeq (code:seq<char>) =
        Seq.map charToInt code
        
    let processCode (acc: seq<int>) (code: string) =
        Seq.map2 (fun accElement codeElement -> accElement + codeElement) acc (convertCodeToDigitSeq code) 

    let determineGamma (threshold: int) (value: int) =
        match value with
        | v when v >= threshold -> 1
        | _ -> 0
        
    let determineEpsilon (threshold: int) (value: int) =
        match value with
        | v when v < threshold -> 1
        | _ -> 0
        
    let toBinary (intSeq: seq<int>) =
        intSeq |> Seq.rev |> Seq.mapi (fun i v -> v * pown 2 i) |> Seq.sum
        
    let determineFinalCodeValues calculateGamma calculateEpsilon (finalCode: seq<int>) =
        toBinary (Seq.map calculateGamma finalCode) * toBinary (Seq.map calculateEpsilon finalCode)
        
    let decipherCodes (codes: seq<string>) =
        let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
        let acc = (Seq.init (Seq.length codes) (fun _ -> 0))
        Seq.fold processCode acc codes
        |> determineFinalCodeValues (determineGamma threshold) (determineEpsilon threshold)
        