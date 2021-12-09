namespace Day5CSharp;

public class Day5
{
    public static int CalculateVentOverlapValue(IEnumerable<string> rawCoordPairs)
    {
        var ventCoordsDict = new Dictionary<Coord, int>();
        var parsedCoordPairs = new List<List<Coord>>();
        foreach (string rawCoordPair in rawCoordPairs)
        {
            string[] coordPoints = rawCoordPair.Split(" -> ");
            parsedCoordPairs.Add(new List<Coord>{Coord.CreateCoord(coordPoints.First()), Coord.CreateCoord(coordPoints.Last())});
        }

        foreach (List<Coord> parsedCoordPair in parsedCoordPairs)
        {
            IEnumerable<Coord> lineCoords = Coord.GetNonDiagCoordsLine(parsedCoordPair.First(), parsedCoordPair.Last());
            foreach (Coord lineCoord in lineCoords)
            {
                if (ventCoordsDict.ContainsKey(lineCoord))
                {
                    ventCoordsDict[lineCoord]++;
                }
                else
                {
                    ventCoordsDict.Add(lineCoord, 1);
                }
            }
        }

        return ventCoordsDict.Count(c => c.Value > 1);
    }

    public struct Coord
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public static Coord CreateCoord(string rawCoord)
        {
            var returnCoord = new Coord();
            
            string[] coordElements = rawCoord.Split(',');
            returnCoord.X = int.Parse(coordElements[0]);
            returnCoord.Y = int.Parse(coordElements[1]);

            return returnCoord;
        }

        public static Coord CreateCoord(int x, int y)
        {
            var returnCoord = new Coord();
            
            returnCoord.X = x;
            returnCoord.Y = y;

            return returnCoord;
        }

        public static IEnumerable<Coord> GetNonDiagCoordsLine(Coord coord1, Coord coord2)
        {
            var line = new List<Coord>();
            
            if (coord1.X != coord2.X && coord1.Y != coord2.Y)
            {
                return line;
            }

            if (coord1.X < coord2.X)
            {
                line = Enumerable.Range(coord1.X, coord2.X - coord1.X + 1).Select(x => Coord.CreateCoord(x, coord1.Y)).ToList();
            }
            else if (coord2.X < coord1.X)
            {
                line = Enumerable.Range(coord2.X, coord1.X - coord2.X + 1).Select(x => Coord.CreateCoord(x, coord1.Y)).ToList();
            }
            else if (coord1.Y < coord2.Y)
            {
                line = Enumerable.Range(coord1.Y, coord2.Y - coord1.Y + 1).Select(y => Coord.CreateCoord(coord1.X, y)).ToList();
            }
            else if (coord2.Y < coord1.Y)
            {
                line = Enumerable.Range(coord2.Y, coord1.Y - coord2.Y + 1).Select(y => Coord.CreateCoord(coord1.X, y)).ToList();
            }
            
            return line;
        }
    }
}