using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingGood : MonoBehaviour
{
    [SerializeField]
    private float goopSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(MoveGood());
    }


    IEnumerator MoveGood()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            yield return null;
            transform.position = new Vector2(transform.position.x, transform.position.y + goopSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
