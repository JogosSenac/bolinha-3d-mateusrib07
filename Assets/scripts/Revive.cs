using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revive : MonoBehaviour
{
  public void reviver()
  {
    SceneManager.LoadScene("fase1");
  }

  public void respawn()
  {
    SceneManager.LoadScene("fase2");
  }

  public void creditos()
  {
    SceneManager.LoadScene("creditos");
  }
}
