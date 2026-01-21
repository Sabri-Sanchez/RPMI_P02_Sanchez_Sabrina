using UnityEngine;
using TMPro;

public class KeyController : MonoBehaviour
{
    public Inventory inventory;
    public GameObject llave;
    public GameObject Skeleton;
    public Transform spawnSkeleton;

    public TextMeshProUGUI scoreKeyText;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        scoreKeyText = GameObject.Find("ScoreKeyText").GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        //inventory.key = inventory.key + 1;
        //scoreKeyText.SetText(inventory.key.ToString()); estaba llamando otra vez a la llave y no debería, se comenta para que no de error
       
        print(inventory.key);
        llave.SetActive(false);

        inventory.AddKey(1);
        Instantiate(Skeleton, spawnSkeleton.position, spawnSkeleton.rotation);
    }
}
