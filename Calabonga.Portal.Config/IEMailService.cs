using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Calabonga.Portal.Config {

    public interface IEmailService {

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="mailFrom"></param>
        /// <param name="mailto"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        bool SendMail(string mailFrom, string mailto, string mailSubject, string mailBody, IEnumerable<HttpPostedFileBase> files);

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="mailFrom"></param>
        /// <param name="mailto"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        Task SendMailAsync(string mailFrom, string mailto, string mailSubject, string mailBody, IEnumerable<HttpPostedFileBase> files);

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="mailFrom"></param>
        /// <param name="mailto"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <returns></returns>
        bool SendMail(string mailFrom, string mailto, string mailSubject, string mailBody);

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="mailFrom"></param>
        /// <param name="mailto"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <returns></returns>
        Task SendMailAsync(string mailFrom, string mailto, string mailSubject, string mailBody);


        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="mailto"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <returns></returns>
        bool SendMail(string mailto, string mailSubject, string mailBody);
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="mailto"></param>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <returns></returns>
        Task SendMailAsync(string mailto, string mailSubject, string mailBody);

        /// <summary>
        /// Send email to admin as notification
        /// </summary>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <returns></returns>
        bool NotifyAdmin(string mailSubject, string mailBody);

        /// <summary>
        /// Send email to admin as notification
        /// </summary>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <returns></returns>
        Task NotifyAdminAsync(string mailSubject, string mailBody);

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        void SendMail(IEmailMessage message);

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendMailAsync(IEmailMessage message);
    }
}