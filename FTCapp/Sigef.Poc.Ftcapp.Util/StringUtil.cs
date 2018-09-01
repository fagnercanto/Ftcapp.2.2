
namespace Sigef.Poc.FTCapp.Util
{
    public static class StringUtil
    {
        public static string IsNullReturnEmpty(object objectString)
        {
            string result = "";
            if (objectString != null)
            {
                result = objectString.ToString();
            }

            return result;
        }

    }
}
