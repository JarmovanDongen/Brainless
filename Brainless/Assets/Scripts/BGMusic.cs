using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioSource COD115;
    public AudioSource Abracadavre;
    public AudioSource BeautyOfAnnihilation;

    public int TrackSelector = 0; 
    public int TrackHistory;
    // Start is called before the first frame update
    void Start()
    {
        if (TrackSelector == 0)
        {
            COD115.Play();
            TrackSelector += 1;
        }
        else if (TrackSelector == 1 )
        {
            Abracadavre.Play();
            TrackSelector += 1;
        }
        else if (TrackSelector == 2)
        {
            BeautyOfAnnihilation.Play();
            TrackSelector = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (COD115.isPlaying == false && Abracadavre.isPlaying == false && BeautyOfAnnihilation.isPlaying == false)
        {
            if (TrackSelector == 0)
            {
                COD115.Play();
                TrackSelector += 1;
            }
            else if (TrackSelector == 1)
            {
                Abracadavre.Play();
                TrackSelector += 1;
            }
            else if (TrackSelector == 2)
            {
                BeautyOfAnnihilation.Play();
                TrackSelector = 0;
            }
        }
    }
}
