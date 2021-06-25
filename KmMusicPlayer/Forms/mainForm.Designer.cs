
namespace KmMusicPlayer.Forms
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.playStop = new System.Windows.Forms.PictureBox();
            this.btn_volume = new System.Windows.Forms.PictureBox();
            this.modeRandom = new System.Windows.Forms.PictureBox();
            this.modeOrder = new System.Windows.Forms.PictureBox();
            this.modeCycle = new System.Windows.Forms.PictureBox();
            this.playPlay = new System.Windows.Forms.PictureBox();
            this.playNext = new System.Windows.Forms.PictureBox();
            this.playLast = new System.Windows.Forms.PictureBox();
            this.volume = new System.Windows.Forms.Panel();
            this.volume1 = new System.Windows.Forms.Panel();
            this.endTime = new System.Windows.Forms.Label();
            this.starTime = new System.Windows.Forms.Label();
            this.schedule = new System.Windows.Forms.Panel();
            this.schedule1 = new System.Windows.Forms.Panel();
            this.stepTime = new System.Windows.Forms.Timer(this.components);
            this.songName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.addSongsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPlayListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFoldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.getNetSongMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.delSongsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listPlaySongs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playingDelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.playingCleanMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.playingSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.netSongInfo = new System.Windows.Forms.Label();
            this.listAllSongs = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.playStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playLast)).BeginInit();
            this.volume.SuspendLayout();
            this.schedule.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.addSongsMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.playeMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // playStop
            // 
            this.playStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playStop.Image = global::KmMusicPlayer.Properties.Resources.trayStop;
            this.playStop.Location = new System.Drawing.Point(146, 41);
            this.playStop.Name = "playStop";
            this.playStop.Size = new System.Drawing.Size(32, 32);
            this.playStop.TabIndex = 10;
            this.playStop.TabStop = false;
            this.toolTip1.SetToolTip(this.playStop, "停止");
            this.playStop.Click += new System.EventHandler(this.playStop_Click);
            this.playStop.MouseEnter += new System.EventHandler(this.playStop_MouseEnter);
            this.playStop.MouseLeave += new System.EventHandler(this.playStop_MouseLeave);
            // 
            // btn_volume
            // 
            this.btn_volume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_volume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_volume.Image = global::KmMusicPlayer.Properties.Resources.volumeButton;
            this.btn_volume.Location = new System.Drawing.Point(322, 89);
            this.btn_volume.Name = "btn_volume";
            this.btn_volume.Size = new System.Drawing.Size(18, 15);
            this.btn_volume.TabIndex = 9;
            this.btn_volume.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_volume, "静音");
            this.btn_volume.Click += new System.EventHandler(this.btn_volume_Click);
            // 
            // modeRandom
            // 
            this.modeRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modeRandom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modeRandom.Image = global::KmMusicPlayer.Properties.Resources.randomPlay;
            this.modeRandom.Location = new System.Drawing.Point(272, 89);
            this.modeRandom.Name = "modeRandom";
            this.modeRandom.Size = new System.Drawing.Size(18, 15);
            this.modeRandom.TabIndex = 8;
            this.modeRandom.TabStop = false;
            this.toolTip1.SetToolTip(this.modeRandom, "随机播放");
            this.modeRandom.Click += new System.EventHandler(this.modeRandom_Click);
            // 
            // modeOrder
            // 
            this.modeOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modeOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modeOrder.Image = global::KmMusicPlayer.Properties.Resources._2orderPlay;
            this.modeOrder.Location = new System.Drawing.Point(241, 89);
            this.modeOrder.Name = "modeOrder";
            this.modeOrder.Size = new System.Drawing.Size(18, 15);
            this.modeOrder.TabIndex = 7;
            this.modeOrder.TabStop = false;
            this.toolTip1.SetToolTip(this.modeOrder, "顺序播放");
            this.modeOrder.Click += new System.EventHandler(this.modeOrder_Click);
            // 
            // modeCycle
            // 
            this.modeCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modeCycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modeCycle.Image = global::KmMusicPlayer.Properties.Resources.cyclePlay;
            this.modeCycle.Location = new System.Drawing.Point(207, 89);
            this.modeCycle.Name = "modeCycle";
            this.modeCycle.Size = new System.Drawing.Size(18, 15);
            this.modeCycle.TabIndex = 6;
            this.modeCycle.TabStop = false;
            this.toolTip1.SetToolTip(this.modeCycle, "单曲循环");
            this.modeCycle.Click += new System.EventHandler(this.modeCycle_Click);
            // 
            // playPlay
            // 
            this.playPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playPlay.Image = global::KmMusicPlayer.Properties.Resources.trayPlay;
            this.playPlay.Location = new System.Drawing.Point(54, 33);
            this.playPlay.Name = "playPlay";
            this.playPlay.Size = new System.Drawing.Size(48, 48);
            this.playPlay.TabIndex = 2;
            this.playPlay.TabStop = false;
            this.playPlay.Tag = "null";
            this.toolTip1.SetToolTip(this.playPlay, "播放/暂停");
            this.playPlay.Click += new System.EventHandler(this.playPlay_Click);
            this.playPlay.MouseEnter += new System.EventHandler(this.playPlay_MouseEnter);
            this.playPlay.MouseLeave += new System.EventHandler(this.playPlay_MouseLeave);
            // 
            // playNext
            // 
            this.playNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playNext.Image = global::KmMusicPlayer.Properties.Resources.trayNext;
            this.playNext.Location = new System.Drawing.Point(108, 41);
            this.playNext.Name = "playNext";
            this.playNext.Size = new System.Drawing.Size(32, 32);
            this.playNext.TabIndex = 1;
            this.playNext.TabStop = false;
            this.toolTip1.SetToolTip(this.playNext, "下一曲");
            this.playNext.Click += new System.EventHandler(this.playNext_Click);
            this.playNext.MouseEnter += new System.EventHandler(this.playNext_MouseEnter);
            this.playNext.MouseLeave += new System.EventHandler(this.playNext_MouseLeave);
            // 
            // playLast
            // 
            this.playLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playLast.Image = global::KmMusicPlayer.Properties.Resources.trayLast;
            this.playLast.Location = new System.Drawing.Point(16, 41);
            this.playLast.Name = "playLast";
            this.playLast.Size = new System.Drawing.Size(32, 32);
            this.playLast.TabIndex = 0;
            this.playLast.TabStop = false;
            this.toolTip1.SetToolTip(this.playLast, "上一曲");
            this.playLast.Click += new System.EventHandler(this.playLast_Click);
            this.playLast.MouseEnter += new System.EventHandler(this.playLast_MouseEnter);
            this.playLast.MouseLeave += new System.EventHandler(this.playLast_MouseLeave);
            // 
            // volume
            // 
            this.volume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volume.BackColor = System.Drawing.Color.White;
            this.volume.Controls.Add(this.volume1);
            this.volume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volume.Location = new System.Drawing.Point(346, 92);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(80, 8);
            this.volume.TabIndex = 11;
            this.volume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volume_MouseDown);
            // 
            // volume1
            // 
            this.volume1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volume1.BackColor = System.Drawing.Color.Gray;
            this.volume1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volume1.Location = new System.Drawing.Point(3, 2);
            this.volume1.Name = "volume1";
            this.volume1.Size = new System.Drawing.Size(38, 4);
            this.volume1.TabIndex = 0;
            this.volume1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volume1_MouseDown);
            // 
            // endTime
            // 
            this.endTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endTime.AutoSize = true;
            this.endTime.ForeColor = System.Drawing.Color.White;
            this.endTime.Location = new System.Drawing.Point(379, 63);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(47, 15);
            this.endTime.TabIndex = 5;
            this.endTime.Text = "00:00";
            // 
            // starTime
            // 
            this.starTime.AutoSize = true;
            this.starTime.ForeColor = System.Drawing.Color.White;
            this.starTime.Location = new System.Drawing.Point(195, 63);
            this.starTime.Name = "starTime";
            this.starTime.Size = new System.Drawing.Size(47, 15);
            this.starTime.TabIndex = 4;
            this.starTime.Text = "00:00";
            // 
            // schedule
            // 
            this.schedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schedule.BackColor = System.Drawing.Color.White;
            this.schedule.Controls.Add(this.schedule1);
            this.schedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.schedule.Location = new System.Drawing.Point(195, 52);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(231, 8);
            this.schedule.TabIndex = 3;
            this.schedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.schedule_MouseDown);
            // 
            // schedule1
            // 
            this.schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schedule1.BackColor = System.Drawing.Color.Gray;
            this.schedule1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.schedule1.Location = new System.Drawing.Point(3, 2);
            this.schedule1.Name = "schedule1";
            this.schedule1.Size = new System.Drawing.Size(11, 4);
            this.schedule1.TabIndex = 0;
            this.schedule1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.schedule1_MouseDown);
            // 
            // stepTime
            // 
            this.stepTime.Tick += new System.EventHandler(this.stepTime_Tick);
            // 
            // songName
            // 
            this.songName.AutoSize = true;
            this.songName.Location = new System.Drawing.Point(193, 31);
            this.songName.Name = "songName";
            this.songName.Size = new System.Drawing.Size(0, 15);
            this.songName.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.playPlay);
            this.groupBox1.Controls.Add(this.songName);
            this.groupBox1.Controls.Add(this.playLast);
            this.groupBox1.Controls.Add(this.playNext);
            this.groupBox1.Controls.Add(this.volume);
            this.groupBox1.Controls.Add(this.schedule);
            this.groupBox1.Controls.Add(this.playStop);
            this.groupBox1.Controls.Add(this.starTime);
            this.groupBox1.Controls.Add(this.btn_volume);
            this.groupBox1.Controls.Add(this.endTime);
            this.groupBox1.Controls.Add(this.modeRandom);
            this.groupBox1.Controls.Add(this.modeCycle);
            this.groupBox1.Controls.Add(this.modeOrder);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 127);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(3, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 282);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.ContextMenuStrip = this.addSongsMenu;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 263);
            this.tabControl1.TabIndex = 1;
            // 
            // addSongsMenu
            // 
            this.addSongsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.addSongsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPlayListMenu,
            this.openFoldMenu,
            this.openListMenu,
            this.getNetSongMenu,
            this.delSongsMenu,
            this.cleanListMenu,
            this.saveListMenu});
            this.addSongsMenu.Name = "addSongsMenu";
            this.addSongsMenu.Size = new System.Drawing.Size(214, 172);
            // 
            // addPlayListMenu
            // 
            this.addPlayListMenu.Name = "addPlayListMenu";
            this.addPlayListMenu.Size = new System.Drawing.Size(213, 24);
            this.addPlayListMenu.Text = "添加到播放列表";
            this.addPlayListMenu.Click += new System.EventHandler(this.addPlayListMenu_Click);
            // 
            // openFoldMenu
            // 
            this.openFoldMenu.Name = "openFoldMenu";
            this.openFoldMenu.Size = new System.Drawing.Size(213, 24);
            this.openFoldMenu.Text = "扫描文件夹添加歌曲";
            this.openFoldMenu.Click += new System.EventHandler(this.openFoldMenu_Click);
            // 
            // openListMenu
            // 
            this.openListMenu.Name = "openListMenu";
            this.openListMenu.Size = new System.Drawing.Size(213, 24);
            this.openListMenu.Text = "加载歌曲清单";
            this.openListMenu.Click += new System.EventHandler(this.openListMenu_Click);
            // 
            // getNetSongMenu
            // 
            this.getNetSongMenu.Name = "getNetSongMenu";
            this.getNetSongMenu.Size = new System.Drawing.Size(213, 24);
            this.getNetSongMenu.Text = "获取网络歌曲";
            this.getNetSongMenu.Click += new System.EventHandler(this.getNetSongMenu_Click);
            // 
            // delSongsMenu
            // 
            this.delSongsMenu.Name = "delSongsMenu";
            this.delSongsMenu.Size = new System.Drawing.Size(213, 24);
            this.delSongsMenu.Text = "删除选中歌曲";
            this.delSongsMenu.Click += new System.EventHandler(this.delSongsMenu_Click);
            // 
            // cleanListMenu
            // 
            this.cleanListMenu.Name = "cleanListMenu";
            this.cleanListMenu.Size = new System.Drawing.Size(213, 24);
            this.cleanListMenu.Text = "清空歌曲列表";
            this.cleanListMenu.Click += new System.EventHandler(this.cleanListMenu_Click);
            // 
            // saveListMenu
            // 
            this.saveListMenu.Name = "saveListMenu";
            this.saveListMenu.Size = new System.Drawing.Size(213, 24);
            this.saveListMenu.Text = "保存歌曲清单";
            this.saveListMenu.Click += new System.EventHandler(this.saveListMenu_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listPlaySongs);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "播放列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listPlaySongs
            // 
            this.listPlaySongs.AllowDrop = true;
            this.listPlaySongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listPlaySongs.ContextMenuStrip = this.playeMenu;
            this.listPlaySongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPlaySongs.FullRowSelect = true;
            this.listPlaySongs.HideSelection = false;
            this.listPlaySongs.Location = new System.Drawing.Point(3, 3);
            this.listPlaySongs.MultiSelect = false;
            this.listPlaySongs.Name = "listPlaySongs";
            this.listPlaySongs.Size = new System.Drawing.Size(425, 228);
            this.listPlaySongs.TabIndex = 0;
            this.listPlaySongs.UseCompatibleStateImageBehavior = false;
            this.listPlaySongs.View = System.Windows.Forms.View.Details;
            this.listPlaySongs.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listPlaySongs.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listPlaySongs.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listPlaySongs.Resize += new System.EventHandler(this.listView1_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "歌曲名";
            // 
            // playeMenu
            // 
            this.playeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.playeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playingDelMenu,
            this.playingCleanMenu,
            this.playingSaveMenu});
            this.playeMenu.Name = "addSongsMenu";
            this.playeMenu.Size = new System.Drawing.Size(169, 76);
            // 
            // playingDelMenu
            // 
            this.playingDelMenu.Name = "playingDelMenu";
            this.playingDelMenu.Size = new System.Drawing.Size(168, 24);
            this.playingDelMenu.Text = "删除选中歌曲";
            this.playingDelMenu.Click += new System.EventHandler(this.playingDelMenu_Click);
            // 
            // playingCleanMenu
            // 
            this.playingCleanMenu.Name = "playingCleanMenu";
            this.playingCleanMenu.Size = new System.Drawing.Size(168, 24);
            this.playingCleanMenu.Text = "清空播放列表";
            this.playingCleanMenu.Click += new System.EventHandler(this.playingCleanMenu_Click);
            // 
            // playingSaveMenu
            // 
            this.playingSaveMenu.Name = "playingSaveMenu";
            this.playingSaveMenu.Size = new System.Drawing.Size(168, 24);
            this.playingSaveMenu.Text = "保存歌曲清单";
            this.playingSaveMenu.Click += new System.EventHandler(this.playingSaveMenu_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.netSongInfo);
            this.tabPage2.Controls.Add(this.listAllSongs);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "所有歌曲";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // netSongInfo
            // 
            this.netSongInfo.AutoSize = true;
            this.netSongInfo.Location = new System.Drawing.Point(10, 216);
            this.netSongInfo.Name = "netSongInfo";
            this.netSongInfo.Size = new System.Drawing.Size(0, 15);
            this.netSongInfo.TabIndex = 2;
            // 
            // listAllSongs
            // 
            this.listAllSongs.AllowDrop = true;
            this.listAllSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listAllSongs.ContextMenuStrip = this.addSongsMenu;
            this.listAllSongs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAllSongs.FullRowSelect = true;
            this.listAllSongs.HideSelection = false;
            this.listAllSongs.Location = new System.Drawing.Point(3, 3);
            this.listAllSongs.Name = "listAllSongs";
            this.listAllSongs.Size = new System.Drawing.Size(425, 228);
            this.listAllSongs.TabIndex = 1;
            this.listAllSongs.UseCompatibleStateImageBehavior = false;
            this.listAllSongs.View = System.Windows.Forms.View.Details;
            this.listAllSongs.DoubleClick += new System.EventHandler(this.listAllSongs_DoubleClick);
            this.listAllSongs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listAllSongs_KeyDown);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "编号";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "歌曲名";
            // 
            // mainForm
            // 
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(458, 412);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KmMusicPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Move += new System.EventHandler(this.mainForm_Move);
            ((System.ComponentModel.ISupportInitialize)(this.playStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playLast)).EndInit();
            this.volume.ResumeLayout(false);
            this.schedule.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.addSongsMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.playeMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox playLast;
        private System.Windows.Forms.PictureBox playNext;
        private System.Windows.Forms.PictureBox playPlay;
        private System.Windows.Forms.Panel schedule;
        private System.Windows.Forms.Panel schedule1;
        private System.Windows.Forms.Label starTime;
        private System.Windows.Forms.Label endTime;
        private System.Windows.Forms.PictureBox modeCycle;
        private System.Windows.Forms.PictureBox modeOrder;
        private System.Windows.Forms.PictureBox modeRandom;
        private System.Windows.Forms.PictureBox btn_volume;
        private System.Windows.Forms.PictureBox playStop;
        private System.Windows.Forms.Panel volume1;
        private System.Windows.Forms.Panel volume;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer stepTime;
        private System.Windows.Forms.Label songName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listPlaySongs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip addSongsMenu;
        private System.Windows.Forms.ToolStripMenuItem openFoldMenu;
        private System.Windows.Forms.ToolStripMenuItem openListMenu;
        private System.Windows.Forms.ToolStripMenuItem saveListMenu;
        private System.Windows.Forms.ToolStripMenuItem delSongsMenu;
        private System.Windows.Forms.ToolStripMenuItem cleanListMenu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listAllSongs;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip playeMenu;
        private System.Windows.Forms.ToolStripMenuItem playingDelMenu;
        private System.Windows.Forms.ToolStripMenuItem playingCleanMenu;
        private System.Windows.Forms.ToolStripMenuItem playingSaveMenu;
        private System.Windows.Forms.ToolStripMenuItem addPlayListMenu;
        private System.Windows.Forms.ToolStripMenuItem getNetSongMenu;
        private System.Windows.Forms.Label netSongInfo;
    }
}
