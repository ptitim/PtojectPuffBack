using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StackExchange.Redis;

namespace Service.DTO
{
    /// <summary>
    /// This dto is used for realisators or actors
    /// </summary>
    public class FullNameDto
    {
        public string FullName { get; private set; }

        public FullNameDto(string fullname)
        {
            FullName = fullname;
        }

        #region Methods

        /// <summary>
        /// Parse names from string
        /// separator ';'
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static List<FullNameDto> ParseString(string raw)
        {
            var listNames = raw.Split(';');

            return listNames.Select(str => new FullNameDto(str)).ToList();
        }

        /// <summary>
        /// Serialize names into string
        /// separator ';'
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(List<FullNameDto> obj)
        {
            var str = "";

            if (!obj.Any()) return str;
            
            foreach (var name in obj)
            {
                str += name.FullName;
                str += ";";
            }

            return str;
        }

        #endregion
    }
}