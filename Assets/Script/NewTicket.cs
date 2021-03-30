using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewTicket : MonoBehaviour
{
    /*
     * Recreates the main gamescene.
     */
    public void LoadTicket()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
      
    
}
