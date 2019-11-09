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
    public GameObject manager;
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
            if (responded == false) {
                if (target != last_num)
                {
                    manager.GetComponent<EventManagerDichoticListening>().correctNumber += 1;
                }
                else {
                    manager.GetComponent<EventManagerDichoticListening>().incorrectNumber += 1;
                }
            }
        }
        manager.GetComponent<EventManagerDichoticListening>().gameEnds = true;

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
        if (!responded) {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) >= 0.9)
            {
                Debug.Log("A button pressed.");
                if (target == last_num)
                {
                    manager.GetComponent<EventManagerDichoticListening>().correctNumber += 1;
                }
                else {
                    manager.GetComponent<EventManagerDichoticListening>().incorrectNumber += 1;
                }
                responded = true;
            }
        }
    }
}
