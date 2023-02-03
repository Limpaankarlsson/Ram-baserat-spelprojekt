using System.Collections;
using UnityEngine;

public class ProximityListener : MonoBehaviour
{

    public string enemyTag = "Enemy"; // For collab safety
    
    public float refreshRate = 1.5f;
    public float fadeTime = 0.5f;

    public float scaryDistance1 = 3f;
    public float scaryDistance2 = 1.5f;

    public AudioSource scaryTrack1;
    public AudioSource scaryTrack2;
    public AudioSource scaryTrack3;

    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {

        scaryTrack2.volume = scaryTrack3.volume = 0f;

        if (enemies == null)
            enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        InvokeRepeating("CheckForEnemies", 0f, refreshRate);
    }

    void CheckForEnemies()
    {

        float closest = 999;

        foreach ( var enemy in enemies )
        {
            float dist = Vector3.Distance(enemy.transform.position, transform.position);

            if (dist < closest)
                closest = dist;

        }


        // Play scary track 2
        if (closest < scaryDistance1)
            StartCoroutine(FadeAudioSource.StartFade(scaryTrack2, fadeTime, 1f));
        else
            StartCoroutine(FadeAudioSource.StartFade(scaryTrack2, fadeTime, 0f));

        // Play scary track 3
        if (closest < scaryDistance2)
            StartCoroutine(FadeAudioSource.StartFade(scaryTrack3, fadeTime, 1f));
        else
            StartCoroutine(FadeAudioSource.StartFade(scaryTrack3, fadeTime, 0f));

    }

    public static class FadeAudioSource
    {
        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }

}
