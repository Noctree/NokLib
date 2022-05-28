using System;
using System.Collections.Generic;
using System.Linq;

namespace NokLib.ConsoleUtils.UI
{
    public class ConsoleListView<T>
    {
        private const string DefaultBullet = "-";
        private const string DefaultSelectedBullet = ">";
        private const string Space = " ";
        private List<T> items;
        private int index;
        private int startX, startY, endX, endY;

        public Func<T, string>? CustomToStringMethod { get; set; }
        public ConsoleColor BulletColor { get; set; } = Console.ForegroundColor;
        public ConsoleColor ItemColor { get; set; } = Console.ForegroundColor;
        public ConsoleColor SelectedBulletColor { get; set; }
        public ConsoleColor SelectedItemColor { get; set; }
        public string Bullet { get; set; } = DefaultBullet;
        public string SelectionBullet { get; set; } = DefaultSelectedBullet;
        public int Index => index;
        public T SelectedItem => items[index];
        public bool Shown { get; private set; }
        public ConsoleListView(IEnumerable<T> collection) {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            if (!collection.Any())
                throw new ArgumentException("Collection is empty");
            items = new List<T>(collection);
            index = 0;
        }

        public void SetItems(IEnumerable<T> items) {
            this.items.Clear();
            this.items = new List<T>(items);
        }

        public T GetItemAt(int index) => items[index];

        private void Render(string bullet = "-", ConsoleColor? _bulletColor = null, ConsoleColor? _itemColor = null) {
            ConsoleColor itemColor = _itemColor ?? Console.ForegroundColor;
            ConsoleColor bulletColor = _bulletColor ?? Console.ForegroundColor;
            int left = Console.CursorLeft;
            foreach (var item in items) {
                ConsoleWriter.Write(bullet, bulletColor);
                ConsoleWriter.Write(Space);
                ConsoleWriter.WriteLine(CustomToStringMethod is null ? item.SafeToString() : CustomToStringMethod(item), itemColor);
                Console.CursorLeft = left;
            }
        }

        public int Show() {
            Shown = true;
            Console.CursorVisible = false;
            index = 0;
            List<string> itemNames = items.Select(item => CustomToStringMethod is null ? item.SafeToString() : CustomToStringMethod(item)).ToList();
            CalculateBounds(Bullet, SelectionBullet, itemNames);
            RenderInSelectionMode(Bullet, SelectionBullet, SelectedBulletColor, SelectedItemColor, BulletColor, ItemColor, itemNames);
            bool run = true;
            while (run) {
                RenderInSelectionMode(Bullet, SelectionBullet, SelectedBulletColor, SelectedItemColor, BulletColor, ItemColor, itemNames);
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.Enter:
                        run = false;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        ++index;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        --index;
                        break;
                }
                if (index < 0)
                    index = 0;
                if (index >= itemNames.Count)
                    index = itemNames.Count - 1;
            }
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, endY);
            Shown = false;
            return index;
        }

        private void RenderInSelectionMode(string bullet, string selectedBullet, ConsoleColor selectedBulletColor, ConsoleColor selectedItemColor, ConsoleColor bulletColor, ConsoleColor itemColor, List<string> items) {
            ConsolePrinter.ClearArea(startX, startY, endX, endY);
            Console.SetCursorPosition(startX, startY);
            Render(bullet, bulletColor, itemColor);
            Console.SetCursorPosition(startX, startY + index);
            ConsoleWriter.Write(selectedBullet, selectedBulletColor);
            ConsoleWriter.Write(Space);
            ConsoleWriter.Write(items[index], selectedItemColor);
        }

        private void CalculateBounds(string bullet, string selectedBullet, List<string> items) {
            int bulletSize = Math.Max(bullet.Length, selectedBullet.Length);
            int maxItemLength = items.Max(item => item.Length);
            startX = Console.CursorLeft;
            startY = Console.CursorTop;
            endX = startX + bulletSize + maxItemLength + 1;
            endY = startY + items.Count;
        }
    }
}
