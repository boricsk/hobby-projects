using MongoDB.Bson;
using MongoDB.Driver;
using SnippetStore.MongoClass;
using SnippetStore.RegistryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnippetStore.SearchClass
{
    public class SearchManagement
    {
        MongoConnectionManagement connMgmnt = new(RegistryOps.ReadConString());
        public bool isNameInDatabase(string name)
        {            
            var snip_coll = connMgmnt.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);

            var filtered = snipStore.GetSnipets()
                .AsQueryable()
                .Where(s => s.SnipName != null && s.SnipName == name)
                .GroupBy(l => l.SnipName);

            if (filtered.Count() == 0) { return false; } else { return true; }
        }

        public IEnumerable<IGrouping<string, SnippetDatabase>> MainScreenSearch(string searchValue)
        {
            var snip_coll = connMgmnt.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);

            bool[] op = new bool[3];
            op = RegistryOps.ReadSearchOptions();

            var ret = snipStore.GetSnipets().AsQueryable()
                        .Where(x => (op[2] && x.SnipKeywords.Contains(searchValue)) ||
                                    (op[3] && x.SnipName != null && x.SnipName.Contains(searchValue)) ||
                                    (op[1] && x.SnipShortDesc != null && x.SnipShortDesc.Contains(searchValue)) ||
                                    (op[0] && x.SnipCode != null && x.SnipCode.Contains(searchValue)))
                        .ToList().GroupBy(l => l.SnipLanguage);
            return ret;
            // ConvertRichTextToPlain(x.SnipCode).Contains(searchValue)
        }


    }
}
