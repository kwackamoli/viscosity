using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequence : MonoBehaviour
{
    [SerializeField] SpriteRenderer backgroundImage;
    [SerializeField] TextMeshProUGUI awesomeText;
    [SerializeField] Sprite[] introImages;
    [SerializeField] string[] introText;
    [SerializeField] string level0scene;
    [SerializeField] float fadeinTime;
    [SerializeField] float waitTime;
    [SerializeField] float fadeoutTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(displaySequence());
       
    }
    IEnumerator displaySequence()
    {
        for (int i = 0; i < introImages.Length; i++)
        {
            backgroundImage.color = new Color(1, 1, 1, 0);
            awesomeText.color = new Color(1, 1, 1, 0);
            backgroundImage.sprite = introImages[i];
            awesomeText.text = introText[i];

            while (backgroundImage.color.a < 1 || awesomeText.color.a < 1)
            {
                backgroundImage.color = new Color(1, 1, 1, Mathf.Clamp01 ( backgroundImage.color.a + (Time.deltaTime * fadeinTime)));
                if (backgroundImage.color.a > 0.5)
                {
                    awesomeText.color = new Color(1, 1, 1, awesomeText.color.a + (Time.deltaTime * fadeinTime));
                }
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            while (backgroundImage.color.a > 0 || awesomeText.color.a > 0)
            {
                backgroundImage.color = new Color(1, 1, 1, backgroundImage.color.a - (Time.deltaTime * fadeoutTime));
                awesomeText.color = new Color(1, 1, 1, awesomeText.color.a - (Time.deltaTime * fadeoutTime));
                yield return null;
            }
        }
        SceneManager.LoadScene(level0scene);
    }
}
