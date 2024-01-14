using Batheer.Application.Common.Interfaces;
using Batheer.Application.Reports.Queries.ExportFamilyMembers;
using Batheer.Application.Reports.Queries.ExportFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.ExportSupportingFamilyRequests;
using Batheer.Application.Reports.Queries.SearchInFamilies;
using Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.SearchInSupportingFamilyRequests;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        readonly CsvConfiguration _config;

        public CsvFileBuilder()
        {
            _config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldQuote = args => true,
                Delimiter = ";",
            };
        }

        public byte[] BuildExportFamilyMembersDtoFile(IEnumerable<ExportFamilyMembersDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, _config);
                csvWriter.Context.RegisterClassMap<Maps.ExportFamilyMembersDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }

        public byte[] BuildExportFamilyRegistrationRequestsDtoFile(IEnumerable<ExportFamilyRegistrationRequestsDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, _config);
                csvWriter.Context.RegisterClassMap<Maps.ExportFamilyRegistrationRequestsDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }

        public byte[] BuildExportSupportingFamilyRequestsDtoFile(IEnumerable<ExportSupportingFamilyRequestsDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, _config);

                csvWriter.Context.RegisterClassMap<Maps.ExportSupportingFamilyRequestsDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }

        public byte[] BuildSearchInFamiliesDtoFile(IEnumerable<SearchInFamiliesDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, _config);

                csvWriter.Context.RegisterClassMap<Maps.SearchInFamiliesDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }

        public byte[] BuildSearchInFamilyRegistrationRequestsDtoFile(IEnumerable<SearchInFamilyRegistrationRequestsDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, _config);

                csvWriter.Context.RegisterClassMap<Maps.SearchInFamilyRegistrationRequestsDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }

        public byte[] BuildSearchInSupportingFamilyRequestsDtoFile(IEnumerable<SearchInSupportingFamilyRequestsDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, _config);

                csvWriter.Context.RegisterClassMap<Maps.SearchInSupportingFamilyRequestsDtoMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
