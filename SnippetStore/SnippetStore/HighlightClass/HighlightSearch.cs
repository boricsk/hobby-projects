using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetStore.HighlightClass

{
    public class HighlightSearch
    {
        public RichTextBox HighlightSearchResult(string searchText, RichTextBox RichTextComponent) 
        {

            if (!string.IsNullOrEmpty(searchText))
            {
                string richTextContent = RichTextComponent.Text;
                List<int> indices = FindAllOccurences(richTextContent, searchText);
                if (indices.Count > 0)
                {
                    return HighlightSearchResult(indices, searchText.Length, RichTextComponent);
                }                
            }
            return RichTextComponent;
        }
        private List<int> FindAllOccurences(string text, string searchText)
        {
            int index = 0;

            List<int> indices = new List<int>();
            while ((index = text.IndexOf(searchText, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                indices.Add(index);
                index += searchText.Length; // Lépés a következő találatra
            }
            return indices;
        }
        private RichTextBox HighlightSearchResult(List<int> indices, int lenght, RichTextBox RichTextComponent)
        {
            RichTextComponent.Select(0, 0);
            RichTextComponent.SelectionBackColor = Color.White;
            foreach (int i in indices)
            {
                RichTextComponent.Select(i, lenght);
                RichTextComponent.SelectionBackColor = Color.Yellow;
            }
            RichTextComponent.Select(0, 0);
            return RichTextComponent;
        }
        
    }
}
