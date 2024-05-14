using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleScreenEffects : MonoBehaviour
{
    public Image backgroundImage;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI startGameText;

    private Color originalColor; // Variable to store the original color of the background image

    private void Start()
    {
        // Store the original color of the image and set it to black
        originalColor = backgroundImage.color;
        backgroundImage.color = Color.black; // Set the initial color to black

        // Set the title and start game text to be fully transparent
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0);
        startGameText.color = new Color(startGameText.color.r, startGameText.color.g, startGameText.color.b, 0);

        // Start the sequence of animations
        StartCoroutine(AnimateTitleScreen());
    }

    private IEnumerator AnimateTitleScreen()
    {
        // Wait for 1 second before starting the fade in
        yield return new WaitForSeconds(1f);

        // Fade the background image from black to its original color over 5 seconds
        yield return StartCoroutine(FadeImageToOriginalColor(backgroundImage, originalColor, 5f));

        // After the background has faded to its original color, fade in the title text over 3 seconds
        yield return StartCoroutine(FadeTextIn(titleText, 3f));

        // Start cycling the title text color between light blue and light purple
        StartCoroutine(CycleTitleTextColor());

        // After the title text has faded in, fade in the "StartTheGame" text over 1 second
        yield return new WaitForSeconds(3f); // Wait for the title text animation to complete
        yield return StartCoroutine(FadeTextIn(startGameText, 1f));
    }

    private IEnumerator FadeImageToOriginalColor(Image image, Color targetColor, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            image.color = Color.Lerp(Color.black, targetColor, elapsedTime / duration);
            yield return null;
        }
    }

    private IEnumerator FadeTextIn(TextMeshProUGUI text, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, elapsedTime / duration);
            yield return null;
        }
    }

    private IEnumerator CycleTitleTextColor()
    {
        Color lightBlue = new Color(0.68f, 0.85f, 0.9f, 1); // Ensure alpha is 1 for full opacity
        Color lightPurple = new Color(0.93f, 0.51f, 0.93f, 1); // Ensure alpha is 1 for full opacity
        while (true) // Infinite loop to continuously cycle colors
        {
            // Fade from light blue to light purple over 10 seconds
            float elapsedTime = 0f;
            while (elapsedTime < 10f)
            {
                elapsedTime += Time.deltaTime;
                titleText.color = Color.Lerp(lightBlue, lightPurple, elapsedTime / 10f);
                yield return null;
            }

            // Swap colors for the next cycle
            (lightBlue, lightPurple) = (lightPurple, lightBlue);
        }
    }
}









