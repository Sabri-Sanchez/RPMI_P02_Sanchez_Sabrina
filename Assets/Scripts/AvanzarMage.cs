using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class AvanzarMage : MonoBehaviour
{
    bool move = true;
    int vida = 100;
    float muertetiempo = 1f;


    public GameObject moneda;

    public TextMeshProUGUI GameOverText;

    public Transform SpawnPoint;

    public Inventory inventory;

    public Animator animator;

    public AdventureroController enemigo;

    public float distancia;
    bool enemyInFront = false;

    //float rayDistance = 20f;


    void Start()
    {
        GameOverText.enabled = false;

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        distancia = GetComponent<BoxCollider>().size.z;
    }

    void Update()
    {
        if (move == true)
        {
            RaycastHit hitInfo; //Es para saber si chocó con algo para saberlo antes del if

            if (Physics.Raycast(SpawnPoint.position, transform.forward, out hitInfo, distancia, LayerMask.GetMask("Heroes")))
            {
                if (hitInfo.collider != null) 
                {
                    enemyInFront = true;

                    enemigo = hitInfo.collider.GetComponent<AdventureroController>();
                }
                    
                   
            }


            transform.Translate(0, 0, -0.011f, Space.World); //La Bruja avanza continuamente

            if (CompareTag("Player2")) //El esqueleto
            {
                transform.Translate(0, 0, -0.002f, Space.World);
            }

            if (CompareTag("Player1")) //Otro personaje
            {
                transform.Translate(0, 0, -0.001f, Space.World);
            }


            if (enemyInFront)
            {
                print("tengo que frenar");
                move = false;

                animator.SetBool("Golpear", true); //para que Mage golpeé cuando tenga al TiraFlecha adelante
            }
            else
            {
                move = true;
            }


        }


    }

    private void OnDrawGizmos() //Para que vea en el inspector lo que se esta haciendo en el elemento seleccionado
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(SpawnPoint.position, distancia * transform.forward);
    }


    private void OnCollisionEnter(Collision collision) //Cuando entra en el trigger collision
    {


        if (collision.gameObject.CompareTag("Collectable")) //Bruja deja de avanzar cuando choca
        {
            move = false;

            GameOverText.enabled = true;

        }

        if (collision.gameObject.CompareTag("Flecha")) //Flechas restan vida y destruyen bruja
        {

            if (vida > 21)
            {


                vida = vida - 20;
                print("Vida: " + vida);

                animator.SetBool("RecibeFlecha", true);
                

            }
            else
            {
                print("Murió");
                move = false;

                animator.SetBool("Dead", true);//Animación de la bruja muriendo
                
                Instantiate(moneda, SpawnPoint.position, Quaternion.identity);

                Invoke(nameof(destroy), muertetiempo);

            }

        }



    }

    public void destroy()
    {
        //Invoke("destroy", 2f); //Tiempo que tarda en morir
        Destroy(gameObject); //Destruye a Mage


    }

    public void SpawnAnimationEnded()
    {
        move = false;
    }

    public void RecibeFlecha()
    {
        move = false;
    }

    public void RecibeFlechaEnded()
    {
      move = true;
    }

    public void Camina()
    {
        animator.SetBool("Camina", true);
    }
}









