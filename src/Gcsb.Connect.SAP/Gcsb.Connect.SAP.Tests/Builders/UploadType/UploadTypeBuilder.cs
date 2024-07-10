using Gcsb.Connect.SAP.Domain.Upload.Enum;
using Gcsb.Connect.SAP.Domain.UploadTypeDto;
using System;


namespace Gcsb.Connect.SAP.Tests.Builders.UploadType
{
    public class UploadTypeBuilder
    {
        public string Value;
        public string Text;

        public static UploadTypeBuilder New()
        {
            return new UploadTypeBuilder()
            {
                Value = "Billfeed",
                Text = "Process Billfeed"
            };
        }
       
        public UploadTypeBuilder WithValue(string value)
        {
            Value = value;
            return this;
        }

        public UploadTypeBuilder WithText(string text)
        {
            Text = text;
            return this;
        }

        public UploadTypeDto Build()
        {
            return new UploadTypeDto(Value, Text);
        }
    }
}
