using FestivalCommon.Properties;

namespace FestivalCommon
{
    public class GetResources
    {
        public static string GetResourceMesssage(string messageCode)
        {
            try
            {
                return ResourceMessages.ResourceManager.GetString(messageCode);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get tsv message
        /// </summary>
        /// <param name="messageCode"></param>
        /// <returns></returns>
        public static string GetResourceMesssageTsv(string messageCode)
        {
            try
            {
                return ResourceMessagesTsv.ResourceManager.GetString(messageCode);
            }
            catch
            {
                return null;
            }
        }
    }
}
