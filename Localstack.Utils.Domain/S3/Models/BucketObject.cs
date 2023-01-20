namespace Localstack.Utils.Domain.S3.Models;

public class BucketObject
{
    public BucketObject(List<string> checksumAlgorithm, string eTag, string bucketName, string key, DateTime lastModified, long size)
    {
        ChecksumAlgorithm = checksumAlgorithm;
        ETag = eTag;
        BucketName = bucketName;
        Key = key;
        LastModified = lastModified;
        Size = size;
    }

    public List<string> ChecksumAlgorithm { get; set; }
    public string ETag { get; set; }
    public string BucketName { get; set; }
    public string Key { get; set; }
    public DateTime LastModified { get; set; }
    public long Size { get; set; }
}
