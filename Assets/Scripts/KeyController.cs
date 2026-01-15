using UnityEngine;
using TMPro;

public class KeyController : MonoBehaviour
{
    public Inventory inventory;
    public GameObject llave;

    public TextMeshProUGUI scoreKeyText;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        scoreKeyText = GameObject.Find("ScoreKeyText").GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseDown()
    {
        inventory.key = inventory.key + 1;
        scoreKeyText.SetText(inventory.key.ToString());
       
        print(inventory.key);
        llave.SetActive(false);
    }
}
