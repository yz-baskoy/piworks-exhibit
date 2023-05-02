public class Program
{
    private static void Main(string[] args)
    {
        // @filePath: path for desired input file. replace with your own.
        string filePath = "./exhibitA-input.csv";

        List<PlayData> playDataList = new List<PlayData>();

        using (var reader = new StreamReader(filePath))
        {
            // skip header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split('\t');

                var playData = new PlayData
                {
                    PlayId = Guid.Parse(values[0]),
                    SongId = int.Parse(values[1]),
                    ClientId = int.Parse(values[2]),
                    PlayTimestamp = DateTime.Parse(values[3])
                };
                playDataList.Add(playData);
            }
        }

        DateTime inputDate = new DateTime(2016, 10, 8);

        var filteredData = playDataList.Where(a => a.PlayTimestamp.Date == inputDate);

        // Group the data by CLIENT_ID and count the number of distinct SONG_IDs played
        var groupedData = filteredData.GroupBy(pd => pd.ClientId)
                                       .Select(g => new { ClientId = g.Key, DistinctSongCount = g.Select(pd => pd.SongId).Distinct().Count() });

        var result = groupedData.GroupBy(gd => gd.DistinctSongCount)
                                    .Select(g => new { DistinctPlayCount = g.Key, ClientCount = g.Count() })
                                    .OrderBy(x => x.DistinctPlayCount);

        // Generate the output table and write to CSV file
        using (var writer = new StreamWriter("output.csv"))
        {
            writer.WriteLine("DISTINCT_PLAY_COUNT,CLIENT_COUNT");

            foreach (var row in result)
            {
                writer.WriteLine($"{row.DistinctPlayCount},{row.ClientCount}");
            }
        }
    }
}