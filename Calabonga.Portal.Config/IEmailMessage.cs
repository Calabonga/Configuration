namespace Calabonga.Portal.Config {
    /// <summary>
    /// Simple email message to send
    /// </summary>
    public interface IEmailMessage {
        /// <summary>
        /// Mail to
        /// </summary>
        string MailTo { get; set; }

        /// <summary>
        /// Subject of email
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// Mail message text
        /// </summary>
        string Body { get; set; }
    }
}