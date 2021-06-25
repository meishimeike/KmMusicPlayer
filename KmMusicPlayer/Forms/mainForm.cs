using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KmMusicPlayer.Classes;

namespace KmMusicPlayer.Forms
{
    public partial class mainForm : Form
    {
        string songListPath = Environment.CurrentDirectory + "\\songs.ls";
        string songPlayPath = Environment.CurrentDirectory + "\\play.ls";
        string musicDirectory = "";
        MediaPlayer mediaPlayer = new MediaPlayer();
        
        bool isChangeSongList = false;
        bool isChangePlayList = false;

        bool isAutoPlay = true;
        int playModel = 1;
        int playIndex = 0;

        LrcForm lrcForm = new LrcForm();

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            listPlaySongs.Columns[0].Width = (int)(listPlaySongs.Width * 0.2);
            listPlaySongs.Columns[1].Width = (int)(listPlaySongs.Width * 0.75);
            listAllSongs.Columns[0].Width = (int)(listAllSongs.Width * 0.2);
            listAllSongs.Columns[1].Width = (int)(listAllSongs.Width * 0.75);

            if (File.Exists(songPlayPath))
                AddSongs(0, GetListSongs(songPlayPath), false);

            if (File.Exists(songListPath))
                AddSongs(1,GetListSongs(songListPath),false);

            musicDirectory = Environment.GetLogicalDrives().Last() + "Music\\";
            if (!Directory.Exists(musicDirectory)) Directory.CreateDirectory(musicDirectory);

            //歌词显示
            //lrcForm.ReturnSize += LrcForm_ReturnSize;
            lrcForm.Height = this.Height;
            lrcForm.Left = this.Left + this.Width - 13;
            lrcForm.Top = this.Top;
            lrcForm.Show();
        }

        private void LrcForm_ReturnSize(int height)
        {
            this.Height = height;
        }

        private void PlayList_playSong(int index,string songname, string songurl)
        {
            stepTime.Enabled = true;
            isAutoPlay = true;
            mediaPlayer.Play(songname,songurl);
            playPlay.Image = Properties.Resources.trayPause;
            playPlay.Tag = "Playing";
            playIndex = index;
            string lrcfile = musicDirectory + songname + ".lrc";
            if (File.Exists(lrcfile))
                lrcForm.LoadLrc(lrcfile);
            else
            {
                if (Lrc.DownloadLrc(lrcfile))
                {
                    lrcForm.LoadLrc(lrcfile);
                }
            }
        }

        private void playLast_MouseEnter(object sender, EventArgs e)
        {
            playLast.Image = Properties.Resources._2trayLast;
        }

        private void playLast_MouseLeave(object sender, EventArgs e)
        {
            playLast.Image = Properties.Resources.trayLast;
        }

        private void playPlay_MouseEnter(object sender, EventArgs e)
        {
            if (playPlay.Tag.ToString()=="Playing")
            {
                playPlay.Image = Properties.Resources._2trayPause;
            }else
            {
                playPlay.Image = Properties.Resources._2trayPlay;
            }
        }

        private void playPlay_MouseLeave(object sender, EventArgs e)
        {
            if (playPlay.Tag.ToString() == "Playing")
            {
                playPlay.Image = Properties.Resources.trayPause;
            }
            else
            {
                playPlay.Image = Properties.Resources.trayPlay;
            }
        }

        private void playNext_MouseEnter(object sender, EventArgs e)
        {
            playNext.Image = Properties.Resources._2trayNext;
        }

        private void playNext_MouseLeave(object sender, EventArgs e)
        {
            playNext.Image = Properties.Resources.trayNext;
        }

        private void playStop_MouseEnter(object sender, EventArgs e)
        {
            playStop.Image = Properties.Resources._2trayStop;
        }

        private void playStop_MouseLeave(object sender, EventArgs e)
        {
            playStop.Image = Properties.Resources.trayStop;

        }
        private void schedule_MouseDown(object sender, MouseEventArgs e)
        {
            float pro = (float)e.Location.X / schedule.Width;
            schedule1.Size = new Size(e.Location.X, 4);
            mediaPlayer.SetSchedule(pro);
        }

        private void schedule1_MouseDown(object sender, MouseEventArgs e)
        {
            float pro = (float)e.Location.X / schedule1.Width;
            schedule1.Size = new Size(e.Location.X, 4);
            mediaPlayer.SetSchedule(pro);
        }

