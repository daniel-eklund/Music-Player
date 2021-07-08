namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Main = new System.Windows.Forms.Panel();
            this.Player = new System.Windows.Forms.Panel();
            this.addBox = new System.Windows.Forms.ListBox();
            this.NextSongs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.SongTitle = new System.Windows.Forms.Label();
            this.MusicList = new System.Windows.Forms.ListBox();
            this.button_panel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Label();
            this.currItemInfo = new System.Windows.Forms.Label();
            this.audioPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.PageTitle = new System.Windows.Forms.Label();
            this.playTimer = new System.Windows.Forms.Timer(this.components);
            this.deleteBox = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.PictureBox();
            this.editButton = new System.Windows.Forms.PictureBox();
            this.shuffleButton = new System.Windows.Forms.PictureBox();
            this.previousButton = new System.Windows.Forms.PictureBox();
            this.nextButton = new System.Windows.Forms.PictureBox();
            this.reverseButton = new System.Windows.Forms.PictureBox();
            this.repeatButton = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.PictureBox();
            this.addPlaylist = new System.Windows.Forms.Button();
            this.playListName = new System.Windows.Forms.TextBox();
            this.Main.SuspendLayout();
            this.Player.SuspendLayout();
            this.button_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reverseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.AutoScroll = true;
            this.Main.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Main.Controls.Add(this.playListName);
            this.Main.Controls.Add(this.addPlaylist);
            this.Main.Controls.Add(this.Player);
            this.Main.Controls.Add(this.MusicList);
            this.Main.Controls.Add(this.button_panel);
            this.Main.Controls.Add(this.currItemInfo);
            this.Main.Controls.Add(this.audioPlayer);
            this.Main.Controls.Add(this.PageTitle);
            this.Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(1409, 808);
            this.Main.TabIndex = 0;
            // 
            // Player
            // 
            this.Player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Player.Controls.Add(this.deleteBox);
            this.Player.Controls.Add(this.deleteButton);
            this.Player.Controls.Add(this.addBox);
            this.Player.Controls.Add(this.editButton);
            this.Player.Controls.Add(this.NextSongs);
            this.Player.Controls.Add(this.label1);
            this.Player.Controls.Add(this.back);
            this.Player.Controls.Add(this.SongTitle);
            this.Player.Location = new System.Drawing.Point(87, 108);
            this.Player.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(1101, 536);
            this.Player.TabIndex = 2;
            // 
            // addBox
            // 
            this.addBox.BackColor = System.Drawing.SystemColors.Menu;
            this.addBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBox.FormattingEnabled = true;
            this.addBox.HorizontalScrollbar = true;
            this.addBox.ItemHeight = 36;
            this.addBox.Location = new System.Drawing.Point(0, 68);
            this.addBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addBox.Name = "addBox";
            this.addBox.ScrollAlwaysVisible = true;
            this.addBox.Size = new System.Drawing.Size(1232, 396);
            this.addBox.TabIndex = 12;
            this.addBox.Visible = false;
            // 
            // NextSongs
            // 
            this.NextSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NextSongs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NextSongs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NextSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextSongs.FormattingEnabled = true;
            this.NextSongs.HorizontalScrollbar = true;
            this.NextSongs.ItemHeight = 36;
            this.NextSongs.Location = new System.Drawing.Point(8, 127);
            this.NextSongs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextSongs.Name = "NextSongs";
            this.NextSongs.Size = new System.Drawing.Size(1217, 360);
            this.NextSongs.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-61, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1228, 229);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(3, 0);
            this.back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(160, 64);
            this.back.TabIndex = 4;
            this.back.Text = "Home";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // SongTitle
            // 
            this.SongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongTitle.Location = new System.Drawing.Point(2, 68);
            this.SongTitle.Name = "SongTitle";
            this.SongTitle.Size = new System.Drawing.Size(1223, 57);
            this.SongTitle.TabIndex = 1;
            this.SongTitle.Text = "No Song Selected";
            this.SongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MusicList
            // 
            this.MusicList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MusicList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MusicList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicList.FormattingEnabled = true;
            this.MusicList.HorizontalScrollbar = true;
            this.MusicList.ItemHeight = 36;
            this.MusicList.Location = new System.Drawing.Point(85, 110);
            this.MusicList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MusicList.MinimumSize = new System.Drawing.Size(981, 252);
            this.MusicList.Name = "MusicList";
            this.MusicList.Size = new System.Drawing.Size(1269, 468);
            this.MusicList.TabIndex = 0;
            // 
            // button_panel
            // 
            this.button_panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_panel.Controls.Add(this.shuffleButton);
            this.button_panel.Controls.Add(this.previousButton);
            this.button_panel.Controls.Add(this.nextButton);
            this.button_panel.Controls.Add(this.reverseButton);
            this.button_panel.Controls.Add(this.repeatButton);
            this.button_panel.Controls.Add(this.playButton);
            this.button_panel.Controls.Add(this.timer);
            this.button_panel.Location = new System.Drawing.Point(88, 600);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(1239, 95);
            this.button_panel.TabIndex = 5;
            // 
            // timer
            // 
            this.timer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timer.Dock = System.Windows.Forms.DockStyle.Right;
            this.timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer.Location = new System.Drawing.Point(1043, 0);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(196, 95);
            this.timer.TabIndex = 4;
            this.timer.Text = "00:00/00:00";
            this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currItemInfo
            // 
            this.currItemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currItemInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.currItemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currItemInfo.Location = new System.Drawing.Point(88, 709);
            this.currItemInfo.Name = "currItemInfo";
            this.currItemInfo.Size = new System.Drawing.Size(1101, 108);
            this.currItemInfo.TabIndex = 3;
            this.currItemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // audioPlayer
            // 
            this.audioPlayer.Enabled = true;
            this.audioPlayer.Location = new System.Drawing.Point(12, 632);
            this.audioPlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.audioPlayer.Name = "audioPlayer";
            this.audioPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("audioPlayer.OcxState")));
            this.audioPlayer.Size = new System.Drawing.Size(53, 50);
            this.audioPlayer.TabIndex = 3;
            this.audioPlayer.Visible = false;
            // 
            // PageTitle
            // 
            this.PageTitle.AutoSize = true;
            this.PageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageTitle.Location = new System.Drawing.Point(77, 57);
            this.PageTitle.Name = "PageTitle";
            this.PageTitle.Size = new System.Drawing.Size(178, 39);
            this.PageTitle.TabIndex = 1;
            this.PageTitle.Text = "Collection";
            // 
            // playTimer
            // 
            this.playTimer.Enabled = true;
            this.playTimer.Tick += new System.EventHandler(this.playTimer_Tick);
            // 
            // deleteBox
            // 
            this.deleteBox.BackColor = System.Drawing.SystemColors.Menu;
            this.deleteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deleteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBox.FormattingEnabled = true;
            this.deleteBox.HorizontalScrollbar = true;
            this.deleteBox.ItemHeight = 36;
            this.deleteBox.Location = new System.Drawing.Point(0, 68);
            this.deleteBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteBox.Name = "deleteBox";
            this.deleteBox.ScrollAlwaysVisible = true;
            this.deleteBox.Size = new System.Drawing.Size(1232, 396);
            this.deleteBox.TabIndex = 14;
            this.deleteBox.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.ErrorImage = null;
            this.deleteButton.Image = global::MusicPlayer.Properties.Resources.minus_button;
            this.deleteButton.Location = new System.Drawing.Point(237, 0);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(62, 64);
            this.deleteButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deleteButton.TabIndex = 13;
            this.deleteButton.TabStop = false;
            this.deleteButton.WaitOnLoad = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.ErrorImage = null;
            this.editButton.Image = global::MusicPlayer.Properties.Resources.add_button;
            this.editButton.Location = new System.Drawing.Point(169, 0);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(62, 64);
            this.editButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editButton.TabIndex = 11;
            this.editButton.TabStop = false;
            this.editButton.WaitOnLoad = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.shuffleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shuffleButton.ErrorImage = null;
            this.shuffleButton.Image = global::MusicPlayer.Properties.Resources.shuffle_button;
            this.shuffleButton.Location = new System.Drawing.Point(98, 4);
            this.shuffleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(89, 87);
            this.shuffleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.shuffleButton.TabIndex = 10;
            this.shuffleButton.TabStop = false;
            this.shuffleButton.WaitOnLoad = true;
            this.shuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.previousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previousButton.ErrorImage = null;
            this.previousButton.Image = global::MusicPlayer.Properties.Resources.previous_button;
            this.previousButton.Location = new System.Drawing.Point(448, 4);
            this.previousButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(89, 87);
            this.previousButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previousButton.TabIndex = 9;
            this.previousButton.TabStop = false;
            this.previousButton.WaitOnLoad = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.ErrorImage = null;
            this.nextButton.Image = global::MusicPlayer.Properties.Resources.next_button;
            this.nextButton.Location = new System.Drawing.Point(693, 4);
            this.nextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(89, 87);
            this.nextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nextButton.TabIndex = 8;
            this.nextButton.TabStop = false;
            this.nextButton.WaitOnLoad = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // reverseButton
            // 
            this.reverseButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reverseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reverseButton.ErrorImage = null;
            this.reverseButton.Image = global::MusicPlayer.Properties.Resources.reverse_button;
            this.reverseButton.Location = new System.Drawing.Point(5, 4);
            this.reverseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reverseButton.Name = "reverseButton";
            this.reverseButton.Size = new System.Drawing.Size(89, 87);
            this.reverseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reverseButton.TabIndex = 7;
            this.reverseButton.TabStop = false;
            this.reverseButton.WaitOnLoad = true;
            this.reverseButton.Click += new System.EventHandler(this.reverseButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.repeatButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repeatButton.ErrorImage = null;
            this.repeatButton.Image = global::MusicPlayer.Properties.Resources.repeat_button;
            this.repeatButton.Location = new System.Drawing.Point(193, 4);
            this.repeatButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(89, 87);
            this.repeatButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.repeatButton.TabIndex = 6;
            this.repeatButton.TabStop = false;
            this.repeatButton.WaitOnLoad = true;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.ErrorImage = null;
            this.playButton.Image = global::MusicPlayer.Properties.Resources.play_button;
            this.playButton.Location = new System.Drawing.Point(570, 4);
            this.playButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(89, 87);
            this.playButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playButton.TabIndex = 0;
            this.playButton.TabStop = false;
            this.playButton.WaitOnLoad = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // addPlaylist
            // 
            this.addPlaylist.Location = new System.Drawing.Point(324, 47);
            this.addPlaylist.Name = "addPlaylist";
            this.addPlaylist.Size = new System.Drawing.Size(213, 56);
            this.addPlaylist.TabIndex = 6;
            this.addPlaylist.Text = "New Playlist";
            this.addPlaylist.UseVisualStyleBackColor = true;
            this.addPlaylist.Click += new System.EventHandler(this.addPlaylist_Click);
            // 
            // playListName
            // 
            this.playListName.Location = new System.Drawing.Point(543, 49);
            this.playListName.MaxLength = 15;
            this.playListName.Name = "playListName";
            this.playListName.Size = new System.Drawing.Size(300, 38);
            this.playListName.TabIndex = 7;
            this.playListName.Text = "Enter Playlist Name";
            this.playListName.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1409, 808);
            this.Controls.Add(this.Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(500, 500);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1445, 900);
            this.MinimumSize = new System.Drawing.Size(1445, 900);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicPlayer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.Player.ResumeLayout(false);
            this.button_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.audioPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previousButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reverseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Label PageTitle;
        private System.Windows.Forms.Panel Player;
        private System.Windows.Forms.PictureBox playButton;
        private System.Windows.Forms.Label SongTitle;
        private AxWMPLib.AxWindowsMediaPlayer audioPlayer;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label currItemInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox NextSongs;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Timer playTimer;
        private System.Windows.Forms.Panel button_panel;
        private System.Windows.Forms.PictureBox repeatButton;
        private System.Windows.Forms.PictureBox reverseButton;
        private System.Windows.Forms.PictureBox previousButton;
        private System.Windows.Forms.PictureBox nextButton;
        public System.Windows.Forms.ListBox MusicList;
        private System.Windows.Forms.PictureBox shuffleButton;
        private System.Windows.Forms.PictureBox editButton;
        private System.Windows.Forms.ListBox addBox;
        private System.Windows.Forms.PictureBox deleteButton;
        private System.Windows.Forms.ListBox deleteBox;
        private System.Windows.Forms.Button addPlaylist;
        private System.Windows.Forms.TextBox playListName;
    }
}

