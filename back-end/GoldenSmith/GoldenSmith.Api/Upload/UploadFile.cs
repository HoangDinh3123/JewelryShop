namespace GoldenSmith.Api.Upload
{
    public class UploadFile
    {
        public static List<String> UploadImage(int id, string controller, List<IFormFile> files)
        {
            List<String> result = new List<String>();
            if (files != null)
            {
                var folderPath = Path.GetFullPath("./wwwroot/");
                folderPath = string.Format(@"{0}\{1}\{2}", folderPath, controller, id);
                Directory.CreateDirectory(folderPath);

                foreach ( var file in files )
                {
                    var filePath = string.Format(@"{0}\{1}", folderPath, file.FileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(stream);
                    result.Add(file.FileName);
                }

                return result;
            }
            return result;
        }
    }
}
