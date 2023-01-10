using Assets.Scripts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CellData
{
    [CreateAssetMenu(fileName = "NewResource", menuName = "Data/Resource")]
    public class ResourceBase : ScriptableObject
    {
        public int BaseCount;
        public Rarity rarity;
    }
}
