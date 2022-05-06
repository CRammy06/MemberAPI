using System;
using System.Collections.Generic;

namespace AnthologyMemberApi.Models
{
    public partial class MemberDemographic
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
    }
}
