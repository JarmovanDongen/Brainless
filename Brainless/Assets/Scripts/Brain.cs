using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Brain : MonoBehaviour
{
    public float brainMaxHealth = 1000;
    public float brainCurHealth;
    public Image healthBar;
    public GameObject player;
    public AudioSource zombieHit;
    // Start is called before the first frame update
    void Start()
    {
        brainCurHealth = brainMaxHealth;
        zombieHit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject child = transform.Find("Brain UI").gameObject;
        child.transform.LookAt(player.transform);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            brainCurHealth -= 60 * Time.deltaTime;
            healthBar.fillAmount = brainCurHealth / brainMaxHealth;
            if (brainCurHealth <= 0)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (brainCurHealth >= brainMaxHealth)
        {
            brainCurHealth = brainMaxHealth;
        }
        else
            brainCurHealth += 10 * Time.deltaTime;

            healthBar.fillAmount = brainCurHealth / brainMaxHealth;
        //Debug.Log(brainCurHealth);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            zombieHit.Play();
        }
    }
}
