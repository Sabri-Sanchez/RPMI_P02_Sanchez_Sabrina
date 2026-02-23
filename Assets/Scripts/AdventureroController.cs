using UnityEngine;

public class AdventureroController : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;
    public Animator animator;

    private bool movimiento;

    private bool shooting;

    public float distancia;

    void Start()
    {
        //InvokeRepeating("InstantiateArrow", 2, 3);
        shooting = false;
        movimiento = false;

        distancia = GetComponent<BoxCollider>().size.z; //Busca un componente del tipo que yo le diga, después lo que es el size para saber la distancia en la que quiero enviar el Raycast
    }

    private void Update()
    {
        if (shooting) //es igual a if shooting == true / !shooting es negativo
        {

            if (!Physics.Raycast(spawnPoint.position, transform.forward, float.MaxValue, LayerMask.GetMask("Enemigos")))
                //Que tenga en cuenta las capas donde está este nombre, la capa enemigos para añadir propiedades en el motor de física

            {   //si no tiene nada adelante en cierta posicion, dirección, distancia y capa, deja de disparar
                print("RaycastTiraFlecha para detener disparo");

                animator.SetBool("Disparo", false); //para que deje de disparar mientras la bruja está muerta y hasta que vuelta a instanciarse

                shooting = false;
                movimiento = false;

                CancelInvoke("InstantiateArrow");


            }

        }
    }

    private void OnDrawGizmos() //Para que vea en el inspector lo que se esta haciendo en el elemento seleccionado
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(spawnPoint.position, distancia * transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (shooting == false)  //Se asegura que el héroe no duplica el disparo, comprueba si es falsa para ponerla en true. Es para que no se haga dos veces
            {
                shooting = true;
                //movimiento = true;

                InvokeRepeating("InstantiateArrow", 2f, 3f);
                //InvokeRepeating("Disparo", 0f, 3f);

                animator.SetBool("Disparo", true);

            }
            else
            {
                movimiento = false;
                animator.SetBool("Disparo", false);
            }


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("salgo del boxcollider en el ontriggerexit");
            CancelInvoke("InstanciateArrow");
        }
    }


    private void InstantiateArrow() //Funcion para instanciar la flecha
    {
        if (shooting == true)
        {
          Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
        }
        
    }

    public void PoseEstatica() //Nombre del evento de la pose Idle
    {
        movimiento = false;
    }

    public void Disparo() //Nombre del evento de disparar
    {
        movimiento = true;
    }

}



