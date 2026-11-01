using System.Collections.Generic;
using UnityEngine;

//save to json
[System.Serializable]

public class SaveData
{
    public Vector3 playerPosition;
    //boundary name for map
    public string mapBoundary;
    public List<InventorySaveData> inventorySaveData;
}
