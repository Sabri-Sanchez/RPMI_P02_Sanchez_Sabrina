using UnityEngine;

public class AdventureroController : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;
    public Animator animator;

    private bool EnemigoActivoTrigger;

    void Start()
    {
        //InvokeRepeating("InstantiateArrow", 2, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemigoActivoTrigger = true;
            //animator.SetTrigger("Shoot");

            InvokeRepeating("InstantiateArrow", 2f, 3f);
            InvokeRepeating("AnimacionDisparar", 0f, 3f);

        }

    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        EnemigoActivo = false;

    //        CancelInvoke("InstantiateArrow");
    //        CancelInvoke("AnimacionDisparar");
    //    }

    //}

    public void StopActions() 
    {
        CancelInvoke("InstantiateArrow");
        CancelInvoke("AnimacionDisparar");

        EnemigoActivoTrigger = false;
    }

    public void Shoot()
    {
        InstantiateArrow();
    }

    private void InstantiateArrow()
    {
        if (!EnemigoActivoTrigger) return;
        {
          Instantiate(arrow, spawnPoint.position, spawnPoint.rotation);
        }
        
    }

    private void AnimacionDisparar()
    {
        if (!EnemigoActivoTrigger) return;
        {
            animator.ResetTrigger("Shoot");
            animator.SetTrigger("Shoot");
        }
    }

}



