using mail_management_backoffice.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace mail_management_backoffice.Models
{
    public class Mail
    {
        public int ID { get; set; }
        public String Ref { get; set; } // Référence
        public String Sender { get; set; } // Expéditeur
        public String Messenger { get; set; } // Coursier
        //public String Recipient { get; set; } // Destinataire
        public String MailObject { get; set; } // Objet
        public MailFlag Flag { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public MailStatus Status { get; set; } // Statut
        public String Comment { get; set; } // Commentaire
        public string CreateUserId { get; set; }
        public IdentityUser CreateUser { get; set; }
        public List<Recipient> Recipients { get; set; } = new List<Recipient>();// Utiliser une liste de destinataires
        [NotMapped]
        public List<int> RecipientIds { get; set; } = new List<int>();// Liste des identifiants des destinataires sélectionnés


    }
}
