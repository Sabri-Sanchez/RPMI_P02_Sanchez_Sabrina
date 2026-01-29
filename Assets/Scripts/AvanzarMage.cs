using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Avanzar : MonoBehaviour
{
    bool move = true;
    int vida = 100;
    float muertetiempo = 2f;


    public GameObject moneda;

    public TextMeshProUGUI GameOverText;

    public Transform SpawnPoint;

    public Inventory inventory;

    public Animator animator;

    public AdventureroController enemigo;

    void Start()
    {
        GameOverText.enabled = false;

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if (move == true)
        {
            transform.Translate(0, 0, -0.005f, Space.World); //La Bruja avanza continuamente


            if (CompareTag("Player2")) //El esqueleto
            {
                transform.Translate(0, 0, -0.002f, Space.World);
            }

            if (CompareTag("Player1")) //Otro personaje
            {
                transform.Translate(0, 0, -0.001f, Space.World);
            }
        }

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

            if (vida > 20)
            {
                vida = vida - 40;
                print("Vida: " + vida);

            }
            else
            {
                print("Murió");
                Instantiate(moneda, SpawnPoint.position, Quaternion.identity);

                //animator.SetBool("Dead", true);
                move = false;
                //animator.SetTrigger("Die");

                //Invoke("destroy", 2f);
                Invoke(nameof(destroy), muertetiempo);


            }
        }
    }

    public void destroy()
    {
        Destroy(gameObject); //Destruye a Mage
        
    }

    public void SpawnAnimationEnded()
    {
        move = false;
    }




}









