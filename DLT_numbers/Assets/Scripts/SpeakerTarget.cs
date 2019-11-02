using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerTarget : MonoBehaviour
{
    public int target;
    public int last_num;
    public GameObject numberAudio;
    private List<AudioSource> audioList;
    private bool responded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        audioList = numberAudio.GetComponent<NumberAudio>().audioList;
        for (int i = 1; i <= 25; i++)
        {
            responded = false;
            SelectRandomNumber();
            StartCoroutine(audioPlay(audioList[last_num]));

        }
    }

    IEnumerator audioPlay(AudioSource num_audio) {
        num_audio.Play();
        yield return new WaitForSeconds(num_audio.clip.length + 1); // wait audioclip length time plus one second
    }

    private void SelectRandomNumber() {
        float probTarget = Random.Range(0.0f, 1.0f);
        if (probTarget < 0.3)
        {
            last_num = target;
        }
        else {
            System.Random rnd = new System.Random();
            last_num = rnd.Next(1, 21);  // creates a number between 1 and 20
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
