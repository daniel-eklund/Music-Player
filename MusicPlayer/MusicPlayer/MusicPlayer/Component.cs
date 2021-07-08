using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    //direction of play
    enum PlayDirection
    {
        Normal, //one playthrough
        Reverse, //reverse
        Random, //random, no repeats
        Continuous //loop playthrough
    }
    /// <summary>
    /// This class demonstrates the composite design pattern
    /// </summary>
    class Component
    {
        private Component _parent;
        private string _name;
        private string _path;
        public PlayDirection _play;
        //getters and setters
        public void setParent(Component parent) { _parent = parent; }
        public Component getParent() { return _parent; }
        public void setName(string name) { _name = name; }
        public string getName() { return _name; }
        public virtual string getSongName() { return _name; }
        public void setPath(string path) { _path = path; }
        public virtual string getPath() { return _path; }
        public void setPlay(string pd)
        {
            switch(pd)
            {
                case "Reverse":
                    _play = PlayDirection.Reverse;
                    break;
                case "Random":
                    _play = PlayDirection.Random;
                    break;
                case "Continuous":
                    _play = PlayDirection.Continuous;
                    break;
                default:
                    _play = PlayDirection.Normal;
                    break;
            }
        }
        public string getPlay()
        {
            string play = "Normal";
            switch(_play)
            {
                case PlayDirection.Reverse:
                    play = "Reverse";
                    break;
                case PlayDirection.Random:
                    play = "Random";
                    break;
                case PlayDirection.Continuous:
                    play = "Continuous";
                    break;
                default:
                    break;
            }
            return play;
        }
        public virtual void add(Component c) { }
        public virtual Component remove(Component c) { return null; }
        public virtual Component get() { return this; }
        public virtual Component next() { return null; }
        public virtual Component previous() { return this; }
        public virtual List<Component> traverseAll() { return null; }
        public virtual List<Component> traverseSelf() { return null; }
        public virtual void updateIndex(Component c) { }
        public virtual int getIndex() { return -1; }
        public virtual Component find(string n, int ind, int off) { return null; }
        public virtual List<string> makeList(int tabs, bool f) { return null; }
    }

    //Playlist within component tree
    class Playlist : Component {
        List<Component> children = new List<Component>();
        int curr_index = 0;
        public override void add(Component c)
        {
            children.Add(c);
            c.setParent(this);
        }

        public override List<string> makeList(int tabs, bool f)
        {
            List<string> names = new List<string>();
            string spaces = "";
            //create formatted lists
            if (tabs >= 0)
            {
                string nm = this.getName();
                if (!f) //if deformat flag turned off
                {
                    spaces = new String(' ', 7 * tabs);
                    nm = spaces + ">" + nm;
                }
                names.Add(nm);
            }
            foreach(Component c in children)
                names.AddRange(c.makeList(tabs+1, f));
            return names;
        }

        public override Component find(string n, int ind, int off)
        {
            n = n.Trim();
            //check after index for name
            Component t = new Component();
            List<Component> all = new List<Component>();
            all = this.traverseAll();
            all.AddRange(this.traverseSelf());
            for (int i = ind-off; i < all.Count(); ++i)
                if (all[i].getName() == n)
                {
                    //t = children[i];
                    t = all[i];
                    break;
                }
            if (t.getName() == null) return null;
            return t;
        }

        public override string getSongName()
        {
            return children[curr_index].getSongName();
        }

        public override Component get()
        {
            return children[curr_index].get();
        }

        public override Component next() //returns next component
        {
            //if (_play == PlayDirection.Reverse) return this.previous();
            //need next for all playlists
            List<Component> all = new List<Component>();
            all = this.traverseAll();
            return all[++curr_index];

            //if (curr_index != children.Count) return children[++curr_index];
        }

        public override Component previous()
        {
            //if (_play == PlayDirection.Reverse) return this.next();
            //need previous for all playlists
            if (curr_index != 0)
            {
                List<Component> all = new List<Component>();
                all = this.traverseAll();
                return all[--curr_index];
            }
            //if (curr_index != 0) return children[--curr_index];
            return null;
        }

        public override Component remove(Component c)
        {
            //find first occurence
            for(int i=0; i < children.Count; ++i)
                if (children[i].makeList(0, false).SequenceEqual(c.makeList(0, false)))
                {
                    children.RemoveAt(i);
                    break;
                }

            return this;
        }

        public override void updateIndex(Component c)
        { //updates index to correct value
            //find if exists
            string name = c.getName();
            int i = 0;
            List<Component> all = new List<Component>();
            all = this.traverseAll();
            foreach (Component co in all)
            {
                if (co.getName() == name)
                {
                    curr_index = i;
                    break;
                }
                ++i;
            }
        }

        public override List<Component> traverseAll()
        {
            List<Component> temp = new List<Component>();
            foreach (Component c in children)
                temp.AddRange(c.traverseAll());
            return temp;
        }

        public override List<Component> traverseSelf()
        {
            
            List<Component> temp = new List<Component>();
            foreach (Component c in children)
            {
                if (c.getPath() == null)
                {
                    Component tc = new Component();
                    tc = c;
                    tc.setName(tc.getName());
                    temp.Add(tc);
                } else
                {
                    temp.Add(c);
                }
                
            }

            return temp;
            //return children;
        }

        public override int getIndex() {
            return curr_index;
        }
    }

    //Single track within Component tree
    class Single : Component
    {
        public override List<string> makeList(int tabs, bool f)
        {
            List<string> s = new List<string>();
            if (tabs >= 0)
            {
                string nm = this.getName();
                if (!f) //if formatting flag
                {
                    string spaces = new String(' ', 7 * tabs);
                    nm = spaces + nm;
                }
                s.Add(nm);
            }
            return s;
        }

        public override List<Component> traverseAll()
        {
            List<Component> temp = new List<Component>();
            temp.Add(this);
            return temp;
        }

        public override Component next()
        {
            if (_play == PlayDirection.Continuous) return this;
            return null;
        }

        public override Component previous()
        {
            if (this.getParent() == null)
            {
                //single
                return this;
            }
            return this.getParent().previous();
        }

        public override Component find(string n, int ind, int off)
        {
            return this;
        }
    }

}
