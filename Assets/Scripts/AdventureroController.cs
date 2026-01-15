using UnityEngine;

public class AdventureroController : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;

    void Start()
    {
        InvokeRepeating("InstantiateArrow", 2, 3);
        

    }

    private void InstantiateArrow() 
    {
        Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
    


    }
}
