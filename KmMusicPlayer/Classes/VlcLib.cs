using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmMusicPlayer.Classes
{
    class MediaPlayer
    {
        string songName;
        Vlc.DotNet.Core.VlcMediaPlayer mediaPlayer;
        internal MediaPlayer()
        {
            DirectoryInfo directoryInfo;
            if (IntPtr.Size == 4)
                directoryInfo = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86\"));
            else
                directoryInfo = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64\"));
            mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(directoryInfo);
            mediaPlayer.Audio.Volume = 50;
        }

        /// <summary>
        /// 设置音量
        /// </summary>
        /// <param name="value">音量大小</param>
        internal void SetVolume(int value)
        {
            mediaPlayer.Audio.Volume = value;
        }

        /// <summary>
        /// 获取音量
        /// </summary>
        internal int GetVolume()
        {
            return mediaPlayer.Audio.Volume;
        }

        /// <summary>
        /// 静音设置
        /// </summary>
        /// <param name="isMute">静音为true</param>
        internal void SetMute(bool isMute)
        {
            mediaPlayer.Audio.IsMute = isMute;
        }

        /// <summary>
        /// 获取是否静音
        /// </summary>
        /// <returns></returns>
        internal bool GetMute()
        {
            return mediaPlayer.Audio.IsMute;
        }
        /// <summary>
        /// 播放
        /// </summary>
        internal void Play()
        {
            mediaPlayer.Play();

        }

        /// <summary>
        /// 获取播放进度
        /// </summary>
        /// <returns></returns>
        internal long GetSchedule()
        {
            return mediaPlayer.Time;
        }

        /// <summary>
        /// 设置播放进度
        /// </summary>
        /// <param name="proportion">百分比%</param>
        internal void SetSchedule(float proportion)
        {
            mediaPlayer.Time = (long)(mediaPlayer.Length * proportion);
        }

        /// <summary>
        /// 播放文件
        /// </summary>
        /// <param name="file">文件路径</param>
        internal void Play(string nane,string file)
        {
            songName = nane;
            if (File.Exists(file))
            {
                FileInfo fileInfo = new FileInfo(file);
                mediaPlayer.Play(fileInfo);
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.Match(file, "^http://|https://").Success)
                {
                    mediaPlayer.Play(new Uri(file));
                }
                else
                {
                    throw new Exception("文件路径有误");
                }
            }
        }


        /// <summary>
        /// 暂停
        /// </summary>
        internal void Pause()
        {
            mediaPlayer.Pause();
        }

        /// <summary>
        /// 停止
        /// </summary>
        internal void Stop()
        {
            mediaPlayer.Stop();
        }

        internal List<string> GetStatues()
        {
            List<string> statues = new List<string>();
            statues.Add(songName);
            statues.Add(mediaPlayer.State.ToString());
            statues.Add(GetTime(mediaPlayer.Time));
            statues.Add(GetTime(mediaPlayer.Length));
            statues.Add(((float)mediaPlayer.Time / mediaPlayer.Length).ToString());
            return statues;

        }

        string GetTime(long time)
        {
            int mi, se, ms;
            ms = (int)time % 1000;
            mi = (int)(time / 60000);
            se = (int)((time - mi * 60000) / 1000);
            return $"{mi:00}:{se:00}.{ms:000}";
        }
    }
}
