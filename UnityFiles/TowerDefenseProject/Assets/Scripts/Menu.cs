using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Ian;

    public void OnButtonStart(){
        SceneManager.LoadScene( 1 );
    }

    public void OnButtonQuit(){
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif

        
    }
}
