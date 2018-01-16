using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load : MonoBehaviour
{
    public void LoadIndex(int idx)
    {
        SceneManager.LoadScene(idx);
    }
	
}
