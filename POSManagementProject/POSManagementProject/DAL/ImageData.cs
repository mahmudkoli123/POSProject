using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSManagementProject.DAL
{
    public class ImageData
    {
        public byte[] ImageConvertToByte(HttpPostedFileBase file)
        {
            byte[] imageData = null;

            if (file != null && file.ContentLength > 0)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/jpg" ||
                    file.ContentType == "image/png" || file.ContentType == "image/gif")
                {
                    if (file.ContentLength <= (1 * 1024 * 1024))
                    {
                        imageData = new byte[file.ContentLength];
                        file.InputStream.Read(imageData, 0, file.ContentLength);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            return imageData;
        }
    }
}