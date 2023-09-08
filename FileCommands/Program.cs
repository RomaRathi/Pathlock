using System.Net;

class Program
{
    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("1. File Copy");
            Console.WriteLine("2. File Delete");
            Console.WriteLine("3. Query Folder Files");
            Console.WriteLine("4. Create Folder");
            Console.WriteLine("5. Download File");
            Console.WriteLine("6. Wait");
            Console.WriteLine("7. Conditional Count Rows File");
            Console.WriteLine("8. Exit");

            Console.Write("Enter the command number: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        FileCopy();
                        break;
                    case 2:
                        FileDelete();
                        break;
                    case 3:
                        QueryFolderFiles();
                        break;
                    case 4:
                        CreateFolder();
                        break;
                    case 5:
                        await DownloadFileAsync();
                        break;
                    case 6:
                        Wait();
                        break;
                    case 7:
                        ConditionalCountRowsFile();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command number. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void FileCopy()
    {
        Console.Write("Enter source file path: ");
        string sourcePath = Console.ReadLine();
        Console.Write("Enter destination file path: ");
        string destinationPath = Console.ReadLine();

        try
        {
            File.Copy(sourcePath, destinationPath);
            Console.WriteLine("File copied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void FileDelete()
    {
        Console.Write("Enter file path to delete: ");
        string filePath = Console.ReadLine();

        try
        {
            File.Delete(filePath);
            Console.WriteLine("File deleted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void QueryFolderFiles()
    {
        Console.Write("Enter folder path: ");
        string folderPath = Console.ReadLine();

        try
        {
            string[] files = Directory.GetFiles(folderPath);
            Console.WriteLine("Files in the folder:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CreateFolder()
    {
        Console.Write("Enter folder path: ");
        string folderPath = Console.ReadLine();
        Console.Write("Enter new folder name: ");
        string folderName = Console.ReadLine();
        string newFolderPath = Path.Combine(folderPath, folderName);

        try
        {
            Directory.CreateDirectory(newFolderPath);
            Console.WriteLine("Folder created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task DownloadFileAsync()
    {
        Console.Write("Enter source URL: ");
        string sourceUrl = Console.ReadLine();
        Console.Write("Enter output file path: ");
        string outputPath = Console.ReadLine();

        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile(sourceUrl, outputPath);
                Console.WriteLine("File downloaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    static void Wait()
    {
        Console.Write("Enter wait time in seconds: ");
        if (int.TryParse(Console.ReadLine(), out int waitTime))
        {
            Thread.Sleep(waitTime * 1000);
            Console.WriteLine($"Waited for {waitTime} seconds.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number of seconds.");
        }
    }

    static void ConditionalCountRowsFile()
    {
        Console.Write("Enter source file path: ");
        string filePath = Console.ReadLine();
        Console.Write("Enter string to search in rows: ");
        string searchString = Console.ReadLine();

        try
        {
            int count = File.ReadLines(filePath).Select(line => line.Contains(searchString)).Count();
            Console.WriteLine($"Number of rows containing '{searchString}': {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
