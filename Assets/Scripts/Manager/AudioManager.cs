using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip buttonSFX;
    [SerializeField] AudioClip removeCasesSFX;
    [SerializeField] AudioClip dealerCallSFX;

    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSFX()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(buttonSFX);
    }

    public void PlayRemoveCasesSFX()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(removeCasesSFX);
    }

    public void PlayDealerCallSFX()
    {
        audioSource.volume = 0.75f;
        audioSource.PlayOneShot(dealerCallSFX);
    }
}
