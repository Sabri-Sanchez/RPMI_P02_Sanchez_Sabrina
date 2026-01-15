using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinController : MonoBehaviour
{
    
    public Inventory inventory;
    public GameObject moneda;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();//En "Find" se debería buscar el nombre que tenga por jerarquía - En "GetComponent" se pone el tipo que es el inventario, va parentesis aunque no tenga nada adentro
    }

    private void OnMouseDown()
    {
        //inventory.coins++; es solo para sumar de a uno
        //inventory.coins+= 1;
        
        inventory.coin = inventory.coin + 1;



        //scoreText.text = inventory.coin.ToString();
        scoreText.SetText(inventory.coin.ToString());
        //scoreText.enabled = true;


        print(inventory.coin);
        moneda.SetActive(false);
    }


}

