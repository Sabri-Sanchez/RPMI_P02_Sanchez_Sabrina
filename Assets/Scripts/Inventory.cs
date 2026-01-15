using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coin; //Luego hay que hacerla privada para que nadie pueda tocar la moneda
    public int key;

    public TextMeshProUGUI coinText; // Esto es para actualizarlo desde el inventario
    public TextMeshProUGUI keyText;

    //private void Update() / PROBLEMA:  que en el Update se está actualizando en cada frame y utiliza mucho recurso
    //{
    //coinText.text = coin.ToString();
    //}


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
}
