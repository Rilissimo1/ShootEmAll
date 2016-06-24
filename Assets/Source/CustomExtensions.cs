using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

public static class CustomExtensions {
    public static void Play2DClipAtPoint(AudioClip clip, Vector3 position, float volume) {
        GameObject obj = new GameObject {name = "One Shot 2D Audio"};
        obj.transform.position = position;
        AudioSource source = obj.AddComponent<AudioSource>();
        source.spatialBlend = 0;
        source.clip = clip;
        source.Play();
        DestroyTimer timer = obj.AddComponent<DestroyTimer>();
        timer.Timer = clip.length;
    }

    public static void Play2DClipAtPoint(AudioClip clip, Vector3 position) {
        GameObject obj = new GameObject { name = "One Shot 2D Audio" };
        obj.transform.position = position;
        AudioSource source = obj.AddComponent<AudioSource>();
        source.spatialBlend = 0;
        source.clip = clip;
        source.Play();
        DestroyTimer timer = obj.AddComponent<DestroyTimer>();
        timer.Timer = clip.length;
    }
}
