using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int Map = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Map == 1)
        {
            if (collision.CompareTag("Warrior"))
            {
                SceneController.instance.NextLevel();
            }
        }

        if (Map == 2)
        {
            SceneManager.LoadSceneAsync(0);
        }

    }
}
