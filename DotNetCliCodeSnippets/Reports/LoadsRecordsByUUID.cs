#region

using System;
using System.Threading.Tasks;
using Vonage.Reports;
using Vonage.Reports.LoadRecords;

#endregion

namespace DotnetCliCodeSnippets.Reports;

public class LoadsRecordsByUUID : ReportBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var product = Enum.Parse<ReportProduct>(Environment.GetEnvironmentVariable("REPORT_PRODUCT")!);
        var accountId = Environment.GetEnvironmentVariable("ACCOUNT_ID");
        var direction = Enum.Parse<RecordDirection>(Environment.GetEnvironmentVariable("REPORT_DIRECTION")!);
        var id = Environment.GetEnvironmentVariable("ID");
        var request = LoadRecordsRequest.Build()
            .WithProduct(product)
            .WithAccountId(accountId)
            .WithDirection(direction)
            .WithId(id)
            .Create();
        var response = await Client.ReportsClient.LoadRecordsAsync(request);
    }
}