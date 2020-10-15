/*
Разработать класс по анализу HTML-содержимого web-страниц заданного интернет ресурса
(выбирается студентом самостоятельно), например, орг. структуры ЮУрГУ
(https://www.susu.ru/ru/structure).
Анализ должен осуществляться по всем страницам, URI которых включает базовый URI ресурса
(интернет-домен, например, www.susu.ru). Предусмотреть настройку максимального 
уровня вложенности страниц в рекурсивном алгоритме анализа, а также 
максимального количества просматриваемых страниц.
В класс добавить событие (event) по определению цели поиска, с передачей в его обработчик
информации о названии ссылки, ведущей на страницу (т.е. имя ссылки, которое видит
пользователь на базовой странице в браузере, например, «Филиалы»), URI страницы (например,
https://www.susu.ru/ru/university/structure/electronics-higher-school/kafedry), уровне вложенности
(например, 1) и самой цели поиска (см. разбивку задания по вариантам). Если целей на странице
несколько, то событие вызывается для каждой цели. 
Обработчик события должен выводить информацию на консоль (или в окно) и 
в CSV-файл в табличной форме. CSV-файл можно открыть в Excel.
Применение событийной модели позволит отделить друг от друга алгоритм поиска данных на
страницах и алгоритм отображения/вывода информации на консоль/в файл.

Рекомендации:
Использовать классы, реализующие HTTP-протокол, например, WebClient, HttpWebRequest,
HttpWebResponse (using System.Net). Для анализа текста внутри HTML-страницы можно
воспользоваться регулярными выражениями (класс System.Text.RegularExpressions.Regex).

Цель поиска – E-Mail на странице

*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper;
using System.Globalization;

namespace labs {

    class lab4 {

        public void Main4() {
            
            HTML_Analysis analysis = new HTML_Analysis();

            analysis.Uri = "https://www.susu.ru/ru/student/poleznye-ssylki";
            analysis.Result += OnResult;
            analysis.Analysis();

        }

        private static void OnResult(WebPage page) {

            // вывод данных на консоль

            string emails;
            if (page.Purpose.Count != 0) {
                List<string> ListEmails = page.Purpose.Cast<Match>().Select(m => m.Value).ToList();
                emails = string.Join(",", ListEmails.Distinct()); // исключать повторения emails  
            } else {
                emails = "Not found";
            }

            Console.WriteLine("Link name: {0}", page.LinkName);
            Console.WriteLine("URI: {0}", page.Uri);
            Console.WriteLine("Level: {0}", page.Level);
            Console.WriteLine("Purpose (Email): {0}", emails);

            // запись данных в csv-файл

            using (var stream = File.Open("analysis.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {    

                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = false;
                csv.WriteField(page.LinkName);
                csv.WriteField(page.Uri);
                csv.WriteField(page.Level);
                csv.WriteField(emails);
                csv.NextRecord();

            }

            /*var csv = new StringBuilder();
            var newLine = string.Format("{0}, {1}, {2}, {3}", page.LinkName, page.Uri, 
                                        page.Level, emails, 
                                        Environment.NewLine);
            csv.AppendLine(newLine);  

            File.AppendAllText("analysis.csv", csv.ToString());*/

        }


    }

    class HTML_Analysis {
        
        public string Uri { get; set; }
        private int cur_lvl = 1;
        private string lvl_i = "https://";
        
        public delegate void Handler(WebPage page);
        public event Handler Result;


        public int GetLevels() {

            // определить количество уровней
            int levels = -1;
            foreach (char ch in Uri) {
                if (ch == '/') {
                    levels++;
                }
            }

            return levels;
        }

        public string GetLink(int item) {

            // разбить на уровни и вернуть заданный уровень

            return Uri.Split("/")[item];
        }

        public bool Analysis() {
            
            if (cur_lvl <= GetLevels()) {
                
                // получить HTML-содержимое web-страницы
                lvl_i += GetLink(cur_lvl + 1) + "/";

                WebClient client = new WebClient();
                string page = client.DownloadString(new Uri(lvl_i));

                // С помощью регулярных выражений из страницы извлечь данные
                WebPage webPage = new WebPage();
                webPage.LinkName = Regex.Matches(page, @"<title>\s*(.+?)\s*</title>")[0].Groups[1];
                webPage.Uri = new Uri(lvl_i);
                webPage.Level = cur_lvl;
                //webPage.Purpose = Regex.Matches(page, @"\b[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b");
                webPage.Purpose = Regex.Matches(page, @"\b[A-Z0-9._%+-]+[ ]{0,3}(\[at\])[ ]{0,3}[A-Z0-9.-]+[ ]{0,3}(\[dot\])[ ]{0,3}[A-Z]{2,4}\b", 
                                                RegexOptions.IgnoreCase);

                cur_lvl++;
                
                // вызов события
                Result?.Invoke(webPage);

                return Analysis();

            } else return true; 

        }

    }

    class WebPage {

        public Group LinkName { get; set; }

        public Uri Uri { get; set; }

        public int Level { get; set; }

        public MatchCollection Purpose { get; set; }

    }

}
