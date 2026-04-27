#region

using System;
using System.Threading.Tasks;
using Vonage.Reports.CancelReport;

#endregion

namespace DotnetCliCodeSnippets.Reports;

public class CancelReport : ReportBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var requestId = Guid.Parse(Environment.GetEnvironmentVariable("REQUEST_ID")!);
        var request = CancelReportRequest.Build()
            .WithReportId(requestId)
            .Create();
        var response = await Client.ReportsClient.CancelReportAsync(request);
    }
}