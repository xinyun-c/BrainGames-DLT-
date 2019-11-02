using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerDichoticListening : MonoBehaviour
{
    public AudioSource IntroAudio;
    public OVRCameraRig Player;
    public GameObject speaker1;
    public GameObject speaker2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        IntroAudio.Play();
        yield return new WaitForSeconds(IntroAudio.clip.length); // wait time
        //supposedly wait for player to set difficulty here
        selectTarget();
        speaker1.SetActive(true);
        speaker2.SetActive(true);
    }

    private void selectDifficulty() {
    }

    private void selectTarget() {
        System.Random rnd = new System.Random();
        int target = rnd.Next(1, 21);  // creates a number between 1 and 20
        SpeakerTarget script1 = speaker1.GetComponent<SpeakerTarget>();
        script1.target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
