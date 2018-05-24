using System.Threading;

namespace Gentil.WebAPI.Autorize
{
    public static class AutorizeHelper
    {
        public static GentilPrincipal Principal
        {
            get { return (GentilPrincipal)Thread.CurrentPrincipal; }
            set { Thread.CurrentPrincipal = value; }
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}