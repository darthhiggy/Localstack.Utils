namespace Localstack.Utils.Domain.S3.Models;

public class Bucket
{
    public Bucket(string bucketName, DateTime creationDate)
    {
        BucketName = bucketName;
        CreationDate = creationDate;
    }
    public string BucketName { get; set; }
    public DateTime CreationDate { get; set; }
    
}
