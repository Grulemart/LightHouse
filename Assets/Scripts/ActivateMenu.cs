using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateMenu : MonoBehaviour
{
    private bool Loaded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Loaded == false)
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
                Loaded = true;
            }
            
        }
        
    }
    public void ActivateButton()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
