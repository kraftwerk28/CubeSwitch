using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitcher : MonoBehaviour {

	public void SwitchToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
