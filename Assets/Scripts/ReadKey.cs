using UnityEngine;

public class ReadKey : MonoBehaviour
{
    // Esto debe ir a la jerarquia - Se puede limpiar en editor -> clear playerpref, es para que haya dos modos de juego. Depende del valor, para saber cuantos esqueletos han muerto o cuantos puntajes hay para mostrar al final de todo
    void Start()
    {
        PlayerPrefs.DeleteKey("tecla h"); 

        if (PlayerPrefs.GetInt("tecla h", -1) == 5)
        {
            print("El jugador pulsó H");        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)); //Quiero guardar que el jugador está haciendo esto
        {
            PlayerPrefs.SetInt("tecla h", 5); //Si pulso la H se guarda un número
            PlayerPrefs.Save(); //Es para que guarde el valor en un casillero
        }
    }
}
