// <auto-generated>
//     This file was generated by a T4 template.
//     Don't change it directly as your change would get overwritten. Instead, make changes
//     to the .tt file (i.e. the T4 template) and save it to regenerate this file.
// </auto-generated>

using System;

namespace StackExchange.StacMan
{
    /// <summary>
    /// StacMan MigrationInfo, corresponding to Stack Exchange API v2's migration_info type
    /// http://api.stackexchange.com/docs/types/migration-info
    /// </summary>
    public partial class MigrationInfo : StacManType
    {
        /// <summary>
        /// on_date
        /// </summary>
        [Field("on_date")]
        public DateTime OnDate { get; internal set; }

        /// <summary>
        /// other_site
        /// </summary>
        [Field("other_site")]
        public Site OtherSite { get; internal set; }

        /// <summary>
        /// question_id
        /// </summary>
        [Field("question_id")]
        public int QuestionId { get; internal set; }

    }
}