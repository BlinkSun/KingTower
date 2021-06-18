using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KingTower
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitPlayerTower();
            InitEnemiesTower();
        }

        #region Drag&Drop
        private void Floor_DragEnter(object sender, DragEventArgs e)
        {
            Panel floor = (Panel)sender;
            // Set backcolor to Lime and cursor to Move
            floor.BackColor = Color.Lime;
            e.Effect = DragDropEffects.Move;
        }
        private void Floor_DragLeave(object sender, EventArgs e)
        {
            Panel floor = (Panel)sender;
            // Set the backcolor back to Blue
            floor.BackColor = Color.Blue;
        }
        private void Floor_DragDrop(object sender, DragEventArgs e)
        {
            Panel player = ((Panel)e.Data.GetData(typeof(Panel)));
            Panel afterFloor = (Panel)sender;
            Panel beforeFloor = (Panel)player.Parent;
            // assign new parent floor to player
            player.Parent = afterFloor;
            // set back the backcolor of floor
            afterFloor.BackColor = Color.Blue;
            // if no character on floor, dispose it
            if (afterFloor.Controls.Count > 0)
            {
                int levels = afterFloor.Controls.Find("Enemy", false).Select(en => int.Parse(en.Tag.ToString())).Sum();
                if (int.Parse(player.Tag.ToString()) > levels)
                {
                    foreach(Panel p in afterFloor.Controls.Find("Enemy", false))
                        p.Dispose();
                    player.Tag = int.Parse(player.Tag.ToString()) + levels;
                }
                else
                    player.Dispose();
            }
            if (beforeFloor.Controls.Count == 0)
                beforeFloor.Dispose();
        }
        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            Panel player = (Panel)sender;
            // do and show the drag and drop move
            player.DoDragDrop(player, DragDropEffects.Move);
        }
        #endregion

        #region InitMethods
        private void InitPlayerTower()
        {
            TowerPlayerUI.BackColor = Color.Black;
            for (int f = 0; f < 1; f++)
            {
                Panel floor = GetNewFloorPanel(f + 1);
                floor.Controls.Add(GetNewCharacterPanel(true, 3));
                TowerPlayerUI.Controls.Add(floor);
            }
        }
        private void InitEnemiesTower()
        {
            TowerEnemyUI.BackColor = Color.Black;
            List<Panel> floors = new List<Panel>();
            for (int f = 0; f < 20; f++)
            {
                Panel floor = GetNewFloorPanel(f + 1);
                for (int e = 0; e < 1; e++)
                {
                    int level;
                    if (floors.Count > 0)
                    {
                        int levels = floors[floors.Count - 1].Controls.Find("Enemy", false).Select(en => int.Parse(en.Tag.ToString())).Sum();
                        level = levels + ((f + 1) * (e + 1));
                    }
                    else
                        level = (f + 1) * (e + 1);
                    floor.Controls.Add(GetNewCharacterPanel(false, level));
                }
                floors.Add(floor);
            }
            floors.RandomizeList<Panel>(5, floors.Count - 5);
            TowerEnemyUI.Controls.AddRange(floors.ToArray<Panel>());
            if (TowerEnemyUI.VerticalScroll.Visible)
                TowerEnemyUI.ScrollControlIntoView(TowerEnemyUI.Controls[0]);
        }
        private Panel GetNewFloorPanel(int floorID)
        {
            Panel pnl = new Panel
            {
                AllowDrop = true,
                BorderStyle = BorderStyle.FixedSingle,
                Name = "Floor",
                Tag = floorID.ToString(),
                Padding = new Padding(5),
                Size = new Size(192, 62),
                BackColor = Color.Blue
            };
            pnl.Paint += new PaintEventHandler(Floor_DrawFloorID);
            pnl.DragDrop += new DragEventHandler(Floor_DragDrop);
            pnl.DragEnter += new DragEventHandler(Floor_DragEnter);
            pnl.DragLeave += new EventHandler(Floor_DragLeave);

            return pnl;
        }
        private Panel GetNewCharacterPanel(bool isPlayer, int level)
        {
            Panel pnl = new Panel
            {
                Name = isPlayer ? "Player" : "Enemy",
                Tag = level.ToString(),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = isPlayer ? DockStyle.Left : DockStyle.Right,
                Size = new Size(50, 50),
                BackColor = isPlayer ? Color.Yellow : Color.Red
            };
            if (isPlayer)
                pnl.MouseDown += new MouseEventHandler(Player_MouseDown);
            pnl.Paint += new PaintEventHandler(Character_DrawLevel);

            return pnl;
        }
        #endregion

        #region PaintEvents
        private void Floor_DrawFloorID(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.DrawString(pnl.Tag.ToString(),
                this.Font,
                new SolidBrush(Color.DarkBlue),
                new Point(0, 0));
        }
        private void Character_DrawLevel(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.DrawString(pnl.Tag.ToString(),
                this.Font,
                new SolidBrush(Color.Black),
                new Point(0, 0));
        }
        #endregion
    }

    public static class ExtendedMethods
    {
        public static void RandomizeList<T>(this List<T> list, int firstElement, int lastElement)
        {
            // Array with all elements to be randomized
            var randomized = new T[lastElement - firstElement];
            // Generate random indices
            // for randomized array
            var randomIds = new List<int>(UniqueRandom(firstElement, lastElement - 1)).ToArray();
            // Loop through all elements within the range
            // and fill list with items in a randomized order
            for (int i = firstElement; i != lastElement; i++)
                randomized[i - firstElement] = list[randomIds[i - firstElement]];
            // Loop again to merge random elements into the list
            for (int i = firstElement; i != lastElement; i++)
                list[i] = randomized[i - firstElement];
        }
        private static IEnumerable<int> UniqueRandom(int minInclusive, int maxInclusive)
        {
            List<int> candidates = new List<int>();
            for (int i = minInclusive; i <= maxInclusive; i++)
                candidates.Add(i);
            Random rnd = new Random();
            while (candidates.Count > 0)
            {
                int index = rnd.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }
    }
}
