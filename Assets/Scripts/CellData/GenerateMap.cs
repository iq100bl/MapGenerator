using Common;
using UnityEngine;

namespace Assets.Scripts.CellData
{
    public class GenerateMap : MonoBehaviour
    {
        public GameObject[] prefabsCells;
        public int size;
        private int ChaingePercents = 1;
        // Start is called before the first frame update
        void Start()
        {
            var mapWorld = new Cell[size, size];
            for (var line = 0; line < size; line++)
            {
                for (var column = 0; column < size; column++)
                {
                    if ((line - 1) < 0)
                    {
                        if ((column - 1) < 0)
                        {
                            mapWorld[line, column] = new Cell(new Chance(), new Territory(column, line, prefabsCells[Random.Range(0, prefabsCells.Length)]));
                            Instantiate(mapWorld[line, column].Territory.territory, new Vector3(column, line), transform.rotation, transform);
                        }
                        else
                        {
                            mapWorld[line, column] = ChoiseTerritory(mapWorld[line, column - 1], column, line);
                            Instantiate(mapWorld[line, column].Territory.territory, new Vector3(column, line), transform.rotation, transform);
                        }
                    }
                    else
                    {
                        if ((column - 1) < 0)
                        {
                            mapWorld[line, column] = ChoiseTerritory(mapWorld[line - 1, column], column, line);
                            Instantiate(mapWorld[line, column].Territory.territory, new Vector3(column, line), transform.rotation, transform);
                        }
                        else
                        {
                            mapWorld[line, column] = ChoiseTerritory(mapWorld[line - 1, column], mapWorld[line, column - 1], column, line);
                            Instantiate(mapWorld[line, column].Territory.territory, new Vector3(column, line), transform.rotation, transform);
                        }
                    }
                }
            }
        }

        private Cell ChoiseTerritory(Cell neighboringCell, int xCell, int yCell)
        {
            Cell generatedCell;
            if (Random.Range(0, 100) > neighboringCell.Chance.chanceGeneration)
            {
                GameObject currentTerritory;
                do
                {
                    currentTerritory = prefabsCells[Random.Range(0, prefabsCells.Length)];
                }
                while (currentTerritory == neighboringCell.Territory.territory);
                generatedCell = new Cell(new Chance(), new Territory(xCell, yCell, currentTerritory));
            }
            else
            {
                neighboringCell.Chance.chanceGeneration -= ChaingePercents;
                generatedCell = new Cell(neighboringCell.Chance, new Territory(xCell, yCell, neighboringCell.Territory.territory));
            }

            return generatedCell;
        }

        private Cell ChoiseTerritory(Cell cellAbove, Cell cellToLeft, int xCell, int yCell)
        {
            Cell generatedCell;
            if (cellAbove.Territory == cellToLeft.Territory)
            {
                generatedCell = ChoiseTerritory(cellAbove, xCell, yCell);
            }
            else
            {
                GameObject currentTerritory;
                if (Random.Range(0, 100) > cellAbove.Chance.chanceGeneration + cellToLeft.Chance.chanceGeneration)
                {
                    do
                    {
                        currentTerritory = prefabsCells[Random.Range(0, prefabsCells.Length)];
                    }
                    while (currentTerritory == cellAbove.Territory.territory && currentTerritory == cellToLeft.Territory.territory);

                    generatedCell = new Cell(new Chance(), new Territory(xCell, yCell, currentTerritory));
                }
                else if (Random.Range(0, cellAbove.Chance.chanceGeneration + cellToLeft.Chance.chanceGeneration) > cellAbove.Chance.chanceGeneration)
                {
                    generatedCell = ChoiseTerritory(cellToLeft, xCell, yCell);
                }
                else
                {
                    generatedCell = ChoiseTerritory(cellAbove, xCell, yCell);
                }
            }

            return generatedCell;
        }
    }
}