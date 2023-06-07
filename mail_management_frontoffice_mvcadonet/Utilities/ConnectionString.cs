namespace mail_management_frontoffice_mvcadonet.Utilities
{
    public static class ConnectionString
    {
        private static string conName = "Data Source=LUKAS-MSI\\SQLEXPRESS01;Initial Catalog=mail_management_db;Integrated Security=True";
        public static string CName
        {
            get => conName;
        }
    }
}
