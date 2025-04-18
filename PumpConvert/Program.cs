using System.Globalization;
using System.Text;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;

var json = File.ReadAllText(@"C:\Users\thomas\Desktop\Pumping.json");
var response = JsonSerializer.Deserialize<BabyBuddyApiResponse<Pumping>>(json);
var pumping = response.results;

pumping = pumping.OrderBy(x => x.start).ToList();

for (int i = 0; i < pumping.Count; i++)
{
    if (i + 1 == pumping.Count)
    {
        break;
    }

    var previous = pumping[i];
    var next = pumping[i + 1];
    next.hoursFromPrevious = (float)(next.start - previous.start).TotalHours;
}

File.Delete(@"C:\Users\thomas\Desktop\Pumping.csv");
using (var writer = new StreamWriter(@"C:\Users\thomas\Desktop\Pumping.csv"))
using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.CurrentCulture)
{
    Delimiter = ";",
    Encoding = Encoding.UTF8
}))
{
    csv.WriteRecords(pumping);
}

public record Pumping(int id, int child, float amount, DateTime start, DateTime end, string duration, string notes, object[] tags)
{
    public float hoursFromPrevious { get; set; }
}

public record BabyBuddyApiResponse<T>(int count, int? next, int? previous, List<T> results);
