
using Batheer.Application.Reports.Queries.ExportFamilyMembers;
using Batheer.Application.Reports.Queries.ExportFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.ExportSupportingFamilyRequests;
using Batheer.Application.Reports.Queries.SearchInFamilies;
using Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.SearchInSupportingFamilyRequests;
using System.Collections.Generic;

namespace Batheer.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildSearchInFamilyRegistrationRequestsDtoFile(IEnumerable<SearchInFamilyRegistrationRequestsDto> records);
        byte[] BuildSearchInFamiliesDtoFile(IEnumerable<SearchInFamiliesDto> records);
        byte[] BuildSearchInSupportingFamilyRequestsDtoFile(IEnumerable<SearchInSupportingFamilyRequestsDto> records);
        byte[] BuildExportFamilyRegistrationRequestsDtoFile(IEnumerable<ExportFamilyRegistrationRequestsDto> records);
        byte[] BuildExportFamilyMembersDtoFile(IEnumerable<ExportFamilyMembersDto> records);
        byte[] BuildExportSupportingFamilyRequestsDtoFile(IEnumerable<ExportSupportingFamilyRequestsDto> records);
    }
}
