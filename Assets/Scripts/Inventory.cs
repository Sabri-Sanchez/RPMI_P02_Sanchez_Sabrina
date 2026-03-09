using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int coin = 15; //Luego hay que hacerla privada para que nadie pueda tocar la moneda
    public int key = 10;

    public TextMeshProUGUI coinText; // Esto es para actualizarlo desde el inventario
    public TextMeshProUGUI keyText;



    public void AddCoins(int coinsToAdd) //Es un parámetro para indicar la cantidad de monedas que quiero agregar, variable de intercambio para que comparta entre la función y el objeto que llame a la función que permita que se modifique, solo si no es un valor fijo
    {
        coin += coinsToAdd;
        coinText.text = coin.ToString(); //Para que todo el tiempo actualice el texto
    }

    public void AddKey(int keyToAdd) 
    {
        key += keyToAdd;
        keyText.text = key.ToString();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("AventurerosEsqueletos");
    }
}
