using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OpenQA.Selenium.Chrome;
using ReadBySelenium.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadBySelenium.App
{
    public class SaveData
    {
        TxtPrcContext _context = new TxtPrcContext();
        public async Task Save()
        {
            while (true)
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory + @"TxtFiles\"; // Get the base directory of the application
     
                var rss = await _context.NewsSourceDetails.Where(s => s.ReadBySite).ToListAsync();
                Thread.Sleep(2000);
                System.Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Rss Links are : " + rss.Count);
                foreach (var site in rss)
                {
                    var myPath = basePath + "HtmlToXml" + site.Id+"-" +DateTime.Now.ToFileTime()+ ".txt";

                    try
                    {
                        File.WriteAllText(myPath, String.Empty);
                        var driver = new ChromeDriver();

                        driver.Navigate().GoToUrl(site.SourceUrl);
                        Thread.Sleep(10000); // Wait for 10 second 
                        string pageSource = driver.PageSource;

                        pageSource = pageSource.Replace("&lt;", "<")
                            .Replace("&gt;", ">").Replace("&nbsp;", "")
                            .Replace("&amp;", "&").Replace("&quot;", "''").Replace("\t&apos;", "'")
                            .Replace("&copy;", "©");

                        var dataSplited = pageSource.Split("?xml");
                        var data2 = dataSplited[1].Split("</pre>");
                        string finalText = "<?xml" + data2[0];
                        using (StreamWriter writer = new StreamWriter(myPath, true))
                        {
                            writer.WriteLine(finalText);
                        }
                        driver.Quit();
                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.ConformanceLevel = ConformanceLevel.Fragment;
                        settings.IgnoreWhitespace = true;
                        settings.IgnoreComments = true;
                        XmlReader xmlReader = XmlReader.Create(myPath, settings);
                        SyndicationFeed syndi = SyndicationFeed.Load(xmlReader);

                        foreach (var item in syndi.Items)
                        {
                            var news = await _context.NewsRssReeds.ToListAsync();
                            long IsRead = news.Count;
                            string? category = "";
                            string? author = "";
                            long rssLinkId = site.Id;
                            string title = item.Title.Text;
                            string? linkUrl = item.Links[0].Uri.ToString();
                            string? description = "";
                            if (item.Summary != null)
                            {
                                description = item.Summary.Text;
                            }

                            var shownLink = linkUrl.Split("/");
                            string ShownId = shownLink[2];
                            string? enclosure = "";
                            if (item.Authors.Count > 0)
                            {
                                if (item.Authors[0].Name != null)
                                    author = item.Authors[0].Name.ToString();
                                else
                                {
                                    author = item.Authors[0].Email.ToString();
                                }
                            }
                            if (item.Categories.Count > 0) category = item.Categories[0].Name.ToString();
                            string? guid = "";

                            string? publishedDate = "";
                            try
                            {
                                publishedDate = item.PublishDate.ToString();
                            }
                            catch (Exception ex)
                            {
                                string errorMasage;

                                System.Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("System Has An Error");
                                if (ex.InnerException != null)
                                {
                                    System.Console.WriteLine(ex.InnerException.Message);
                                    errorMasage = ex.InnerException.Message;
                                }
                                else
                                {
                                    System.Console.WriteLine(ex.Message);
                                    errorMasage = ex.Message;
                                }
                                string link = item.Id;

                                await AddProblematic(link, rssLinkId);

                                await AddProblematicText(link, rssLinkId);
                                await AddErrors(errorMasage, "ProblematicNewsLinks");
                                break;
                            }

                            System.Console.ForegroundColor = ConsoleColor.Blue;
                            System.Console.WriteLine("System Read A Linke With link : " + ShownId);
                            Thread.Sleep(1000);
                            var isexist = await IsExistNewsInRsses(title, linkUrl);
                            if (!isexist)
                            {
                                var id = await AddNewsInRss(rssLinkId, title, linkUrl, description, publishedDate,
                                     enclosure, author, category);
                                System.Console.ForegroundColor = ConsoleColor.Yellow;
                                System.Console.BackgroundColor = ConsoleColor.Green;
                                System.Console.WriteLine("System Save a News With Id : " + IsRead);
                                System.Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }

                        //TODO: Delete File

                        Thread.Sleep(10000);
                    }

                    catch (Exception ex)
                    {

                        string errorMasage;
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        if (ex.InnerException != null)
                        {
                            System.Console.WriteLine(ex.InnerException.Message);
                            errorMasage = ex.InnerException.Message;
                        }
                        else
                        {
                            System.Console.WriteLine(ex.Message);
                            errorMasage = ex.Message;
                        }


                        await AddErrors(errorMasage, "NewsHeadLines");
                    }
                }
                Thread.Sleep(30 * 60 * 1000);
            }
        }

        private async Task<bool> IsExistNewsInRsses(string title, string link)
        {
            return await _context.NewsRssReeds.AnyAsync(n => n.Title == title && n.LinkUrl == link);
        }

        private async Task<bool> AddProblematic(string? link, long sourceId)
        {
            if (link != null)
            {
                using (StreamWriter writer = new StreamWriter("ProblematicErrors.txt", true))
                {
                    writer.WriteLine(link + " DateTime" + "==>" + sourceId);

                }
            }
            return true;

        }
        private async Task<long> AddNewsInRss(long RssLinkId, string? title, string? linkUrl,
            string? description, string? publishedDate, string? enclosure, string? author,
            string? category)
        {
            NewsRssReed nrss = new NewsRssReed()
            {
                NewsSourceDetailId = RssLinkId,
                Title = title,
                LinkUrl = linkUrl,
                Description = description,
                PublishedDate = publishedDate,
                Enclosure = enclosure,
                Author = author,
                Category = category,

                CreateDate = DateTime.Now,
                IsOil = false

            };
            if (Convert.ToDateTime(publishedDate) > DateTime.Now)
            {
                nrss.PublishedDate = null;
            }
            else
            {
                nrss.RealPublishDate = Convert.ToDateTime(publishedDate);

            }
            await _context.NewsRssReeds.AddAsync(nrss);
            await _context.SaveChangesAsync();
            return nrss.Id;
        }
        private async Task AddErrors(string errorMessage, string tableName)
        {
            using (StreamWriter writer = new StreamWriter("Errors.txt", true))
            {
                writer.WriteLine(errorMessage + "==>" + tableName);

            }
            //ErrorEntity error = new ErrorEntity()
            //{
            //    CreateDate = DateTime.Now,
            //    ErrorName = errorMessage,
            //    TableName = tableName          
            //};
            //await _context.Errors.AddAsync(error);
            //await _context.SaveChangesAsync();
        }
        private async Task AddProblematicText(string text, long sourceId)
        {
            using (StreamWriter writer = new StreamWriter("ProblematicText.txt", true))
            {
                writer.WriteLine(text + "==>" + "Source Id is : " + sourceId);

            }
        }
    }
}
