using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
  [SerializeField] GameObject sadPlayerImage;
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void EndGame()
    {
        StartCoroutine(WaitForDelay());
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitForDelay()
    {
        GameObject sadPlayer = Instantiate(sadPlayerImage, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        Destroy(sadPlayer);
        SceneManager.LoadScene("End");
    }
  
}
