using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.CellData
{
    public class ResourceState : MonoBehaviour
    {
        public ResourceBase[] resourcesData;
    
        public Dictionary<ResourceBase, int> GetResoursesState()
        {
            return resourcesData.ToDictionary(x => x, r => r.BaseCount);
        }
    }
}
