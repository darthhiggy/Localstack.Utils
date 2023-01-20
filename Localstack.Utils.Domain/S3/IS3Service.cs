using Amazon.S3.Model;
using Localstack.Utils.Domain.S3.Models;

namespace Localstack.Utils.Domain.S3;

public interface IS3Service
{
    Task<IEnumerable<Bucket>> ListBuckets();
    Task<IEnumerable<BucketObject>> ListBucketItemsAsync(string bucket);
}
