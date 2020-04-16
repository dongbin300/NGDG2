using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGDG2
{
    public class PathUtil
    {
        public static string LocalPath => Environment.CurrentDirectory;
        public static string AccountPath => LocalPath + @"\Resource\Account\";
        public static string NFDPath => LocalPath + @"\Resource\NFD\";
    }
}
