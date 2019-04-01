// <auto-generated>
//     This file was generated by a T4 template.
//     Don't change it directly as your change would get overwritten. Instead, make changes
//     to the .tt file (i.e. the T4 template) and save it to regenerate this file.
// </auto-generated>

using System;

namespace StackExchange.StacMan
{
    /// <summary>
    /// StacMan Site, corresponding to Stack Exchange API v2's site type
    /// http://api.stackexchange.com/docs/types/site
    /// </summary>
    public partial class Site : StacManType
    {
        /// <summary>
        /// aliases
        /// </summary>
        [Field("aliases")]
        public string[] Aliases { get; internal set; }

        /// <summary>
        /// api_site_parameter
        /// </summary>
        [Field("api_site_parameter")]
        public string ApiSiteParameter { get; internal set; }

        /// <summary>
        /// audience
        /// </summary>
        [Field("audience")]
        public string Audience { get; internal set; }

        /// <summary>
        /// closed_beta_date
        /// </summary>
        [Field("closed_beta_date")]
        public DateTime? ClosedBetaDate { get; internal set; }

        /// <summary>
        /// favicon_url
        /// </summary>
        [Field("favicon_url")]
        public string FaviconUrl { get; internal set; }

        /// <summary>
        /// high_resolution_icon_url -- introduced in API version 2.1
        /// </summary>
        [Field("high_resolution_icon_url")]
        public string HighResolutionIconUrl { get; internal set; }

        /// <summary>
        /// icon_url
        /// </summary>
        [Field("icon_url")]
        public string IconUrl { get; internal set; }

        /// <summary>
        /// launch_date
        /// </summary>
        [Field("launch_date")]
        public DateTime LaunchDate { get; internal set; }

        /// <summary>
        /// logo_url
        /// </summary>
        [Field("logo_url")]
        public string LogoUrl { get; internal set; }

        /// <summary>
        /// markdown_extensions
        /// </summary>
        [Field("markdown_extensions")]
        public string[] MarkdownExtensions { get; internal set; }

        /// <summary>
        /// name
        /// </summary>
        [Field("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// open_beta_date
        /// </summary>
        [Field("open_beta_date")]
        public DateTime? OpenBetaDate { get; internal set; }

        /// <summary>
        /// related_sites
        /// </summary>
        [Field("related_sites")]
        public RelatedSite[] RelatedSites { get; internal set; }

        /// <summary>
        /// site_state
        /// </summary>
        [Field("site_state")]
        public Sites.SiteState SiteState { get; internal set; }

        /// <summary>
        /// site_type
        /// </summary>
        [Field("site_type")]
        public string SiteType { get; internal set; }

        /// <summary>
        /// site_url
        /// </summary>
        [Field("site_url")]
        public string SiteUrl { get; internal set; }

        /// <summary>
        /// styling
        /// </summary>
        [Field("styling")]
        public Styling Styling { get; internal set; }

        /// <summary>
        /// twitter_account
        /// </summary>
        [Field("twitter_account")]
        public string TwitterAccount { get; internal set; }

    }
}
