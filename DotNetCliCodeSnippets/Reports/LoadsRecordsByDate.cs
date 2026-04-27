#region

using System;
using System.Threading.Tasks;
using Vonage.Reports;
using Vonage.Reports.LoadRecords;

#endregion

namespace DotnetCliCodeSnippets.Reports;

public class LoadsRecordsByDate : ReportBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var product = Enum.Parse<ReportProduct>(Environment.GetEnvironmentVariable("REPORT_PRODUCT")!);
        var accountId = Environment.GetEnvironmentVariable("ACCOUNT_ID");
        var direction = Enum.Parse<RecordDirection>(Environment.GetEnvironmentVariable("REPORT_DIRECTION")!);
        var dateStart = DateTimeOffset.Parse(Environment.GetEnvironmentVariable("DATE_START")!);
        var dateEnd = DateTimeOffset.Parse(Environment.GetEnvironmentVariable("DATE_END")!);
        var request = LoadRecordsRequest.Build()
            .WithProduct(product)
            .WithAccountId(accountId)
            .WithDirection(direction)
            .WithDateStart(dateStart)
            .WithDateEnd(dateEnd)
            .Create();
        var response = await Client.ReportsClient.LoadRecordsAsync(request);
    }
}