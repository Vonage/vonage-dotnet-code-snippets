#region

using System;
using System.Threading.Tasks;
using Vonage.Reports.GetReport;

#endregion

namespace DotnetCliCodeSnippets.Reports;

public class GetReport : ReportBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var requestId = Guid.Parse(Environment.GetEnvironmentVariable("REQUEST_ID")!);
        var request = GetReportRequest.Build()
            .WithReportId(requestId)
            .Create();
        var response = await Client.ReportsClient.GetReportAsync(request);
    }
}