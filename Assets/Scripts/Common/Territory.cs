using UnityEngine;

namespace Common
{
    public class Territory
    {

        public int xCoordinate;
        public int yCoordinate;
        public GameObject territory;

        public Territory(int xCoordinate, int yCoordinate, GameObject territory)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.territory = territory;
        }
    }
}