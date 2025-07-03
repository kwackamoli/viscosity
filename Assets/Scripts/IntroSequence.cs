using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroSequence : MonoBehaviour
{
    [SerializeField] SpriteRenderer backgroundImage;
    [SerializeField] TextMeshProUGUI awesomeText;
    [SerializeField] Sprite[] introImages;
    [SerializeField] string[] introText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(displaySequence());
       
    }
    IEnumerator displaySequence()
    {
        for (int i = 0; i < 3; i++)
        {
            backgroundImage.color = new Color(1, 1, 1, 0);
            awesomeText.color = new Color(1, 1, 1, 0);
            backgroundImage.sprite = introImages[i];
            awesomeText.text = introText[i];

            while (backgroundImage.color.a < 1 || awesomeText.color.a < 1)
            {
                backgroundImage.color = new Color(1, 1, 1, Mathf.Clamp01 ( backgroundImage.color.a + (Time.deltaTime * 0.25f)));
                if (backgroundImage.color.a > 0.5)
                {
                    awesomeText.color = new Color(1, 1, 1, awesomeText.color.a + (Time.deltaTime * 0.25f));
                }
                yield return null;
            }

            yield return new WaitForSeconds(2);

            while (backgroundImage.color.a > 0 || awesomeText.color.a > 0)
            {
                backgroundImage.color = new Color(1, 1, 1, backgroundImage.color.a - (Time.deltaTime * 0.2f));
                awesomeText.color = new Color(1, 1, 1, awesomeText.color.a - (Time.deltaTime * 0.2f));
                yield return null;
            }
        }
        yield return null;
    }
}
