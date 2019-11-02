using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerTarget : MonoBehaviour
{
    public int target;
    public int last_num;
    public GameObject numberAudio;
    public int iter;
    public GameObject player;
    private List<AudioSource> audioList;
    private bool responded;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        audioList = numberAudio.GetComponent<NumberAudio>().audioList;
        StartCoroutine(audioPlay(iter));
    }

    IEnumerator audioPlay(int num) {
        for (int i = 1; i <= num; i++)
        {
            responded = false;
            SelectRandomNumber();
            audioList[last_num].Play();
            yield return new WaitForSeconds(audioList[last_num].clip.length + 1); // wait audioclip length time plus one second
        }
        
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
        OVRInput.Get(OVRInput.Button.One);
        Debug.Log("A button pressed.");
    }
}
