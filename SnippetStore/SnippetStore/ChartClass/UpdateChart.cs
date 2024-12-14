using SnippetStore.MongoClass;
using SnippetStore.RegistryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace SnippetStore.ChartClass
{
    public class UpdateChart
    {
        private MongoConnectionManagement connectionManagement = new MongoConnectionManagement(RegistryOps.ReadConString());

        public Chart UpdateSnipNumChart(Chart chartSnippetNum)
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            var lang_coll = connectionManagement.GetCollection<Languages>("Languages");

            MongoSnipStore snipStore = new(snip_coll);
            MongoLanguage mongoLanguage = new(lang_coll);

            chartSnippetNum.Series.Clear();
            var seriesSnipNum = new Series("Snippet number by lang.");
            seriesSnipNum.ChartType = SeriesChartType.Doughnut;
            List<string?> snipNum = mongoLanguage.GetLanguages();

            foreach (var snip in snipNum)
            {
                if (snip != null)
                {
                    seriesSnipNum.Points.AddXY(snip, snipStore.GetSnipNumByLanguage(snip));
                }
            }
            chartSnippetNum.Series.Add(seriesSnipNum);
            chartSnippetNum.Series[0].IsValueShownAsLabel = true;
            return chartSnippetNum;
        }

        public Chart UpdateTopViewChart(Chart chartNumOfWiew)
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
 
            chartNumOfWiew.Series.Clear();
            var seriesViewNum = new Series("Top 5 view");
            seriesViewNum.ChartType = SeriesChartType.Doughnut;

            foreach (var v in snipStore.GetTop5Wiew())
            {
                seriesViewNum.Points.AddXY(v.Key, v.Value);
            }

            chartNumOfWiew.Series.Add(seriesViewNum);
            chartNumOfWiew.Series[0].IsValueShownAsLabel = true;
            return chartNumOfWiew;
        }
    }
}
