using Amazon.S3.Model;
using Localstack.Utils.Domain.S3;
using Localstack.Utils.Domain.S3.Models;
using Microsoft.AspNetCore.Components;

namespace Localstack.Utils.UI.Pages.ComponentBases;

public class S3UtilsBase : ComponentBase
{
    [Inject]
    public IS3Service S3Service { get; set; }

    public IEnumerable<Bucket> Buckets { get; set; }
    public IList<Bucket> SelectedBuckets { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Buckets = await S3Service.ListBuckets();

        SelectedBuckets = Buckets?.Take(1).ToList() ?? new List<Bucket>();
    }

}
