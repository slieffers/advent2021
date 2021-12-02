namespace FSharp.Code

module Day1 =
    let countGreaterValues (nums: seq<int>) =
        Seq.pairwise nums
        |> Seq.filter (fun (a, b) -> a < b)
        |> Seq.length

    let countSlidingGreaterValues (nums: seq<int>) =
        Seq.windowed 3 nums
        |> Seq.map Seq.sum
        |> countGreaterValues