using System;
using System.ComponentModel.DataAnnotations;
using Calabonga.Portal.Config.Properties;

namespace Calabonga.Portal.Config
{
    /// <summary>
    /// Default settings for MVC application
    /// </summary>
    [Serializable]
    public class AppSettings: IAppSettings {

        /// <summary>
        /// Event log
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "AppSettings_IsLogging_Event_log")]
        public bool IsLogging { get;  set; }

        /// <summary>
        /// Default pager size
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "AppSettings_DefaultPagerSize_Default_pager_size")]
        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_DefaultPagerSize_Default_pager_size___required")]
        [Range(2, 100)]
        public int DefaultPagerSize { get;  set; }

        /// <summary>
        /// Элекронный Robot email
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "AppSettings_RobotEmail_Robot_email")]
        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_RobotEmail_Robot_email___required")]
        [StringLength(50, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_RobotEmail_Address_of_Robot_email_should_be_at_least_50_characters")]
        [EmailAddress]
        public string RobotEmail { get;  set; }

        /// <summary>
        /// Admin email
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "AppSettings_AdminEmail_Admin_email")]
        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_AdminEmail_Admin_email___required")]
        [StringLength(50, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_AdminEmail_Address_of_Admin_email_should_be_at_least_50_characters")]
        [EmailAddress]
        public string AdminEmail { get;  set; }


        /// <summary>
        /// Оправка почты с HTML-контентом
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "AppSettings_IsHtmlForEmailMessagesEnabled_Use_HTML_in_email_messages")]
        public bool IsHtmlForEmailMessagesEnabled { get;  set; }

        /// <summary>
        /// Email server
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "AppSettings_SmtpClient_Email_server__exp__localhost_")]
        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_SmtpClient_Email_server___required")]
        [StringLength(128, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_SmtpClient_Email_server_should_be_at_least_128_characters")]
        public string SmtpClient { get;  set; }

        /// <summary>
        /// Domain URL
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "AppSettings_DomainUrl_Domain_URL")]
        [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_DomainUrl_Domain_URL___required")]
        [StringLength(256, ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "AppSettings_DomainUrl_Domain_URL_should_be_at_least_256_characters")]
        public string DomainUrl { get;  set; }
    }
}