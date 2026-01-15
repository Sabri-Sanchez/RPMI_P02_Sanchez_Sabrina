using UnityEngine;
using UnityEngine.SceneManagement; //es la librería que incluimos para poder usar otros elementos

public class MenuController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Aventureros Esqueletos");
    }
}
