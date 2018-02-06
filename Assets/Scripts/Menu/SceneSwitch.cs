using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SceneSwitch : MonoBehaviour
{
    public GameObject levelSelector;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Save()
    {
        //FileStream file = File.Open()
    }

    public void ShowLevelSel()
    {
        levelSelector.GetComponent<Animator>().SetTrigger("Show");
    }
    public void HideLevelSel()
    {
        levelSelector.GetComponent<Animator>().SetTrigger("Hide");
    }
}
