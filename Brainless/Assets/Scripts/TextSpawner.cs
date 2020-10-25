using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpawner : MonoBehaviour
{
    public Color startColor;
    public Color color;
    public Text moreDamage;
    public bool fadeText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fadeText)
        {
            color = moreDamage.color;
            color.a -= 0.5f * Time.fixedDeltaTime;
            moreDamage.color = color;
            if (moreDamage.color.a < 0)
            {
                moreDamage.color = startColor;
                color = startColor;
                fadeText = false;
                moreDamage.enabled = false;
            }
        }
    }
    public void SpawnText()
    {
        moreDamage.enabled = true;
        StartCoroutine(StartFading());
    }

    IEnumerator StartFading()
    {
        yield return new WaitForSeconds(2f);
        fadeText = true;
    }
}
