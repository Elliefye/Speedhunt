using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour {

    bool walking;
    bool routineRunning;
    public float rate = 1;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    public AudioSource m_AudioSource;

    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            walking = true;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                rate = 0.35f;
            }
            else
            {
                rate = 0.55f;
            }
        }
        else walking = false;
        if(!routineRunning && walking)
            StartCoroutine(wait());
	}

    IEnumerator wait()
    {
        routineRunning = true;
        yield return new WaitForSeconds(rate);
        PlayFootStepAudio();
        routineRunning = false;
    }

    private void PlayFootStepAudio()
    {
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }
}
