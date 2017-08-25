using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Extensions
{
    public static class FileSave
    {
        /// <summary>
        /// 一个文件保存
        /// </summary>
        /// <param name="file">保存的文件</param>
        /// <param name="path">保存文件路径</param>
        /// <returns></returns>
        public static string FileSaveOne(this IFormFile file, string path)
        {
            if (!(file is null))
            {
                var savePath = $@"{DateTime.Now.ToFileTimeUtc().ToString()}{Path.GetExtension(file.FileName)}";
                using (var stream = new FileStream(Path.Combine(path, savePath), FileMode.OpenOrCreate))
                {
                    file.CopyTo(stream);
                }
                return savePath;
            }
            return null;
        }
    }
}
