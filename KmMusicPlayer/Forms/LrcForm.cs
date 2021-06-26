using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmMusicPlayer.Forms
{
    public partial class LrcForm : Form
    {
        public delegate void formSize(int height);
        //public event formSize ReturnSize;
        Classes.Lrc lrc;
        List<Label> labels = new List<Label>();
        public LrcForm()
        {
            InitializeComponent();
        }

        private void LrcForm_Load(object sender, EventArgs e)
        {
  

        }

        public void LoadLrc()
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Text = "";
            }
            labels[labels.Count / 2].Text = "暂无歌词";
            lrc = Classes.Lrc.InitLrc(null);      
        }

        public void LoadLrc(string lrcfile)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Text = "";
            }
            lrc = Classes.Lrc.InitLrc(lrcfile);
        }

        public void SetShowLrc(int millisecond)
        {
            if (lrc == null) return;
            double[] lrckeys = lrc.LrcWord.Keys.ToArray();
            int point = 0;
            for (int i=0; i< lrckeys.Length; i++)
            {
                if(i< lrckeys.Length-1 )
                {
                    if (lrckeys[i] < millisecond && millisecond < lrckeys[i + 1])
                    {
                        point = i;
                        break;
                    }                 
                }            
            }
            if (millisecond > lrckeys.Last())
            {
                point = lrckeys.Length - 1;
            }
            string[] lrcvalues = lrc.LrcWord.Values.ToArray();
            for(int i=0;i< labels.Count; i++)
            {
                int index = labels.Count / 2;
                if(i - index + point>=0 && i - index + point< lrcvalues.Length)
                    labels[i].Text = lrcvalues[i - index + point];
               else
                    labels[i].Text = "";
                
            }
        }

        private void LrcForm_SizeChanged(object sender, EventArgs e)
        {
            int updown = 20;
            int labelH = 15;
            int gap = 5;
            int n = (lrcPanl.Height - updown) / (labelH + gap);
            if (n % 2 == 1)
            {
                int nul = labels.Count;
                if (n > nul)
                {
                    for (int i = 0; i < n - nul; i++)
                    {
                        Label label = new Label();
                        label.AutoSize = false;
                        label.Height = labelH;
                        label.Width = lrcPanl.Width;
                        label.Left = 0;
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        labels.Add(label);
                    }
                }
                else
                {
                    int delnub = nul - n;
                    while (delnub > 0)
                    {
                        labels.RemoveAt(labels.Count - 1);
                        delnub--;
                    }
                }
                if (labels.Count > 0) lrcPanl.Controls.Clear();
                for (int i = 0; i < labels.Count; i++)
                {
                    labels[i].Top = i * (labelH + gap) + updown / 2;
                    if (i == labels.Count / 2) { 
                        labels[i].Font = new Font("宋体", 10, FontStyle.Bold);
                        labels[i].ForeColor = Color.MediumVioletRed;
                    }
                    else
                    {
                        labels[i].ForeColor = Color.White;
                    }
                    lrcPanl.Controls.Add(labels[i]);
                }
            }
        }

    }
}
