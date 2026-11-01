// using Unity.Cinemachine;
// using System.IO;
// using UnityEngine;

// public class SaveController : MonoBehaviour
// {
//     private string saveLocation;
//     private InventoryController inventoryController;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         //define save location
//         saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
//         inventoryController = Object.FindFirstObjectByType<InventoryController>();

//         LoadGame();
//     }

//     public void SaveGame(){
//         //calling saveData file
//         SaveData saveData = new SaveData {
//             playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
//             mapBoundary = FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name,
//             inventorySaveData = inventoryController.GetInventoryItems()
//         };

//         File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
//     }

//     public void LoadGame(){
//         if(File.Exists(saveLocation)){
//             SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

//             GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

//             FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find(saveData.mapBoundary).
//             GetComponent<PolygonCollider2D>();

//             inventoryController.SetInventoryItems(saveData.inventorySaveData);
//         } else {
//             //no save file yet in game
//             SaveGame();
//         }
//     }
// }
