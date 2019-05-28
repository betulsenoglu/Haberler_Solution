using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haberler.WebUI.MVC
{
    /// <summary>
    /// Bu class, json veriyi okurken hp agility pack classları ile HTML taglerini modify etmemizi sağlar.
    /// </summary>
    public class GoogleAmpConverter
    {
        private readonly string source;

        public GoogleAmpConverter(string source)
        {
            this.source = source;
        }

        public static string Convert(string source)
        {
            var converter = new GoogleAmpConverter(source);
            return converter.Convert();
        }

        public string Convert()
        {
            var result = ReplaceIframeWithLink(source);
            result = StripInlineStyles(result);
            result = ReplaceEmbedWithLink(result);
            result = UpdateAmpImages(result);
            return result;
        }

        private string ReplaceIframeWithLink(string current)
        {
            //Bu cs dosyasi icin HtmlAgilityPack (install-package HtmlAgilityPack) paketi gereklidir!
            var doc = GetHtmlDocument(current);
            var elements = doc.DocumentNode.Descendants("iframe");
            foreach (var htmlNode in elements)
            {
                if (htmlNode.Attributes["src"] == null)
                {
                    continue;
                }
                var link = htmlNode.Attributes["src"].Value;
                var paragraph = doc.CreateElement("p");
                var text = link; // Gelecekte burası genişletilebilir
                var anchor = doc.CreateElement("a");
                anchor.InnerHtml = text;
                anchor.Attributes.Add("href", link);
                anchor.Attributes.Add("title", text);
                paragraph.InnerHtml = anchor.OuterHtml;
                var original = htmlNode.OuterHtml;
                var replacement = paragraph.OuterHtml;
                current = current.Replace(original, replacement);
            }

            return current;
        }

        private string StripInlineStyles(string current)
        {

            //Bu cs dosyasi icin HtmlAgilityPack (install-package HtmlAgilityPack) paketi gereklidir!
            var doc = GetHtmlDocument(current);
            var elements = doc.DocumentNode.Descendants();


            foreach (var htmlNode in elements)
            {
                if (htmlNode.Attributes["style"] != null)
                {
                    htmlNode.Attributes.Remove(htmlNode.Attributes["style"]);
                }

                if (htmlNode.Attributes["onclick"] == null)
                {
                    continue;
                }

                htmlNode.Attributes.Remove(htmlNode.Attributes["onclick"]);

                doc.GetElementbyId("click_area").ChildNodes.FirstOrDefault().Attributes.Add("role", "button");
              //  doc.GetElementbyId("click_area").ChildNodes.FirstOrDefault().Attributes.Add("on", "tap:popup"); 
                doc.GetElementbyId("click_area").ChildNodes.FirstOrDefault().Attributes.Add("tabindex", "0");

            }

            var builder = new StringBuilder();
            var writer = new StringWriter(builder);
            doc.Save(writer);
            return builder.ToString();
        }

        private string ReplaceEmbedWithLink(string current)
        {
            //Bu cs dosyasi icin HtmlAgilityPack (install-package HtmlAgilityPack) paketi gereklidir!
            var doc = GetHtmlDocument(current);
            var elements = doc.DocumentNode.Descendants("embed");
            foreach (var htmlNode in elements)
            {
                if (htmlNode.Attributes["src"] == null) continue;

                var link = htmlNode.Attributes["src"].Value;
                var paragraph = doc.CreateElement("p");
                var anchor = doc.CreateElement("a");
                anchor.InnerHtml = link;
                anchor.Attributes.Add("href", link);
                anchor.Attributes.Add("title", link);
                paragraph.InnerHtml = anchor.OuterHtml;
                var original = htmlNode.OuterHtml;
                var replacement = paragraph.OuterHtml;

                current = current.Replace(original, replacement);

            }

            return current;
        }

        private string UpdateAmpImages(string current)
        {
            //Bu cs dosyasi icin HtmlAgilityPack (install-package HtmlAgilityPack) paketi gereklidir!
            var doc = GetHtmlDocument(current);
            var imageList = doc.DocumentNode.Descendants("img");

            const string ampImage = "amp-img";
            if (!imageList.Any())
            {
                return current;
            }

            if (!HtmlNode.ElementsFlags.ContainsKey("amp-img"))
            {
                HtmlNode.ElementsFlags.Add("amp-img", HtmlElementFlag.Closed);
            }

            foreach (var imgTag in imageList)
            {
                var original = imgTag.OuterHtml;
                var replacement = imgTag.Clone();
                replacement.Name = ampImage;
                replacement.SetAttributeValue("width", "700px");
                replacement.SetAttributeValue("height", "350px");
                current = current.Replace(original, replacement.OuterHtml);
            }


            return current;
        }

        private HtmlDocument GetHtmlDocument(string htmlContent)
        {
            var doc = new HtmlDocument
            {
                OptionOutputAsXml = false,
                OptionDefaultStreamEncoding = Encoding.UTF8
            };
            doc.LoadHtml(htmlContent);

            return doc;
        }
    }
}
