using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePoint : MonoBehaviour
{

    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            print("holaT");
            if (Input.GetKeyDown(KeyCode.E))
            {
                end.SetActive(true);
                Invoke("NextLevel", 4f);
            }
        }
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
