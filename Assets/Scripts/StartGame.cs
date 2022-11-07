using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>
        {
            ClickEvent ();
        });
    }

    // Update is called once per frame
    void ClickEvent()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
