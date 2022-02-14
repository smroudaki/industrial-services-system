using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialServicesSystem.Application.Common.UploadHelper.Filepond
{
    public class FilepondDto
    {
        public string Source { get; set; }

        public FilepondOptions Options { get; set; }
    }

    public class FilepondDtoTest
    {
        public string Source { get; set; }

        public FilepondOptionsTest Options { get; set; }
    }

    public class FilepondOptions
    {
        public string Type { get; set; }

        public FilepondFile Files { get; set; }

        public FilepondMetadata Metadata { get; set; }
    }

    public class FilepondOptionsTest
    {
        public string Type { get; set; }

        public FilepondFile File { get; set; }

        public FilepondMetadata Metadata { get; set; }
    }

    public class FilepondFile
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public string Type { get; set; }
    }

    public class FilepondMetadata
    {
        public string Poster { get; set; }
    }
}
