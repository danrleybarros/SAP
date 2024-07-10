namespace Gcsb.Connect.SAP.Domain.UploadTypeDto
{
    public class UploadTypeDto
    {
        //Name
        public string Value { get; set; }

        //Description
        public string Text { get; set; }

        public UploadTypeDto(string value, string text)
        {
            Value = value;
            Text = text;
        }
    }
}
