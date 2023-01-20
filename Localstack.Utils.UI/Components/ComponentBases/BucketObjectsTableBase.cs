using Localstack.Utils.Domain.S3;
using Localstack.Utils.Domain.S3.Models;
using Microsoft.AspNetCore.Components;

namespace Localstack.Utils.UI.Components.ComponentBases;

public class BucketObjectsTableBase : ComponentBase
{
    [Inject]
    public IS3Service S3Service { get; set; }

    public List<BucketObject> BucketObjects { get; set; }

    public IList<BucketObject> SelectedObjects { get; set; }

    [Parameter]
    public string BucketName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        BucketObjects = (await S3Service.ListBucketItemsAsync(BucketName)).ToList();

        SelectedObjects = BucketObjects?.Take(1).ToList() ?? new List<BucketObject>();
    }
}
