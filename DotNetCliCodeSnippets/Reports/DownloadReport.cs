#region

using System;
using System.Threading.Tasks;
using Vonage.Reports.DownloadReport;
using Vonage.Reports.GetReport;

#endregion

namespace DotnetCliCodeSnippets.Reports;

public class DownloadReport : ReportBaseRequest, ICodeSnippet
{
    public async Task Execute()
    {
        var requestId = Guid.Parse(Environment.GetEnvironmentVariable("FILE_ID")!);
        var request = DownloadReportRequest.Build()
            .WithFileId(requestId)
            .Create();
        var response = await Client.ReportsClient.DownloadReportAsync(request);
    }
}