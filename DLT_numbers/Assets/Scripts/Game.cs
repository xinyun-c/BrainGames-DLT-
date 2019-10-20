using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour
{
    private List<AudioClip> AudioClips;
    private int target;
    public AudioClip targetInstruction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //enable is called when it is enabled
    private void OnEnable()
    {
        target = SelectTarget();
        StartCoroutine(PlayAudio(targetInstruction));
    }


    private int SelectTarget() {
        System.Random rnd = new System.Random();
        return rnd.Next(1, 20);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayAudio(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, );
        yield return new WaitForSeconds(audioSource.clip.length); // wait time
    }
}
