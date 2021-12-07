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
        
    let determineFinalGammaEpsilonCodeValues calculateGamma calculateEpsilon (finalCode: seq<int>) =
        toBinary (Seq.map calculateGamma finalCode) * toBinary (Seq.map calculateEpsilon finalCode)
        
    let decipherPowerConsumptionCodes (codes: seq<string>) =
        let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
        let acc = Seq.replicate (Seq.length codes) 0
        Seq.fold processCode acc codes
        |> determineFinalGammaEpsilonCodeValues (determineGamma threshold) (determineEpsilon threshold)
        
        
        
        
//        let charToInt (c: char) =
//    int c - int '0'
//
//let convertCodeToDigitSeq (code:seq<char>) =
//    Seq.map charToInt code
//    
//let processCode (acc: seq<int>) (code: string) =
//    Seq.map2 (fun accElement codeElement -> accElement + codeElement) acc (convertCodeToDigitSeq code) 
//
//let determineGamma (threshold: int) (value: int) =
//    match value with
//    | v when v >= threshold -> 1
//    | _ -> 0
//    
//let determineEpsilon (threshold: int) (value: int) =
//    match value with
//    | v when v < threshold -> 1
//    | _ -> 0
//    
//let toBinary (intSeq: seq<int>) =
//    intSeq |> Seq.rev |> Seq.mapi (fun i v -> v * pown 2 i) |> Seq.sum
//    
//let determineFinalPowerConsumptionValue calculateGamma calculateEpsilon (finalCode: seq<int>) =
//    toBinary (Seq.map calculateGamma finalCode) * toBinary (Seq.map calculateEpsilon finalCode)
//    
////let determineFinalLifeSupportValue calculateGamma calculateEpsilon (codes: seq<string>) (finalCode: seq<int>) =
////    let oxygenGeneratorRating = Seq.where (fun c -> )
//    
//let processInitialCodes (codes: seq<string>) =
//    let acc = (Seq.replicate (Seq.length codes) 0)
//    Seq.fold processCode acc codes
//
//let getValidCodesForIndex (codes: seq<string>) (index: int) (value: int) =
//    codes |> Seq.filter (fun c -> charToInt c.[index] = value)
//    
////let rec test (finalCode: seq<int>) (index: int) (codes: seq<string>)=
////    if index >= (Seq.length finalCode) then
////        codes
////    else
////        let newValues = (getValidCodesForIndex codes index (Seq.item index finalCode))
////        let threshold = (ceil ((float (Seq.length newValues)) /  2.0) |> int)
////        let newFinalCode = processInitialCodes newValues |> Seq.map (determineGamma threshold)
////        test newFinalCode (index+1) newValues
//        
//let decipherPowerConsumptionCodes (codes: seq<string>) =
//    let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
//    processInitialCodes codes
//    |> determineFinalPowerConsumptionValue (determineGamma threshold) (determineEpsilon threshold)
//    
//    
////let decipherLifeSupportCodes (codes: seq<string>) =
////    let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
////    processInitialCodes codes
////    |> determineFinalLifeSupportValue (determineGamma threshold) (determineEpsilon threshold) codes
//
//
////let rec test (codes: seq<string>) (index: int) (length: int) =
////    if index < length then
////         test (seq {for code in codes do
////                    if charToInt (Seq.item index code) = 1 then Some(code) else None} |> Seq.where (fun c -> c.IsSome) |> Seq.map (fun c -> c.Value)) (index + 1) length
////    else codes
////    
////let getValidCodesForIndex (codes: seq<string>) (index: int) (value: int) =
////    codes |> Seq.filter (fun c -> charToInt c.[index] = value)
//            
//let getNewFinalCode (codes: seq<string>) =
//    let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
//    processInitialCodes codes |> Seq.map (determineGamma threshold)
//    
//let rec test (finalCode: seq<int>) (index: int) (codes: seq<string>)=
//    if index >= (Seq.length finalCode) then
//        (codes, finalCode)
//    else
//        let v = Seq.toList finalCode
//        let v1 = v.[index]
//        let newValues = (getValidCodesForIndex codes index v1)
//        printfn "%A" finalCode
//        let newFinalCode = getNewFinalCode newValues
//        test newFinalCode (index+1) newValues
//
//let t = seq{"00100"; "11110"; "10110"; "10111"; "10101"; "01111"; "00111"; "11100"; "10000"; "11001"; "00010"; "01010"}
//let f = getNewFinalCode t
//f
//test (getNewFinalCode t) 0 t 