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
        
    let determineFinalPowerConsumptionValue calculateGamma calculateEpsilon (finalCode: seq<int>) =
        toBinary (Seq.map calculateGamma finalCode) * toBinary (Seq.map calculateEpsilon finalCode)
            
    let processInitialCodes (codes: list<string>) =
        let acc = (Seq.replicate (Seq.length codes.[0]) 0)
        List.fold processCode acc codes

    let getValidCodesForIndex (codes: seq<string>) (index: int) (value: int) =
        codes |> Seq.filter (fun c -> charToInt c.[index] = value)
                
    let getNewFinalCode (codes: seq<string>) finalCodeMapper =
        let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
        codes |> Seq.toList |> processInitialCodes |> Seq.map (finalCodeMapper threshold)

    let rec getFinalLifeSupportCode (finalCode: seq<int>) (index: int) (codes: seq<string>) finalCodeMapper =
        if index >= (Seq.length finalCode) || (Seq.length codes = 1) then
            codes
        else
            let v1 = Seq.item index finalCode
            let newValues = (getValidCodesForIndex codes index v1)
            let newFinalCode = getNewFinalCode newValues finalCodeMapper
            getFinalLifeSupportCode newFinalCode (index+1) newValues finalCodeMapper

    let determineFinalLifeSupportValue (o2Reading: seq<int>) (cO2Reading: seq<int>) =
        toBinary o2Reading * toBinary cO2Reading

    let decipherPowerConsumptionCodes (codes: seq<string>) =
        let threshold = (ceil ((float (Seq.length codes)) /  2.0) |> int)
        let acc = Seq.replicate (Seq.length codes) 0
        Seq.fold processCode acc codes
        |> determineFinalPowerConsumptionValue (determineGamma threshold) (determineEpsilon threshold)

    let decipherLifeSupportCodes (codes: seq<string>) =
        let o2Rating = convertCodeToDigitSeq (Seq.head (getFinalLifeSupportCode (getNewFinalCode codes determineGamma) 0 codes determineGamma))
        let cO2Rating = convertCodeToDigitSeq (Seq.head (getFinalLifeSupportCode (getNewFinalCode codes determineEpsilon) 0 codes determineEpsilon))
        determineFinalLifeSupportValue o2Rating cO2Rating