namespace Common
{
    internal class Cell : ICell
    {
        public Cell(Chance chance, Territory territory)
        {
            Chance = chance;
            Territory = territory;
        }

        public Chance Chance { get; set; }
        public Territory Territory { get; set; }
    }
}