﻿namespace FSharp.Code

module Day2 =
    let extractCoordValue (coord: string) =
            coord.Split(' ').[1] |> int32
            
    let calculatePosition (horiz: int32, vert: int32) (coord: string) =
        match coord.Split(' ').[0] with
            | "forward" -> (horiz + extractCoordValue coord, vert)
            | "up" -> (horiz, vert - extractCoordValue coord)
            | "down" -> (horiz, vert + extractCoordValue coord)
            | _ -> (horiz, vert)
        
    let calculatePositionWithAim (horiz: int32, vert: int32, aim: int32) (coord: string) =
        match coord.Split(' ').[0] with
            | "forward" -> (horiz + extractCoordValue coord, vert + aim * extractCoordValue coord, aim)
            | "up" -> (horiz, vert, aim - extractCoordValue coord)
            | "down" -> (horiz, vert, aim + extractCoordValue coord)
            | _ -> (horiz, vert, aim)
        
    let findFinalPositionValue (coordinates: seq<string>) =
        Seq.fold calculatePosition (0, 0) coordinates
        |> (fun (a, b) -> a * b)
        
    let findFinalPositionValueWithAim (coordinates: seq<string>) =
        Seq.fold calculatePositionWithAim (0, 0, 0) coordinates
        |> (fun (a, b, _) -> a * b)