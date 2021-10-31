﻿using System.Drawing;

namespace cloudscribe.FileManager.Web.Models
{
    public interface IImageResizer
    {
        /// <summary>
        /// returns a boolean indicating if the image was resized. determined by whether the input image is smaller thena the resize options and whether enlargement is allowed
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="targetDirectoryPath"></param>
        /// <param name="newFileName"></param>
        /// <param name="mimeType"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="allowEnlargement"></param>
        /// <param name="quality"></param>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        bool ResizeImage(
            string sourceFilePath,
            string targetDirectoryPath,
            string newFileName,
            string mimeType,
            int maxWidth,
            int maxHeight,
            bool allowEnlargement = false,
            long quality = 90, 
            Color backgroundColor = default(Color)
            );
    }
}
