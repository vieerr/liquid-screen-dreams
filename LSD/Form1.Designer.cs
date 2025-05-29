namespace LSD
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Button btnSelectPlay;

        // Missing declarations
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;

        private System.Windows.Forms.ProgressBar progressBarSong;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblTotalTime;

        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label lblVolume;

        private System.Windows.Forms.Label lblSongTitle;
        private System.Windows.Forms.Timer timerMarquee;
        private System.Windows.Forms.Timer timerProgress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.progressBarSong = new System.Windows.Forms.ProgressBar();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblSongTitle = new System.Windows.Forms.Label();
            this.timerMarquee = new System.Windows.Forms.Timer(this.components);
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.btnSelectPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(323, 375);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 34);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "⏵";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(242, 375);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 34);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "⏸";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(404, 374);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 34);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "⏹";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(485, 375);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 34);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "⏭";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(161, 375);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 34);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "⏮";
            // 
            // progressBarSong
            // 
            this.progressBarSong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBarSong.Location = new System.Drawing.Point(12, 415);
            this.progressBarSong.Name = "progressBarSong";
            this.progressBarSong.Size = new System.Drawing.Size(669, 23);
            this.progressBarSong.TabIndex = 7;
            this.progressBarSong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressBarSong_MouseDown);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCurrentTime.Location = new System.Drawing.Point(12, 445);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(100, 23);
            this.lblCurrentTime.TabIndex = 8;
            this.lblCurrentTime.Text = "0:00";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalTime.Location = new System.Drawing.Point(581, 441);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(100, 23);
            this.lblTotalTime.TabIndex = 9;
            this.lblTotalTime.Text = "0:00";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBarVolume.Location = new System.Drawing.Point(12, 461);
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(253, 56);
            this.trackBarVolume.TabIndex = 10;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // lblVolume
            // 
            this.lblVolume.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVolume.Location = new System.Drawing.Point(271, 461);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(100, 23);
            this.lblVolume.TabIndex = 11;
            this.lblVolume.Text = "Volumen";
            // 
            // lblSongTitle
            // 
            this.lblSongTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSongTitle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSongTitle.Location = new System.Drawing.Point(14, 13);
            this.lblSongTitle.Name = "lblSongTitle";
            this.lblSongTitle.Size = new System.Drawing.Size(669, 23);
            this.lblSongTitle.TabIndex = 12;
            this.lblSongTitle.Text = "Título de la canción";
            this.lblSongTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerMarquee
            // 
            this.timerMarquee.Tick += new System.EventHandler(this.timerMarquee_Tick);
            // 
            // timerProgress
            // 
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.BackColor = System.Drawing.Color.Black;
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(669, 356);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            // 
            // btnSelectPlay
            // 
            this.btnSelectPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelectPlay.Location = new System.Drawing.Point(497, 476);
            this.btnSelectPlay.Name = "btnSelectPlay";
            this.btnSelectPlay.Size = new System.Drawing.Size(184, 32);
            this.btnSelectPlay.TabIndex = 1;
            this.btnSelectPlay.Text = "Seleccionar y Reproducir";
            this.btnSelectPlay.UseVisualStyleBackColor = true;
            this.btnSelectPlay.Click += new System.EventHandler(this.btnSelectPlay_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(695, 520);
            this.Controls.Add(this.lblSongTitle);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.btnSelectPlay);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.progressBarSong);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.lblVolume);
            this.Name = "Form1";
            this.Text = "Rhythm Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