        private void volume_MouseDown(object sender, MouseEventArgs e)
        {
            float pro = (float)e.Location.X / volume.Width;
            volume1.Size = new Size(e.Location.X, 4);
            mediaPlayer.SetVolume(Convert.ToInt32(pro * 100));
        }

        private void volume1_MouseDown(object sender, MouseEventArgs e)
        {
            float pro = (float)e.Location.X / volume.Width;
            volume1.Size = new Size(e.Location.X, 4);
            mediaPlayer.SetVolume(Convert.ToInt32(pro * 100));
        }

        private void stepTime_Tick(object sender, EventArgs e)
        {
            List<string> status = mediaPlayer.GetStatues();

            songName.Text = status[0];
            starTime.Text = status[2];
            endTime.Text = status[3];
            schedule1.Size = new Size((int)((schedule.Width-4) * float.Parse(status[4])), 4);
            if (isAutoPlay && status[1]== "Ended")
            {
                playModelSong(1);
            }
            if(status[1] == "Playing")
            {
                lrcForm.SetShowLrc(ToSecond(status[2]));
            }
        }
        private int ToSecond(string time)
        {
            string[] ts = time.Split(':');
            int m = int.Parse(ts[0]);
            int s = int.Parse(ts[1]);
            return m * 60 + s;
        }

        private void playPlay_Click(object sender, EventArgs e)
        {
            if (playPlay.Tag.ToString() == "Playing")
            {
                mediaPlayer.Pause();
                playPlay.Image = Properties.Resources._2trayPlay;
                playPlay.Tag = "Pause";
            }
            else
            {
                stepTime.Enabled = true;
                mediaPlayer.Play();
                playPlay.Image = Properties.Resources._2trayPause;
                playPlay.Tag = "Playing";
            }
           
        }

