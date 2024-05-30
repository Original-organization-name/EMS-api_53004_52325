using System.Text.RegularExpressions;
using EMS.Data.Models;

namespace EMS.Data.Employees.Entities;

public class Image : Entity
{
    public string Name { get; set; }
    public string FileExtension { get; set; }
    public string ContentType { get; set; }
    public byte[] Content { get; set; }
    
    public Image(string contentType, byte[] content)
    {    
        var match = Regex.Match(contentType, @"image\/(png|jpeg|jpg)");
        if (!match.Success)        throw new ArgumentException("Invalid data URI format.");
        if (content.Length >= 10485760)
            throw new ArgumentException("The image cannot be larger than 10 MB");    
        ContentType = contentType;    Content = content;
        FileExtension = contentType.Split('/')[1];
        Name = $"{DateTime.Now.Ticks}";
    }
    
    public static Image? FromBase64String(string? base64Image)
    {    
        if (string.IsNullOrEmpty(base64Image))
        {        
            return null;
        }    
        var match = Regex.Match(base64Image, @"data:(image\/(png|jpeg|jpg));base64,(.+)");    
        if (!match.Success)
            throw new ArgumentException("Invalid data URI format.");
        var contentType = match.Groups[1].Value;    var base64Data = match.Groups[3].Value;
        try
        {        
            var imageBytes = Convert.FromBase64String(base64Data);
            return new Image(contentType, imageBytes);
        }
        catch (FormatException)    
        {
            throw new ArgumentException("Invalid base64 string format.");    
        }
    }
}