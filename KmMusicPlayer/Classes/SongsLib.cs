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
    internal class Song
    {
        public string id = "";
        public string id2 = "";
        public string mname = "";
        public string gsid = "";
        public string singer = "";
        public string wma = "";
        public string m4a = "";
        public string zjid = "";
        public string zjname = "";
        public string zjpic = "";
        public string gspic = "";
        public string status = "";
        public string lrc = "";
        public Song() 
        { 

        }
        public Song(string info)
        {
            string[] infos = info.Split('|');
            id = Base64Helper.Base64Decrypt(infos[0]);
            id2 = Base64Helper.Base64Decrypt(infos[1]);
            mname = Base64Helper.Base64Decrypt(infos[2]);
            gsid = Base64Helper.Base64Decrypt(infos[3]);
            singer = Base64Helper.Base64Decrypt(infos[4]);
            wma = Base64Helper.Base64Decrypt(infos[5]);
            m4a = Base64Helper.Base64Decrypt(infos[6]);
            zjid = Base64Helper.Base64Decrypt(infos[7]);
            zjname = Base64Helper.Base64Decrypt(infos[8]);
            zjpic = Base64Helper.Base64Decrypt(infos[9]);
            gspic = Base64Helper.Base64Decrypt(infos[10]);
            status = Base64Helper.Base64Decrypt(infos[11]);
            lrc = Base64Helper.Base64Decrypt(infos[12]);
        }
        public override string ToString()
        {
            return $"{Base64Helper.Base64Encrypt(id)}|{Base64Helper.Base64Encrypt(id2)}|{Base64Helper.Base64Encrypt(mname)}|{Base64Helper.Base64Encrypt(gsid)}|{Base64Helper.Base64Encrypt(singer)}|{Base64Helper.Base64Encrypt(wma)}|{Base64Helper.Base64Encrypt(m4a)}|{Base64Helper.Base64Encrypt(zjid)}|{Base64Helper.Base64Encrypt(zjname)}|{Base64Helper.Base64Encrypt(zjpic)}|{Base64Helper.Base64Encrypt(gspic)}|{Base64Helper.Base64Encrypt(status)}|{Base64Helper.Base64Encrypt(lrc)}";
        }
    }

    class GetSongs
    {
        public delegate void Status(bool status,string msg,List<Song> songs);
        public event Status GetStatus;
        static List<Song> ListSong = new List<Song>();
        string SongsUrl;
        internal GetSongs(string songurl)
        {
            SongsUrl = songurl;
        }
        internal void GetNetSongs()
        {
            ListSong.Clear();
            List<string> songurllist = new List<string>();
            GetStatus(false, "开始获取网页内容", null);
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
                        if (kp == songname) continue;
                    }
                    if (songurl == "") continue;                    
                    songurllist.Add(songurl);
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
                    Thread GetSong = new Thread(() => GetSongsInfo(songurllist[pointer]));
                    GetSonginfo.Add(GetSong);
                    GetSong.Start();
                    pointer++;
                }
                Thread.Sleep(100);
            }
            if (ListSong == null) return;
            GetStatus(true, "获取网络歌曲完成", ListSong);
        }

        private void GetSongsInfo(string songurl)
        {
            int songid = int.Parse(Path.GetFileNameWithoutExtension(songurl));
            string tpath = ((int)songid / 1000 + 1).ToString();
            string song = $"{ SongsUrl}/html/playjs/{tpath}/{songid}.js";
            string jsonStr = GetContent(song);
            if (string.IsNullOrWhiteSpace(jsonStr)) return;
            jsonStr = jsonStr.Replace("(", "");
            jsonStr = jsonStr.Replace(")", "");
            Song LSI = JsonUtil.JsonToObjList(jsonStr);

            HAP.HtmlDocument htmlDocument = new HAP.HtmlDocument();
            string songpage = GetContent(SongsUrl + songurl);
            if (songpage != "")
            {
                htmlDocument.LoadHtml(songpage);
                string lrc = htmlDocument.DocumentNode.SelectSingleNode("//textarea[@id=\"lrc_content\"]").InnerText;
                LSI.lrc = lrc;
            }       
            ListSong.Add(LSI);
            GetStatus(false, $"已添加 <{LSI.mname}>", null);
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
        public static Song JsonToObjList(string jsonStr)
        {
            Song objList;
            try
            {
                objList = JsonConvert.DeserializeObject<Song>(jsonStr);
            }
            catch (Exception e)
            {
                throw new JsonException("Json的格式可能错误," + e.Message);
            }
            return objList;
        }
    }
}
