using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using HAP = HtmlAgilityPack;

namespace KmMusicPlayer
{
    class SongInfo
    {
        public string id = null;
        public string id2 = null;
        public string mname = null;
        public string gsid = null;
        public string singer = null;
        public string wma = null;
        public string m4a = null;
        public string zjid = null;
        public string zjname = null;
        public string zjpic = null;
        public string gspic = null;
        public string status = null;
    }
    class GetSongs
    {
        public delegate void Status(bool status,string msg,List<KeyValuePair<string, string>> songs);
        public event Status GetStatus;
        static List<KeyValuePair<string, string>> ListSong = new List<KeyValuePair<string, string>>();
        string SongsUrl;
        internal GetSongs(string songurl)
        {
            SongsUrl = songurl;
        }
        internal void GetNetSongs()
        {
            ListSong.Clear();
            List<KeyValuePair<string, string>> songurllist = new List<KeyValuePair<string, string>>();
            HAP.HtmlDocument HD = new HAP.HtmlDocument();
            string html = GetContent(SongsUrl);
            HD.LoadHtml(html);

            string[] maths = new string[] { "//a[@class=\"songName\"]", "//a[@class=\"songName \"]" };
            foreach (string math in maths)
            {
                var HNC = HD.DocumentNode.SelectNodes(math);
                if (HNC == null) continue;
                for (int i = 0; i < HNC.Count; i++)
                {
                    HAP.HtmlNode HN = HNC[i];
                    string songname = HN.InnerText;
                    string songurl = HN.Attributes["href"].Value;
                    foreach (var kp in songurllist)
                    {
                        if (kp.Key == songname) continue;
                    }
                    if (songname == "" || songurl == "") continue;
                    int songid = int.Parse(Path.GetFileNameWithoutExtension(songurl));
                    string tpath = ((int)songid / 1000 + 1).ToString();
                    string song = $"{ SongsUrl}/html/playjs/{tpath}/{songid}.js";
                    songurllist.Add(new KeyValuePair<string, string>(songname, song));
                }
            }
            if (songurllist == null) return; else ListSong.Clear();

            int pointer = 0;
            List<Thread> GetSonginfo = new List<Thread>();
            while (pointer < songurllist.Count - 1)
            {
                for (int i = 0; i < GetSonginfo.Count; i++)
                {
                    if (!GetSonginfo[i].IsAlive)
                    {
                        GetSonginfo.RemoveAt(i);
                    }
                }
                if (GetSonginfo.Count < 10)
                {
                    GetStatus(false,$"开始获取网络歌曲 <{songurllist[pointer].Key}>",null);
                    Thread GetSong = new Thread(() => SaveSongs(songurllist[pointer].Value));
                    GetSonginfo.Add(GetSong);
                    GetSong.Start();
                    pointer++;
                }
                Thread.Sleep(100);
            }
            if (ListSong == null) return;
            
            GetStatus(true,"获取网络歌曲完成", ListSong);
        }

        private void SaveSongs(string songurl)
        {
            string jsonStr = GetContent(songurl);
            if (string.IsNullOrWhiteSpace(jsonStr)) return;
            jsonStr = jsonStr.Replace("(", "");
            jsonStr = jsonStr.Replace(")", "");
            SongInfo LSI = JsonUtil.JsonToObjList(jsonStr);
            ListSong.Add(new KeyValuePair<string, string>(LSI.mname,LSI.wma));
        }
        private string GetContent(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                using (HttpClient httpClient = new HttpClient(handler) { Timeout = new TimeSpan(0, 0, 20) })
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");
                    httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                    httpClient.DefaultRequestHeaders.Add("ContentType", "text/html;charset=utf-8");
                    string result = httpClient.GetStringAsync(url).Result;
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
    class JsonUtil
    {
        /// <summary>
        /// 用于将Json格式的字符串反序化为List。 当传入的Json字符串有误的时候, 抛出一个异常（JsonException）
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="jsonStr">Json字符串</param>
        /// <returns>List对象或者null</returns>
        public static List<T> JsonToObjList<T>(string jsonStr)
        {
            List<T> objList = null;
            try
            {
                objList = JsonConvert.DeserializeObject<List<T>>(jsonStr);
            }
            catch (Exception e)
            {
                throw new JsonException("Json的格式可能错误," + e.Message);
            }
            return objList;
        }

        /// <summary>
        /// 用于将Json格式的字符串反序化为List。 当传入的Json字符串有误的时候, 抛出一个异常（JsonException）
        /// </summary>
        /// <param name="jsonStr">Json字符串</param>
        /// <returns>对象或者null</returns>
        public static SongInfo JsonToObjList(string jsonStr)
        {
            SongInfo objList;
            try
            {
                objList = JsonConvert.DeserializeObject<SongInfo>(jsonStr);
            }
            catch (Exception e)
            {
                throw new JsonException("Json的格式可能错误," + e.Message);
            }
            return objList;
        }
    }
}
