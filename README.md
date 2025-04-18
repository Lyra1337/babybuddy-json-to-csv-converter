# Baby Buddy Pumping Data CSV Exporter

This project is a simple, efficient utility written in C# to convert baby pumping session data from JSON format into a CSV file suitable for analysis or archival.

## Features

- Reads baby pumping session data from a JSON file.
- Calculates time intervals between consecutive pumping sessions.
- Outputs processed data into a neatly structured CSV file.
- Handles UTF-8 encoding and custom CSV delimiters.

## Technologies Used

- **C# (.NET)**
- **CsvHelper** – Easy CSV parsing and writing.
- **System.Text.Json** – Fast JSON deserialization.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [CsvHelper NuGet Package](https://www.nuget.org/packages/CsvHelper/)

### Installation

Clone the repository:

```bash
git clone <your-repo-url>
cd <your-repo-directory>
```

Install dependencies via NuGet:

```bash
dotnet add package CsvHelper
```

### Usage

1. Download the `Pumping.json` file from your Baby Buddy instance. You can find it in the `pumping` section of your Baby Buddy API (/api/pumping?limit=100000).

2. Place your `Pumping.json` file on your Desktop (`C:\Users\<your-username>\Desktop\Pumping.json`).

3. Run the application:

```bash
dotnet run
```

4. Check the generated CSV file located at:

```
C:\Users\<your-username>\Desktop\Pumping.csv
```

## JSON Data Structure

```json
{
  "count": int,
  "next": int?,
  "previous": int?,
  "results": [
    {
      "id": int,
      "child": int,
      "amount": float,
      "start": DateTime,
      "end": DateTime,
      "duration": string,
      "notes": string,
      "tags": object[]
    }
  ]
}
```

## CSV Output Structure

- `id` (int)
- `child` (int)
- `amount` (float)
- `start` (DateTime)
- `end` (DateTime)
- `duration` (string)
- `notes` (string)
- `tags` (object[])
- `hoursFromPrevious` (float, calculated field)

## License

Distributed under the MIT License. See `LICENSE` for more information.

---

Feel free to contribute or submit issues for enhancements or bug reports!

