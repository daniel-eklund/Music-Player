using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Documents;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        List<Component> database = new List<Component>();//main directory of components
        Component currItem = new Component();
        Component currPlaylist = new Component();
        Component editItem = new Component();
        List<int> shuffleList = new List<int>();
        int shuffleIndex; //hold onto so we can goto previous
        bool play = false;
        bool started = false;
        int currSelected = 0;
        bool buffering = true; //when done buffering, we can play
        bool reverse = false;
        bool shuffle = false;
        bool repeat = false;
        bool edit = false;
        bool delete = false;
        string data;
        Random rng = new Random();
        bool main = true;
        public Form1()
        {
            InitializeComponent();
            playButton.Image = Properties.Resources.play_button;
            MusicList.MouseDoubleClick += new MouseEventHandler(MusicList_MouseDoubleClick);
            MusicList.MouseClick += new MouseEventHandler(MusicList_MouseClick);
            MusicList.KeyDown += new KeyEventHandler(MusicList_KeyDown);
            NextSongs.MouseClick += new MouseEventHandler(NextSongs_MouseClick);
            NextSongs.KeyDown += new KeyEventHandler(NextSongs_KeyDown);
            audioPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(audioPlayer_PlayStateChange);
            MusicList.Size = new Size(461, 200);
            Player.Size = new Size(459, 203);
            NextSongs.Size = new Size(455, 150);
            deleteBox.Size = new Size(458, 195);
            addBox.Size = new Size(458, 195);
            addBox.MouseClick += new MouseEventHandler(addBox_MouseClick);
            addBox.KeyDown += new KeyEventHandler(addBox_KeyDown);
            deleteBox.MouseClick += new MouseEventHandler(deleteBox_MouseClick);
            deleteBox.KeyDown += new KeyEventHandler(deleteBox_KeyDown);
            playListName.KeyDown += new KeyEventHandler(playList_KeyDown);
        }

        private void playList_KeyDown(object sender, KeyEventArgs e)
        {
            if (!playListName.Visible) return;
            if (e.KeyCode == Keys.Enter)
            {
                string name = playListName.Text.ToString();
                Component pl = new Playlist();
                pl.setName(name);
                database.Add(pl);
                playListName.Visible = false;
                playListName.Text = "Enter Playlist name";
                MusicList.Items.Insert(0, ">" + name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load to default collection panel
            MusicList.Visible = true;
            Player.Visible = false;
            //on load check for application folder, if no folder, create
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\MusicPlayer\\";
            data = path + "data.txt";
            string music = path + "Music\\";
            if (Directory.Exists(path) && Directory.Exists(music))
            {
                //load documents
                FileStream fs = File.OpenRead(data);
                //display each playlist
                using (StreamReader reader = new StreamReader(fs))
                { //load our playlists from our data
                    string line = null;
                    do
                    {
                        // get the next line from the file
                        line = reader.ReadLine();
                        if (line == null) break;
                        if (line != "")
                        {
                            if (line.Substring(0, 1) == "+") //start of playlist
                            {
                                //create playlist, loop until end of playlist
                                Component temp = new Playlist();
                                temp.setName(line.Substring(1));
                                MusicList.Items.Add(">" + line.Substring(1)); //if playlist name, add
                                do
                                {
                                    line = reader.ReadLine();
                                    if (line.Substring(0, 1) == "~")
                                    {
                                        database.Add(temp);
                                        break;
                                    }
                                    if (line.Substring(0, 1) == ">")
                                    {
                                        //loop through playlist database and add to current
                                        foreach (Component c in database)
                                        {
                                            if (c.getName() == line.Substring(1)) //found playlist in loaded playlists
                                            {
                                                temp.add(c);
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    { //Add audio to playlist
                                        Component t = new Single();
                                        t.setParent(temp);
                                        t.setPath(music + line);
                                        t.setName(line);
                                        temp.add(t);
                                    }
                                } while (true); //end of playlist creator

                            }
                        }
                    } while (true);
                }

                //open and display the list of music in music folder
                string[] files = Directory.GetFiles(music);
                foreach (string f in files) //for each file left in our folder, add to our directory
                {
                    //truncate f
                    string name = f.Substring(music.Length);
                    MusicList.Items.Add(name);
                    Component temp;
                    temp = new Single();
                    temp.setName(name);
                    temp.setPath(f);
                    database.Add(temp);
                }
            }
            else
            {
                //create folders
                if (!Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
                System.IO.Directory.CreateDirectory(music);
                //create file in folder
                FileStream fs = File.Create(data);
            }
            //set currPlaylist to database
            Component curr = new Playlist();
            foreach (Component c in database) curr.add(c);
            currPlaylist = curr;
        }
        private void MusicList_MouseClick(object sender, MouseEventArgs e)
        {
            main = true;
        }
        private void MusicList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the name of the file to open from the ListBox
            string file = MusicList.SelectedItem.ToString();
            
            if (!file.Contains(">"))
            {/*
                //load and play song, but stay on collection
                started = false;
                play = false;
                playButton_Click("mouse double click", null);
                return;*/
                SongTitle.Text = "Single Track";
            } else
            {
                file = file.Substring(1);
                SongTitle.Text = file;
            }
            PageTitle.Text = "Music Player";
            //find music object and load into player
            MusicList.Visible = false;
            Player.Visible = true;
            addPlaylist.Visible = false;
            //List<Component> all = null;
            NextSongs.Items.Clear();
            //load playlist
            Component t = new Playlist();
            t.setName(">Main Directory");
            foreach (Component c in database) t.add(c);
            //currPlaylist = t;
            //currPlaylist = currPlaylist.find(file, MusicList.SelectedIndex, getOffset(MusicList));
            t = t.find(file, MusicList.SelectedIndex, getOffset(MusicList));
            List<string> formatted = new List<string>();
            formatted = t.makeList(-1, false);
            if (formatted.Count == 0 && t.getPath() != null) NextSongs.Items.Add(file);
            foreach (string n in formatted)
                NextSongs.Items.Add(n);
            
            int i = 0;
            for (; i < NextSongs.Items.Count; i++) if (!NextSongs.Items[i].ToString().Contains(">")) break;
            if (NextSongs.Items.Count == 0)
            {
                //disallow selection
                NextSongs.SelectionMode = SelectionMode.None;
            }
            else
            {
                NextSongs.SelectionMode = SelectionMode.One;
                if (currPlaylist.getName() == SongTitle.Text.ToString())
                {
                    //set to current song
                    NextSongs.SelectedIndex = currSelected;                      
                }
            }
        }
        private void audioPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //NEED TO FIX AUTO PLAY
            //if (audioPlayer.currentMedia != null) maxTime = audioPlayer.currentMedia.duration;
            timerUpdate();
            if (e.newState == 1 && play)
            {   /*
                started = false;
                play = false;
                playButton.Image = Properties.Resources.pause_button;
                //stopped
                //load next song
                currPlaylist.next();
                //nextButton_Click("state change", null);
                //playButton_Click("state change", null);*/
            }
        }
        private void NextSongs_MouseClick(object sender, EventArgs e)
        {
            if (NextSongs.SelectionMode == SelectionMode.None) return;
            if (NextSongs.SelectedItem.ToString().Trim().Substring(0, 1) == ">")
            {
                if (currPlaylist.getName() != SongTitle.Text.ToString())
                {
                    NextSongs.ClearSelected();
                    return;
                }
                //keep on selected item
                NextSongs.SelectedIndex = currSelected;
                return;
            } 
            //else find song and load
            currSelected = NextSongs.SelectedIndex;
            string file = NextSongs.SelectedItem.ToString().Trim();
            //send to component class, thats it's job!
            if (currPlaylist.getName() != SongTitle.Text.ToString() && SongTitle.Text.ToString() != "Single Track")
            {
                //default playlist from collection
                //load playlist
                Component t = new Playlist();
                t.setName(">Main Directory");
                foreach (Component c in database) t.add(c);
                currPlaylist = t.find(SongTitle.Text.ToString(), 0, 0);
                //if shuffle set up
                if (shuffle)
                {
                    shuffle = false;
                    ShuffleButton_Click("mouse click", null);
                }
                currItem = currPlaylist.find(file, NextSongs.SelectedIndex, getOffset(NextSongs));
            }
            else
            {
                Component t = new Playlist();
                t.setName(">Main Directory");
                foreach (Component c in database) t.add(c);
                currPlaylist = t.find(NextSongs.SelectedItem.ToString(), MusicList.SelectedIndex, getOffset(MusicList));
                currItem = currPlaylist;
            }
            started = false;
            play = false;
            playButton_Click("next songs", null);
        }
        private void MusicList_KeyDown(object sender, KeyEventArgs e)
        {
            if (!MusicList.Visible) return;
            if (e.KeyCode == Keys.Enter) MusicList_MouseDoubleClick(sender, null);
        }
        private void NextSongs_KeyDown(object sender, KeyEventArgs e)
        {
            if (!NextSongs.Visible) MusicList_KeyDown(sender, e);
            //if (e.KeyCode == Keys.Enter) NextSongs_MouseClick(sender, null); //eventually handle
            e.Handled = true;
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            if (MusicList.Visible && main)  //if on music list, still select and play song
            { 
                string file = null;
                //grab item at index
                object f = MusicList.SelectedItem;
                if (f != null) file = f.ToString().Trim();
                if (file.Substring(0, 1) == ">") return;
                //set currPlaylist to database
                Component curr = new Playlist();
                foreach (Component c in database) curr.add(c);
                currPlaylist = curr;
                currItem = currPlaylist.find(MusicList.SelectedItem.ToString(), MusicList.SelectedIndex, 0);
                main = true;
            } else
            {
                main = false;
            }
            if (currItem == null) return;
            if (currItem.getName() == null) return;
            if (!play)
            {
                play = true;
                playButton.Image = Properties.Resources.pause_button;
                //get correct name
                currItemInfo.Text = currItem.getSongName();
                //start list to play
                if (!started)
                {
                    started = true;
                    audioPlayer.URL = @currItem.getPath();
                }
                audioPlayer.Ctlcontrols.play();
            }
            else
            {
                play = false;
                playButton.Image = Properties.Resources.play_button;
                audioPlayer.Ctlcontrols.pause();
                //pause music
            }

        }
        private int getOffset(ListBox lb)
        {
            int offset = 0;
            for (int i = 0; i < lb.SelectedIndex; i++)
                if (lb.Items[i].ToString().Trim().Substring(0, 1) == ">") offset++;
            return offset;
        }
        private void back_Click(object sender, EventArgs e)
        {
            //return to collection
            PageTitle.Text = "Collection";
            MusicList.Visible = true;
            Player.Visible = false;
            addBox.Visible = false;
            addPlaylist.Visible = true;
            playListName.Visible = false;
            edit = false;
            delete = false;
            deleteButton.Image = Properties.Resources.minus_button;
            editButton.Image = Properties.Resources.add_button;
            started = false;
            currSelected = NextSongs.SelectedIndex;

        }
        private void playTimer_Tick(object sender, EventArgs e)
        {
            if (play && buffering) timerUpdate();
        }
        private void timerUpdate()
        {
            string first = "00:00";
            string second = "00:00";
            if (audioPlayer.currentMedia != null)
            {
                second = audioPlayer.currentMedia.durationString;
                first = audioPlayer.Ctlcontrols.currentPositionString;
            }
            timer.Text = first + "/" + second;
        }
        private void previousButton_Click(object sender, EventArgs e)
        {
            if (reverse && sender.ToString() != "next") //if reverse
            {
                nextButton_Click("reverse", null);
                return;
            }
            //load previous
            //if (currPlaylist == null) return;
            //load next
            if (currPlaylist == null) return;
            if (!main) previous(NextSongs);
            else previous(MusicList);
            started = false;
            play = false;
            playButton_Click("previous button", null);
        }
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (reverse && sender.ToString() != "reverse")
            {
                previousButton_Click("next", null);
                return;
            }
            //load next
            if (currPlaylist == null) return;
            if (!main)  {
                next(NextSongs);
                currSelected = NextSongs.SelectedIndex;
                //set correct next or previous
            } else { next(MusicList); }
            started = false;
            play = false;
            playButton_Click("next button", null);
        }
        private void previous(ListBox lb)
        {
            if (lb.Items.Count == 0) return;
            if (shuffle)
            {
                if (shuffleIndex == 0)
                {
                    //make new shuffle list
                    if (repeat)
                    {
                        shuffle = false;
                        ShuffleButton_Click("next", null);
                    }
                    else { return; } //don't repeat, exit
                }
                lb.SelectedIndex = shuffleList[shuffleIndex--];
            }
            else if (lb.SelectedIndex == getOffset(lb))
            {
                //max number in list
                if (repeat) lb.SelectedIndex = lb.Items.Count - 1;
                else return;
                //other things?
            }
            else
            {
                lb.SelectedIndex--;
            }
            while (lb.SelectedItem.ToString().Trim().Substring(0, 1) == ">")
                lb.SelectedIndex--;
            currItem = currPlaylist.find(lb.SelectedItem.ToString(), lb.SelectedIndex, getOffset(lb));
        }
        private void next(ListBox lb)
        {
            if (lb.Items.Count <= 1) return;
            if (shuffle)
            {
                if (shuffleIndex == shuffleList.Count - 1)
                {
                    //make new shuffle list
                    if (repeat)
                    {
                        shuffle = false;
                        ShuffleButton_Click("next", null);
                    } else { return; } //don't repeat, exit
                }
                lb.SelectedIndex = shuffleList[shuffleIndex++];
            }
            else if (lb.SelectedIndex + 1 == lb.Items.Count)
            {
                //max number in list
                if (repeat) lb.SelectedIndex = 0;
                else return;
                //other things?
            }
            else
            {
                lb.SelectedIndex++;
            }
            while (lb.SelectedItem.ToString().Trim().Substring(0, 1) == ">")
                lb.SelectedIndex++;
            currItem = currPlaylist.find(lb.SelectedItem.ToString(), lb.SelectedIndex, getOffset(lb));
        }
        private void reverseButton_Click(object sender, EventArgs e)
        {
            //set reverse play
            if (reverse) //if on
            {
                reverse = false;
                reverseButton.Image = Properties.Resources.reverse_button;
            }
            else //if off
            {
                reverse = true;
                reverseButton.Image = Properties.Resources.reverse_button_active;
            }
        }
        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            //setup shuffle settings
            if (shuffle) //if on turn off
            {
                shuffle = false;
                shuffleButton.Image = Properties.Resources.shuffle_button;
                shuffleList = new List<int>();
                shuffleIndex = 0;
            }
            else //if off turn on
            {
                shuffleIndex = 0;
                shuffle = true;
                shuffleButton.Image = Properties.Resources.shuffle_button_active;
                if (!main || NextSongs.Visible)
                {
                    //only add song indexes
                    for (int i = 0; i < NextSongs.Items.Count; ++i)
                        if (!NextSongs.Items[i].ToString().Contains(">")) shuffleList.Add(i);
                    shuffleList = Shuffle(shuffleList);
                    if (!play)
                    {
                        NextSongs.SelectedIndex = shuffleList[0];
                    }
                } else
                {
                    for (int i = 0; i < MusicList.Items.Count - 1; ++i)
                        if (!MusicList.Items[i].ToString().Contains(">")) shuffleList.Add(i);
                    shuffleList = Shuffle(shuffleList);
                    MusicList.SelectedIndex = shuffleList[0];
                }
            }
        }

        //using code from https://www.codegrepper.com/code-examples/csharp/c%23+randomize+a+list
        private List<int> Shuffle(List<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
        private void repeatButton_Click(object sender, EventArgs e)
        {
            //set repeat
            if (repeat) //if on
            {
                repeat = false;
                repeatButton.Image = Properties.Resources.repeat_button;
            }
            else //if off
            {
                repeat = true;
                repeatButton.Image = Properties.Resources.repeat_button_active;
            }
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (delete || SongTitle.Text.ToString() == "Single Track") return;
            if (!edit)
            {
                edit = true;
                addBox.Visible = true;
                editButton.Image = Properties.Resources.add_button_active;
                addBox.Items.Clear();
                //get current play list we are in
                //search valid options to add to current playlist
                //CANNOT add any playlist that contains itself at any level!
                //add all items in playlist
                List<Component> all = new List<Component>();
                Component t = new Playlist();
                foreach (Component c in database) t.add(c);
                t = t.find(SongTitle.Text.ToString(), 0, 0);
                editItem = t;

                foreach (Component c in database)
                    if (c.getName() != t.getName() && !c.makeList(-1, true).Contains(t.getName()))
                        addBox.Items.Add(c.getName());

                if (addBox.Items.Count > 0) {
                    addBox.Select();
                    addBox.SelectedIndex = 0;
                }
            } else
            {
                edit = false;
                addBox.Visible = false;
                editButton.Image = Properties.Resources.add_button;
            }   
        }
        private void addBox_MouseClick(object sender, MouseEventArgs e)
        {
            string file = addBox.SelectedItem.ToString().Trim();
            //add to the current playlist
            //find object
            Component t = new Component();
            foreach(Component c in database)
                if (c.getName() == file)
                {
                    t = c;
                    break;
                }

            DialogResult dialogResult = MessageBox.Show("Add "+ file + " to " + editItem.getName() + " playlist?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                editItem.add(t);
                //add into database
                if (t.getIndex() >= 0) //playlist
                {
                    NextSongs.Items.Add(">" + file);
                    MusicList_MouseDoubleClick(null, null);
                } else
                {
                    NextSongs.Items.Add(file);
                }
            }
        }
        private void addBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!addBox.Visible) return;
            if (e.KeyCode == Keys.Enter) addBox_MouseClick(null, null);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            File.Create(data).Close();
            //save current database back into file
            System.IO.StreamWriter writer = new System.IO.StreamWriter(data); //open the file for writing.

            List<Component> all = new List<Component>();
            foreach (Component c in database)
                if (c.getPath() == null) all.Add(c);

            List<Component> f = new List<Component>();
            foreach(Component c in all)
            {
                writer.WriteLine("+" + c.getName());
                f = c.traverseSelf();
                foreach(Component co in f)
                {
                    if (co.getPath() == null)
                    {
                        writer.WriteLine(">" + co.getName());
                    } else
                    {
                        writer.WriteLine(co.getName());
                    }     
                }
                writer.WriteLine("~");
            }

            writer.Close(); //remember to close the file again.
            writer.Dispose();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (edit || SongTitle.Text.ToString() == "Single Track") return;
            if (!delete)
            {
                delete = true;
                deleteBox.Visible = true;
                deleteButton.Image = Properties.Resources.minus_button_active;
                deleteBox.Items.Clear();
                //add all items in playlist
                List<Component> all = new List<Component>();
                Component t = new Playlist();
                foreach (Component c in database) t.add(c);
                t = t.find(SongTitle.Text.ToString(), 0, 0);
                all = t.traverseSelf();
                foreach(Component c in all)
                    deleteBox.Items.Add(c.getName());
                editItem = t;
            }
            else
            {
                delete = false;
                deleteBox.Visible = false;
                deleteButton.Image = Properties.Resources.minus_button;
            }
        }
        private void deleteBox_MouseClick(object sender, MouseEventArgs e)
        {
            string file = deleteBox.SelectedItem.ToString().Trim();
            DialogResult dialogResult = MessageBox.Show("Remove " + file + " from " + editItem.getName() + " playlist?", "Confirm", MessageBoxButtons.YesNo);

            Component t = editItem.find(file, deleteBox.SelectedIndex, getOffset(deleteBox));

            if (dialogResult == DialogResult.Yes)
            {
                int i = 0;
                for (; i < NextSongs.Items.Count; ++i) //find and delete at current index
                    if (NextSongs.Items[i].ToString() == ">" + t.getName() || NextSongs.Items[i].ToString() == t.getName()) break;

                if (t.getPath() == null) //playlist
                {
                    //NextSongs.Items.Add(">" + file);
                    List<string> co = t.makeList(0, false);
                    for (int j = 0; j < co.Count; ++j)
                        NextSongs.Items.RemoveAt(i);
                }
                else //remove singular
                {
                    NextSongs.Items.RemoveAt(i);
                }
                //go through database and find the current editItem
                int k = 0;
                for (; k < database.Count; ++k)
                    if (editItem == database[k]) break;
                //go though kth index and remove
                //List<string> kth = database[k].makeList(0, false);
                database[k].remove(t);
                deleteBox.Visible = false;
                deleteButton.Image = Properties.Resources.minus_button;
                delete = false;
            }
            MusicList_MouseDoubleClick(null, null);
        }
        private void deleteBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!deleteBox.Visible) return;
            if (e.KeyCode == Keys.Enter) deleteBox_MouseClick(null, null);
        }

        private void addPlaylist_Click(object sender, EventArgs e)
        {
            playListName.Visible = true;

        }
    }
}
