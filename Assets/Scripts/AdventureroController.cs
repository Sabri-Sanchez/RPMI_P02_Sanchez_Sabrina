using UnityEngine;

public class AdventureroController : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;

    void Start()
    {
        //InvokeRepeating("InstantiateArrow", 2, 3);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            //Comparar tags para saber si está vivo o muerto 
            InvokeRepeating("InstantiateArrow", 0.1f, 0.1f);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CancelInvoke("InstantiateArrow");
        }
       
    }

    private void InstantiateArrow() 
    {
        Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
    


    }
}
