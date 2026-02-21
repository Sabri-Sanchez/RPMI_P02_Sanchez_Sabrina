using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Avanzar : MonoBehaviour
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

    void Start()
    {
        GameOverText.enabled = false;

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if (move == true)
        {
            bool enemyInFront = Physics.Raycast(SpawnPoint.position, transform.forward, float.MaxValue, LayerMask.GetMask("Player"));


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
                move = false;

                animator.SetBool("Golpear", true); //para que Mage golpeé cuando tenga al TiraFlecha adelante
            }
            else
            {
                move = true;
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

            if (vida > 21)
            {


                vida = vida - 20;
                print("Vida: " + vida);

                animator.SetBool("RecibeFlecha", true);

            }
            else
            {
                print("Murió");
                animator.SetBool("Dead", true);//Animación de la bruja muriendo
                move = false;

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

    //public void RecibeFlechaEnded();
    //{
    //  move = false;
    //}

    public void Camina()
    {
        animator.SetBool("Camina", true);
    }
}
