using SnippetStore.MongoClass;
using SnippetStore.RegistryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnippetStore.HighlightClass
{
    public class HighlightWord
    {
        private MongoConnectionManagement connectionManagement = new MongoConnectionManagement(RegistryOps.ReadConString());
        private List<string?>? wordsToHighlight = new List<string?>();
        private List<string?>? separatorToHighlight = new List<string?>();
        private Color ResWordColor = new Color();
        private Color SepColor = new Color();

        public HighlightWord()
        {
            ResWordColor = RegistryOps.ReadResWordColor();
            SepColor = RegistryOps.ReadBlockSepColor();
        }
        public async Task<RichTextBox> WordHighlight(RichTextBox RichTextContent)
        {
            var keyw_coll = connectionManagement.GetCollection<Keywords>("Keywords");
            var resw_coll = connectionManagement.GetCollection<ResWords>("Reserved words");
            var blck_coll = connectionManagement.GetCollection<BlockSeparators>("Block separators");
            MongoKeyword mongoKeyword = new(keyw_coll);
            MongoResWord mongoResword = new(resw_coll);
            MongoBlockSep mongoBlockSep = new(blck_coll);

            wordsToHighlight = await mongoResword.GetReswordsAsync();
            separatorToHighlight = await mongoBlockSep.GetBlockSepAsync();
            ResWordColor = RegistryOps.ReadResWordColor();
            SepColor = RegistryOps.ReadBlockSepColor();

            foreach (var word in wordsToHighlight)
            {
                string pattern = $@"\b{Regex.Escape(word)}\b";
                MatchCollection matches = Regex.Matches(RichTextContent.Text, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    RichTextContent.Select(match.Index, match.Length);
                    RichTextContent.SelectionColor = ResWordColor;
                }
            }
            RichTextContent.Select(0, 0);

            foreach (var word in separatorToHighlight)
            {
                int startIndex = 0;
                while ((startIndex = RichTextContent.Text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    RichTextContent.Select(startIndex, word.Length);
                    RichTextContent.SelectionColor = SepColor;
                    startIndex += word.Length; // Továbblépés a következő előfordulásra
                }
            }
            RichTextContent.Select(0, 0);
            return RichTextContent;
        }
    }
}
