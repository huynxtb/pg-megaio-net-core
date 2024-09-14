namespace CodeMegaUploadFileMegaZ;

public static class FileHelper
{
    private static readonly string[] Suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
    
    public static string ToFileSize(long bytes)
    {
        int counter = 0;
        decimal number = bytes;
        while (Math.Round(number / 1024) >= 1)
        {
            number = number / 1024;
            counter++;
        }

        return $"{number:n1} {Suffixes[counter]}";
    }

}