using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesM : MonoBehaviour
{
    public static ScenesM instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    public void DiGame()
    {
        SceneManager.LoadScene("DiGame");
    }
    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void RandomStock()
    {
        SceneManager.LoadScene("RandomMine");
    }
    public void Doback()
    {
        SceneManager.LoadScene("DoBock");
    }

}
