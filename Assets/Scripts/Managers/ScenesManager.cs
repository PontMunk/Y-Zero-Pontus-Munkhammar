using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
    public static OldMovement oldmovement;
    public CanvasAttribute canvasPause;

    private bool isPaused = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;  //Default on awake
    }

    private void Start()
    {
        
    }

    public enum Scene
    {
        CourtOne,
        CourtTwo,
        CourtThree
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.CourtOne.ToString());
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void LoadPause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        //Enable CanvasPause
        //gameObject.GetComponent<CanvasAttribute>().enabled = true;
        //https://www.youtube.com/watch?v=Z3tO8FPCM_w
    }

    public void UnPause()
    {
        
    }

}