        private void playStop_Click(object sender, EventArgs e)
        {
            stepTime.Enabled = false;
            isAutoPlay = false;
            mediaPlayer.Stop();
            playPlay.Image = Properties.Resources.trayPlay;
            playPlay.Tag = "Stop";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listPlaySongs.SelectedItems.Count != 1) return;
            string songname = listPlaySongs.SelectedItems[0].SubItems[1].Text;
            string songurl = listPlaySongs.SelectedItems[0].Tag.ToString();
            PlayList_playSong(listPlaySongs.SelectedItems[0].Index,songname, songurl);
           
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] rs = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < rs.Length; i++)
                {

                    ListViewItem listView = new ListViewItem(new string[] { (listPlaySongs.Items.Count + 1).ToString(), Path.GetFileNameWithoutExtension(rs[i]) });
                    listView.Tag = rs[i];
                    listPlaySongs.Items.Add(listView);
                }
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btn_volume_Click(object sender, EventArgs e)
        {
            if (mediaPlayer.GetMute())
            {
                mediaPlayer.SetMute(false);
                btn_volume.Image = Properties.Resources.volumeButton;
            }
            else
            {
                mediaPlayer.SetMute(true);
                btn_volume.Image = Properties.Resources.volumeButtonX;
            }
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            listPlaySongs.Columns[0].Width = (int)(listPlaySongs.Width * 0.2);
            listPlaySongs.Columns[1].Width = (int)(listPlaySongs.Width * 0.75);
            listAllSongs.Columns[0].Width = (int)(listAllSongs.Width * 0.2);
            listAllSongs.Columns[1].Width = (int)(listAllSongs.Width * 0.75);

            //歌词显示
            lrcForm.Height = this.Height;
            lrcForm.Left = this.Left + this.Width - 13;
            lrcForm.Top = this.Top;
        }

        private void openFoldMenu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                AddSongs(1,GetFoldSongs(folderBrowser.SelectedPath));
            }
        }

        private void openListMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "歌曲清单|*.ls";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                AddSongs(1,GetListSongs(openFile.FileName));
            }
        }

        private void AddSongs(int listType, List<KeyValuePair<string, string>> songs, bool isSave = true)
        {
            if (songs == null) return;
            for (int i=0; i< songs.Count;i++)
            {
                KeyValuePair<string, string> song = songs[i];
                if (listType == 0)
                {

                    ListViewItem viewItem = new ListViewItem(new string[] { (listPlaySongs.Items.Count + 1).ToString(), song.Key });
                    viewItem.Tag = song.Value;
                    listPlaySongs.Items.Add(viewItem);
                    isChangePlayList = isSave;
                }
                    
                if (listType == 1)
                {
                    ListViewItem viewItem = new ListViewItem(new string[] { (listAllSongs.Items.Count + 1).ToString(), song.Key });
                    viewItem.Tag = song.Value;
                    if (listAllSongs.InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            listAllSongs.Items.Add(viewItem);
                        }));
                    }
                    else
                    {
                        listAllSongs.Items.Add(viewItem);
                    }
                    isChangeSongList = isSave;
                }               
            }

            
        }

        private List<KeyValuePair<string, string>> GetListSongs(string path)
        {
            List<KeyValuePair<string, string>> songList = new List<KeyValuePair<string, string>>();
            string[] songs = File.ReadAllLines(path);
            if (songs == null) return null;
            foreach(string song in songs)
            {
                string[] songinfo = song.Split('|');
                string name = Base64Helper.Base64Decrypt(songinfo[0]);
                string url = Base64Helper.Base64Decrypt(songinfo[1]);
                songList.Add(new KeyValuePair<string, string>(Path.GetFileNameWithoutExtension(name), url));
            }
            return songList;
        }
        private List<KeyValuePair<string,string>> GetFoldSongs(string dir)
        {
            List<KeyValuePair<string, string>> songList = new List<KeyValuePair<string, string>>();
            string[] songex = new string[] { ".mp3", ".wav", ".wma", ".flac" };
            if (!Directory.Exists(dir)) return null;
            string[] songs = Directory.GetFiles(dir);
            for (int i = 0; i < songs.Length; i++)
            {
                string song = songs[i];
                string ext = Path.GetExtension(song).ToLower();
                if (songex.Contains(ext))
                {
                    songList.Add(new KeyValuePair<string, string>(Path.GetFileNameWithoutExtension(song),song));
                }
            }

            string[] subDirectory = Directory.GetDirectories(dir);
            if (subDirectory != null)
            {
                foreach (string s in subDirectory)
                {
                    songList.AddRange(GetFoldSongs(s));
                }
            }
            return songList;
        }

        private void saveListMenu_Click(object sender, EventArgs e)
        {
            if (listAllSongs.Items.Count == 0) return;
            string song = "";
            foreach (ListViewItem item in listAllSongs.Items)
            {
                song += $"{Base64Helper.Base64Encrypt(item.SubItems[1].Text)}|{Base64Helper.Base64Encrypt(item.Tag.ToString())}{Environment.NewLine}";
            }
            File.WriteAllText(songListPath, song);
            isChangeSongList = false;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChangePlayList)
            {
                if (MessageBox.Show("播放清单没有保存，是否保存清单？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    playingSaveMenu_Click(null, null);
                }
            }

            if (isChangeSongList)
            {
                if (MessageBox.Show("歌曲没有保存，是否保存清单？", "保存", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    saveListMenu_Click(null, null);
                }
            }

        }

        private void delSongsMenu_Click(object sender, EventArgs e)
        {
            if (listPlaySongs.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认要删除选中歌曲吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                   for(int i = listAllSongs.SelectedItems.Count-1; i >= 0; i--)
                    {
                        listAllSongs.SelectedItems[i].Remove();
                    }
                }

                isChangeSongList = true;
            }
        }

        private void cleanListMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要清空歌曲列表吗？", "清空", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listAllSongs.Items.Clear();
                isChangeSongList = true;
            }
            
        }

        private void playNext_Click(object sender, EventArgs e)
        {
            playModelSong(1);
        }

        private void playLast_Click(object sender, EventArgs e)
        {
            playModelSong(-1);
        }

        private void playModelSong(int type)
        {
            switch (playModel)
            {
                case 0:
                    mediaPlayer.Play();
                    break;
                case 1:
                    if(type==1)
                        if (playIndex == listPlaySongs.Items.Count - 1) playIndex = 0; else playIndex += 1;
                    if(type==-1)
                        if (playIndex == 0) playIndex = listPlaySongs.Items.Count - 1; else playIndex -= 1;
                    string songname1 = listPlaySongs.Items[playIndex].SubItems[1].Text;
                    string songurl1 = listPlaySongs.Items[playIndex].Tag.ToString();
                    PlayList_playSong(playIndex,songname1, songurl1);
                    break;
                case 2:
                    Random random = new Random();
                    playIndex = random.Next(0, listPlaySongs.Items.Count);
                    string songname2 = listPlaySongs.Items[playIndex].SubItems[1].Text;
                    string songurl2 = listPlaySongs.Items[playIndex].Tag.ToString();
                    PlayList_playSong(playIndex, songname2, songurl2);
                    break;
                default:
                    break;
            }

            listPlaySongs.Items[playIndex].Selected = true;
        }

        private void modeCycle_Click(object sender, EventArgs e)
        {
            playModel = 0;
            modeCycle.Image = Properties.Resources._2cyclePlay;
            modeOrder.Image = Properties.Resources.orderPlay;
            modeRandom.Image = Properties.Resources.randomPlay;
        }

        private void modeOrder_Click(object sender, EventArgs e)
        {
            playModel = 1;
            modeCycle.Image = Properties.Resources.cyclePlay;
            modeOrder.Image = Properties.Resources._2orderPlay;
            modeRandom.Image = Properties.Resources.randomPlay;
        }

        private void modeRandom_Click(object sender, EventArgs e)
        {
            playModel = 2;
            modeCycle.Image = Properties.Resources.cyclePlay;
            modeOrder.Image = Properties.Resources.orderPlay;
            modeRandom.Image = Properties.Resources._2randomPlay;
        }

        private void playingDelMenu_Click(object sender, EventArgs e)
        {
            if (listPlaySongs.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认要删除选中歌曲吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    for (int i = listPlaySongs.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        listPlaySongs.SelectedItems[i].Remove();
                    }
                }
                isChangePlayList = true;
            }
        }

        private void playingCleanMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要清空歌曲列表吗？", "清空", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listPlaySongs.Items.Clear();
                isChangePlayList = true;
            }
        }

        private void playingSaveMenu_Click(object sender, EventArgs e)
        {
            if (listPlaySongs.Items.Count == 0) return;
            string song = "";
            foreach (ListViewItem item in listPlaySongs.Items)
            {
                song += $"{Base64Helper.Base64Encrypt(item.SubItems[1].Text)}|{Base64Helper.Base64Encrypt(item.Tag.ToString())}{Environment.NewLine}";
            }
            File.WriteAllText(songPlayPath, song);
            isChangePlayList = false;
        }

        private void listAllSongs_DoubleClick(object sender, EventArgs e)
        {
            addToPlayList();
        }

        private void addPlayListMenu_Click(object sender, EventArgs e)
        {
            addToPlayList();
        }

        private void addToPlayList()
        {
            if (listAllSongs.SelectedItems.Count > 0)
            {
                foreach(ListViewItem listViewItem in listAllSongs.SelectedItems)
                {
                    string songName = listViewItem.SubItems[1].Text;
                    string songUrl = listViewItem.Tag.ToString();

                    ListViewItem viewItem = new ListViewItem(new string[] { (listPlaySongs.Items.Count + 1).ToString(), songName });
                    viewItem.Tag = songUrl;
                    listPlaySongs.Items.Add(viewItem);
                }
                isChangePlayList = true;
                MessageBox.Show("添加到播放列表成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }          
        }

        private void getNetSongMenu_Click(object sender, EventArgs e)
        {
            GetSongs getSongs = new GetSongs("https://www.9ku.com");
            getSongs.GetStatus += GetSongs_GetStatus;
            System.Threading.Thread getSongThread = new System.Threading.Thread(getSongs.GetNetSongs);
            getSongThread.Start();
        }

        private void GetSongs_GetStatus(bool status, string msg, List<KeyValuePair<string,string>> songs)
        {
            if (status)
            {
                if (songs == null) return;
                AddSongs(1, songs, true);
                setInfo("");
            }else
            {
                setInfo(msg);
            }
        }
        private void setInfo(string msg)
        {
            if (netSongInfo.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    netSongInfo.Text = msg;
                }));
            }
            else
            {
                netSongInfo.Text = msg;
            }
        }

        private void mainForm_Move(object sender, EventArgs e)
        {
            //歌词显示
            lrcForm.Left = this.Left + this.Width - 13;
            lrcForm.Top = this.Top;
        }

        private void listAllSongs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                for (int i = 0; i < listAllSongs.Items.Count; i++)
                {
                    listAllSongs.Items[i].Selected = true;
                }
            }
        }
    }


}
