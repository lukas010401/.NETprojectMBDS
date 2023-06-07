namespace mail_management_backoffice.Models
{
    public class Recipient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Mail> Mails { get; set; } = new List<Mail>();// Utiliser une liste de courriers
    }
}
