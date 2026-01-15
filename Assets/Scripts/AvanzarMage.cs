using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Avanzar : MonoBehaviour
{
    bool move = true;
    int vida = 100;
    

    public GameObject moneda;

    public TextMeshProUGUI GameOverText;
    
    public Transform SpawnPoint;

    public Inventory inventory;

    void Start()
    {
        GameOverText.enabled = false;

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if  (move == true)
        {
            transform.Translate(0, 0, -0.005f, Space.World); //La Bruja avanza continuamente

            if (CompareTag("Player2"))
            {
                transform.Translate(0, 0, -0.002f, Space.World);
            }

            if (CompareTag("Player1"))
            {
                transform.Translate(0, 0, -0.001f, Space.World);
            }
        }

    }   


    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Collectable")) //Bruja deja de avanzar cuando choca
        {
            move = false;
            
            GameOverText.enabled = true;

        }

          if (collision.gameObject.CompareTag("Flecha")) //Flechas restan vida y destruyen bruja
          {

            if (vida > 20)
            {
                vida = vida - 40;
                print("Vida: " + vida);
       
            }
            else
            {
                print("Murió");
                Instantiate(moneda, SpawnPoint.position, Quaternion.identity);
                
                Destroy(gameObject); //Destruye a Mage
            }
          }
    }
         
}            
             





          
         

