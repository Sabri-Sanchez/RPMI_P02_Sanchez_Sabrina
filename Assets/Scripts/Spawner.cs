using JetBrains.Annotations;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    public GameObject adventurer;
    public Transform SpawnPoint;

 
    private void OnMouseDown()
    {
        
        print("spawn");
        Instantiate(adventurer, SpawnPoint.position, SpawnPoint.rotation);

      


    }

    


}
