using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinController : MonoBehaviour
{
    
    public Inventory inventory;
    public GameObject moneda;
    public GameObject Mage;
    public Transform spawnMage;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();//En "Find" se debería buscar el nombre que tenga por jerarquía - En "GetComponent" se pone el tipo que es el inventario, va parentesis aunque no tenga nada adentro
    }

    public void OnMouseDown()
    {
        //inventory.coins++; es solo para sumar de a uno
        //inventory.coins+= 1;
        
        //inventory.coin = inventory.coin + 1;



        //scoreText.text = inventory.coin.ToString();
        scoreText.SetText(inventory.coin.ToString());
        //scoreText.enabled = true;


        print(inventory.coin);
        moneda.SetActive(false); // Genera mas basura pero en juegos pequeños está bien
        //Destroy(moneda); para que sufra menos la memoria

        inventory.AddCoins(1); //Es llamar para que siempre se pueda actualizar en la interfaz llamando a la función desde el inventario
        Instantiate(Mage, spawnMage.position, spawnMage.rotation);

    } // PROBLEMA: problema que no se actualiza las monedas hasta que no se vuelva a hacer click


}

