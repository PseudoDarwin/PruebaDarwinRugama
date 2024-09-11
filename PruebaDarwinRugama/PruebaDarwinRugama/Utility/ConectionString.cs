namespace PruebaDarwinRugama.Utility
{
    public class ConectionString
    {
        private static string cName = "Server=192.168.1.115; Database=Compania;User ID=ITdemetech;Password=ITdemetech2019!, Trusted_Connection=True; MultipleActiveResultSets=true";
        public static string CName
        {
            get => cName;
        }
    }
}
