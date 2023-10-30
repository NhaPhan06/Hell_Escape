using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Warrior"))
        {
            SceneController.instance.NextLevel();
        }
    }
}
