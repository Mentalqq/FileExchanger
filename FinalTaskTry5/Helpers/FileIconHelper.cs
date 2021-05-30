using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Interfaces;
using FinalTaskTry5.BLL.Services;
using FinalTaskTry5.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalTaskTry5.Helpers
{
    public static class FileIconHelper
    {
        public static string FileIcon(string name)
        {
            string icon, type = Path.GetExtension(name).ToLower();

            //Image
            if (type == ".jpg" || type == ".png" || type == ".gif" || type == ".jpeg" || type == ".jpe" || type == ".svg")
                icon = "https://cdn4.iconfinder.com/data/icons/ionicons/512/icon-image-512.png";
            //Video
            else if (type == ".mov" || type == ".mpeg" || type == ".mp4" || type == ".mpg" || type == ".mkv" || type == ".avi")
                icon = "https://cdn0.iconfinder.com/data/icons/multimedia-icons-5/100/video-512.png";
            //Audio
            else if (type == ".aif" || type == ".aiff" || type == ".aifc" || type == ".wav" || type == ".ogg" || type == ".mp3")
                icon = "https://image.flaticon.com/icons/png/512/37/37420.png";
            //Word
            else if (type == ".doc" || type == ".docx")
                icon = "https://png.pngtree.com/element_our/md/20180627/md_5b33460fe6357.jpg";
            //Pdf
            else if (type == ".pdf")
                icon = "https://rivne.church.ua/files/2015/09/PDF-icon.png";
            //Txt
            else if (type == ".txt" || type == ".html")
                icon = "https://cdn3.iconfinder.com/data/icons/file-format-2/512/txt_.txt_file_file_format_document_extension_text_format_-512.png";
            //PowerPoint
            else if (type == ".ppt" || type == ".pptx")
                icon = "https://icons.iconarchive.com/icons/carlosjj/microsoft-office-2013/256/PowerPoint-icon.png";
            //Exe
            else if (type == ".exe")
                icon = "https://icon-library.com/images/windows-exe-icon/windows-exe-icon-1.jpg";
            //Zip
            else if (type == ".zip")
                icon = "https://icons.iconseeker.com/png/fullsize/pull-tab-archives/zip-9.png";
            else
                icon = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRRheHj7yW_UQ5DFin_UC3GfFCqoKhaRgltrg&usqp=CAU";
            return icon;
        }

    }
}