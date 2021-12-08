Public Class Day5
    Public Shared Function CalculateVentOverlapValue(rawCoordPairs as IEnumerable(Of String)) As Int32
        Dim ventCoordsDict = new Dictionary(Of Coord, Integer)()
        For Each rawCoordPair As String In rawCoordPairs
            Dim coordPoints = rawCoordPair.Split(" -> ")
            Dim lineCoords = Coord.GetNonDiagCoordsLine(Coord.CreateCoord(coordPoints.First()), Coord.CreateCoord(coordPoints.Last()))
            For Each lineCoord As Coord in lineCoords
                If(ventCoordsDict.ContainsKey(lineCoord)) Then
                    ventCoordsDict.Item(lineCoord) += 1
                Else
                    ventCoordsDict.Add(lineCoord, 1)
                End If
            Next
        Next
        
        Return ventCoordsDict.Where(Function (c) c.Value > 1).Count
    End Function
End Class

Public Structure Coord
    Private X As Int32
    Private Y As Int32

    public Shared Function CreateCoord(rawCoord As String) As Coord

        Dim returnCoord = New Coord()
        
        Dim coordElements As List(Of String) = rawCoord.Split(",").ToList()
        returnCoord.X = Int32.Parse(coordElements.Item(0))
        returnCoord.Y = Int32.Parse(coordElements.Item(1))

        Return returnCoord
    End Function

    Private Shared Function CreateCoord(x As Integer, y As Integer) As Coord
        Dim returnCoord = new Coord()
        
        returnCoord.X = x
        returnCoord.Y = y

        Return returnCoord
    End Function

    Public Shared Function GetNonDiagCoordsLine(coord1 As Coord, coord2 As Coord) As IEnumerable(Of Coord)
        Dim line = new List(Of Coord)()
        
        If(coord1.X <> coord2.X And coord1.Y <> coord2.Y) Then
            Return line
        End If
        
        If (coord1.X < coord2.X) Then
            line = (From x In Enumerable.Range(coord1.X, coord2.X - coord1.X + 1) Select Coord.CreateCoord(x, coord1.Y)).ToList()
        Else If (coord2.X < coord1.X) Then
            line = (From x In Enumerable.Range(coord2.X, coord1.X - coord2.X + 1) Select Coord.CreateCoord(x, coord1.Y)).ToList()
        Else If (coord1.Y < coord2.Y) Then
            line = (From y In Enumerable.Range(coord1.Y, coord2.Y - coord1.Y + 1) Select Coord.CreateCoord(coord1.X, y)).ToList()
        Else If (coord2.Y < coord1.Y) Then
            line = (From y In Enumerable.Range(coord2.Y, coord1.Y - coord2.Y + 1) Select Coord.CreateCoord(coord1.X, y)).ToList()
        End If
        
        Return line
    End Function

End Structure
