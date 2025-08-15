using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jumpnext : MonoBehaviour
{
    public UnityEvent NextLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NextLevel?.Invoke();
            finishLevel();

        }
    }
    private void finishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
