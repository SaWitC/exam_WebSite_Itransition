using ExampleWebSite.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YandexDisk.Client.Http;
using YandexDisk.Client.Protocol;

namespace ExampleWebSite.Components.YandexDisk
{
    public class CollectionImage
    {
        public static async Task UploadImageAsync(string Token,string DiskFolderPath, IFormFile File,string fileNameNotExtension)
        {
            try
            {
                var api = new DiskHttpApi(Token);

                var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" });

                if (!rootFolderData.Embedded.Items.Any(i => i.Type == ResourceType.Dir && i.Name.Equals(DiskFolderPath)))
                {
                    await api.Commands.CreateDictionaryAsync("/" + DiskFolderPath);
                }

                string extenshion = Path.GetExtension(File.FileName);//расширение

                var link = await api.Files.GetUploadLinkAsync("/" + DiskFolderPath + "/" + fileNameNotExtension + extenshion, overwrite: true);
                using (var fs = File.OpenReadStream())
                {
                    await api.Files.UploadAsync(link, fs);
                }

                //var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DiskFolderPath });

                //foreach (var item in testFolder.Embedded.Items)
                //{
                //    if (item.Name.Contains(File.Name))
                //    {
                //        return await api.Files.GetDownloadLinkAsync(item.Path);
                //    }
                //}
               // return null;
            }
            catch
            {
               // return null;
            }
        }
        public static async Task<Link> GetImageLinkAsync(string Token, string DiskFolderPath, string fileNameNotExtension)
        {
            try
            {
                var api = new DiskHttpApi(Token);

                var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" });

                var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + DiskFolderPath });

                foreach (var item in testFolder.Embedded.Items)
                {
                    if (item.Name.Contains(fileNameNotExtension))
                    {
                        return  await api.Files.GetDownloadLinkAsync(item.Path);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        ////http://localhost:12345/callback#access_token=AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c&token_type=bearer&expires_in=31536000
        //    try
        //    {
        //        var api = new DiskHttpApi("AQAAAABgW19JAAfYg2ZC-Ml1M0I4vHLmlumOb_c");

        //        var rootFolderData = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" });

        //        foreach (var item in rootFolderData.Embedded.Items)
        //        {
        //            Console.WriteLine(item.Name);
        //        }

        //        const string folderName = "Collection_user";
        //        if (!rootFolderData.Embedded.Items.Any(i => i.Type == ResourceType.Dir && i.Name.Equals(folderName)))
        //        {
        //            await api.Commands.CreateDictionaryAsync("/" + folderName);
        //        }

        //        //var file = Directory.GetFiles(Environment.CurrentDirectory, "*.jpg");

        //        var file = "C:\\Users\\USER\\Pictures\\Camera Roll\\1.jpg";

        //        var link = await api.Files.GetUploadLinkAsync("/" + folderName + "/" + Path.GetFileName(file), overwrite: true);
        //        using (var fs = File.OpenRead(file))
        //        {
        //            await api.Files.UploadAsync(link, fs);
        //        }

        //        var testFolder = await api.MetaInfo.GetInfoAsync(new ResourceRequest { Path = "/" + folderName });

        //        foreach (var item in testFolder.Embedded.Items)
        //        {
        //            var filelink = await api.Files.GetDownloadLinkAsync(item.Path);

        //            Console.WriteLine(filelink.Href);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

    }
}
