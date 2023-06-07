using mail_management_backoffice.Enums;
using Microsoft.AspNetCore.Identity;

namespace mail_management_backoffice.Models
{
    public class ChangeHistory
    {
        public int ID { get; set; }
        public int MailID { get; set; } 
        public Mail Mail { get; set; }
        public MailFlag PreviousFlag { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public MailStatus PreviousStatus { get; set; }
        public MailFlag UpdatedFlag { get; set; }
        public MailStatus UpdatedStatus { get; set; }
        public string UpdateUserID { get; set; }  
        public IdentityUser UpdateUser { get; set; }    


        public ChangeHistory(int mailID, MailFlag previousFlag, DateTime? updatedDate, MailStatus previousStatus, MailFlag updatedFlag, MailStatus updatedStatus, string updateUserID)
        {
            MailID = mailID;
            PreviousFlag = previousFlag;
            UpdatedDate = updatedDate;
            PreviousStatus = previousStatus;
            UpdatedFlag = updatedFlag;
            UpdatedStatus = updatedStatus;
            UpdateUserID = updateUserID;
        }   
    }
}
