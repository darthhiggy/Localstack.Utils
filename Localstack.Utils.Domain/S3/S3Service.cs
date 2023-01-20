using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Localstack.Utils.Domain.S3.Models;
using S3Bucket = Amazon.S3.Model.S3Bucket;
using S3Object = Amazon.S3.Model.S3Object;

namespace Localstack.Utils.Domain.S3;

public class S3Service : IS3Service
{
    private IAmazonS3 S3Client { get; set; }

    public S3Service()
    {
        S3Client = new AmazonS3Client(new AmazonS3Config()
        {
            RegionEndpoint = RegionEndpoint.USEast1,
            ServiceURL = "https://s3.localhost.localstack.cloud:4566",
            UseHttp = true,
            ForcePathStyle = true
        });
    }

    public async Task<IEnumerable<Bucket>> ListBuckets()
    {
        return (await S3Client.ListBucketsAsync()).Buckets.Select(b => new Bucket(b.BucketName, b.CreationDate));
    }

    public async Task<IEnumerable<BucketObject>> ListBucketItemsAsync(string bucket)
    {
        return (await S3Client.ListObjectsV2Async(new ListObjectsV2Request() { BucketName = bucket })).S3Objects
            .Select(b => new BucketObject(b.ChecksumAlgorithm, b.ETag, b.BucketName, b.Key, b.LastModified, b.Size)).ToList();
    }
}
