using DoYouNowThese.CORE;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Ionic.Zip;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace DoYouNowThese.Backup
{
    class Program
    {

        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "doyounowthesebackup";

        static void Main(string[] args)
        {

            //CreateFolder(DateTime.Now.ToShortDateString().ToString(), service);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string somepath = "C:\\inetpub\\wwwroot\\";
            string zippath = "C:\\inetpub\\backup\\"+DateTime.Now.ToShortDateString()+".rar";
            string[] filenames =
            System.IO.Directory.GetDirectories(somepath);
 
            using (ZipFile zip = new ZipFile())
            {
                foreach (String filename in filenames)
                {

                    ZipEntry e = zip.AddFile(filename, "");

                }
                zip.Save(zippath);
            }

            //UserCredential credential;

            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //credential = GetCredentials();


            //// Create Drive API service.
            //var service = new DriveService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = ApplicationName,
            //});

            //UploadBasicImage(zippath, service);


            Console.WriteLine("Done");
            Console.Read();

        }

        private static void CreateFolder(string folderName, DriveService service)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };
            var request = service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            Console.WriteLine("Folder ID: " + file.Id);

        }


        private static void DeleteFileFolder(string id, DriveService service)
        {
            var request = service.Files.Delete(id);

            request.Execute();

        }

        private static void UploadBasicImage(string path, DriveService service)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "image/jpeg";
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }

            var file = request.ResponseBody;

            Console.WriteLine("File ID: " + file.Id);

        }

        private static void ListFiles(DriveService service, ref string pageToken)
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            //listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.Fields = "nextPageToken, files(name)";
            listRequest.PageToken = pageToken;
            listRequest.Q = "mimeType='image/jpeg'";

            // List files.
            var request = listRequest.Execute();


            if (request.Files != null && request.Files.Count > 0)
            {


                foreach (var file in request.Files)
                {
                    Console.WriteLine("{0}", file.Name);
                }

                pageToken = request.NextPageToken;

                if (request.NextPageToken != null)
                {
                    Console.WriteLine("Press any key to conti...");
                    Console.ReadLine();



                }


            }
            else
            {
                Console.WriteLine("No files found.");

            }


        }



        private static UserCredential GetCredentials()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }
    }
}
