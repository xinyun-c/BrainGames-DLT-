using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerDichoticListening : MonoBehaviour
{
    public AudioSource IntroAudio;
    public OVRCameraRig Player;
    public GameObject difficultyManager;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAudio(IntroAudio));
        //supposedly wait for player to set difficulty here
        game.SetActive(true);

    }
    IEnumerator PlayAudio(AudioSource audioSource)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length); // wait time
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
