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
    Private _x As Int32
    Private _y As Int32

    public Shared Function CreateCoord(rawCoord As String) As Coord

        Dim returnCoord = New Coord()
        
        Dim coordElements As List(Of String) = rawCoord.Split(",").ToList()
        returnCoord._x = Int32.Parse(coordElements.Item(0))
        returnCoord._y = Int32.Parse(coordElements.Item(1))

        Return returnCoord
    End Function

    Private Shared Function CreateCoord(x As Integer, y As Integer) As Coord
        Dim returnCoord = new Coord()
        
        returnCoord._x = x
        returnCoord._y = y

        Return returnCoord
    End Function

    Public Shared Function GetNonDiagCoordsLine(coord1 As Coord, coord2 As Coord) As IEnumerable(Of Coord)
        Dim line = new List(Of Coord)()
        
        If(coord1._x <> coord2._x And coord1._y <> coord2._y) Then
            Return line
        End If
        
        If (coord1._x < coord2._x) Then
            line = (From x In Enumerable.Range(coord1._x, coord2._x - coord1._x + 1) Select Coord.CreateCoord(x, coord1._y)).ToList()
        Else If (coord2._x < coord1._x) Then
            line = (From x In Enumerable.Range(coord2._x, coord1._x - coord2._x + 1) Select Coord.CreateCoord(x, coord1._y)).ToList()
        Else If (coord1._y < coord2._y) Then
            line = (From y In Enumerable.Range(coord1._y, coord2._y - coord1._y + 1) Select Coord.CreateCoord(coord1._x, y)).ToList()
        Else If (coord2._y < coord1._y) Then
            line = (From y In Enumerable.Range(coord2._y, coord1._y - coord2._y + 1) Select Coord.CreateCoord(coord1._x, y)).ToList()
        End If
        
        Return line
    End Function

End Structure
