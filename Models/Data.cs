using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;

namespace SourceryWeb.Models
{
    public static class Data
    {
        private static string path { get; set; } = "E:\\bot\\"; //CHANGE PATH OR MAKE LOADER
        private static string log { get; } = path + "log.txt";
        private static string promos { get; } = path + "promos.txt";
        private static string expired { get; } = path + "expired.txt";
        private static string ops { get; } = path + "ops.txt";
        private static string list { get; } = path + "list.txt";
        private static string oplist { get; } = path + "oplist.txt";
        private static string cache { get; } = path + "cache\\";
        private static string local { get; } = path + "local\\";

        public static void Log(string data)
        {
            using (StreamWriter sw = File.AppendText(log))
            {
                sw.WriteLine(data);
            }
        }

        public static IReadOnlyList<string> GetExpired()
        {
            List<string> init = new List<string>();
            using (StreamReader sr = File.OpenText(expired))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    init.Add(s);
                }
            }
            return init as IReadOnlyList<string>;
        }

        public static IReadOnlyList<Promo> GetPromos()
        {
            List<Promo> init = new List<Promo>();
            using (StreamReader sr = File.OpenText(promos))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length < 9)
                    {
                        continue;
                    }
                    if (GetExpired().Contains(s.Substring(0, 9)))
                    {
                        if (s[0] == 'I')
                        {
                            init.Add(new Promo(s, false));
                        }
                        init.Add(new Promo(s, true));
                    }
                    else
                    {
                        init.Add(new Promo(s, false));
                    }
                }
            }
            return init as IReadOnlyList<Promo>;
        }

        public static IReadOnlyList<string> GetOP()
        {
            List<string> init = new List<string>();
            using (StreamReader sr = File.OpenText(ops))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    init.Add(s);
                }
            }
            return init as IReadOnlyList<string>;
        }
        public static void AddExpired(string data)
        {
            using (StreamWriter sw = File.AppendText(expired))
            {
                sw.WriteLine("");
                sw.Write(data);
            }
        }
        public static void AddPromo(string src)
        {
            using (StreamWriter sw = File.AppendText(promos))
            {
                sw.WriteLine("");
                sw.Write(src);
            }
        }
        public static string GetList()
        {
            string s = "";
            using (StreamReader sr = File.OpenText(list))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    s += str + "\n";
                }
            }
            return s;
        }
        public static string GetOPList()
        {
            string s = "";
            using (StreamReader sr = File.OpenText(oplist))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    s += str + "\n";
                }
            }
            return s;
        }
        public static void AddOP(string id)
        {
            using (StreamWriter sw = File.AppendText(ops))
            {
                sw.WriteLine("");
                sw.Write(id);
            }
        }
        public static void RemoveOP(string id)
        {
            string s = "";
            using (StreamReader sr = File.OpenText(ops))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    s += str + "\n";
                }
            }
            s = s.Replace("\n" + id + "\n", "\n");
            using (StreamWriter sw = File.CreateText(ops))
            {
                sw.Write(s);
            }
        }
        public static void Load(string uri, Pack pack)
        {
            var webclient = new WebClient();
            string destname = uri.Substring(uri.LastIndexOf('/') + 1, uri.Length - uri.LastIndexOf('/') - 1);
            webclient.DownloadFileCompleted += LoadCompleted;
            pack.dest = cache + destname;
            webclient.DownloadFileAsync(new Uri(uri), cache + destname, pack);
        }

        private static async void LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var pack = e.UserState as Pack?;
            using (Stream stream = File.OpenRead(pack.Value.dest))
            {
                await pack.Value.client.SendDocumentAsync(
                    chatId: pack.Value.msg.Chat.Id,
                    document: new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream, pack.Value.dest)
                );
            }
            File.Delete(pack.Value.dest);
        }
        
        public static void InitializeComponents()
        {
            if (!File.Exists(ops))
            {
                File.WriteAllText(ops, "493473011");
            }
            if (!File.Exists(log))
            {
                File.WriteAllText(log, "");
            }
            if (!File.Exists(promos))
            {
                File.WriteAllText(promos, "");
            }
            if (!File.Exists(expired))
            {
                File.WriteAllText(expired, "");
            }
            if (!File.Exists(list))
            {
                File.WriteAllText(list, "");
            }
            if (!File.Exists(oplist))
            {
                File.WriteAllText(oplist, "");
            }
            if (!Directory.Exists(cache))
            {
                Directory.CreateDirectory(cache);
            }
            if (!Directory.Exists(local))
            {
                Directory.CreateDirectory(local);
            }
        }
    }
}