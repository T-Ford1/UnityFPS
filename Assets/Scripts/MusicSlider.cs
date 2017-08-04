using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(AudioSource))]
public class MusicSlider : MonoBehaviour
{

    [SerializeField]
    private Toggle t;

    private Slider s;
    private AudioSource a;

    void Start()
    {
        s = GetComponent<Slider>();
        a = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(t != null && !t.isOn)
        {
            a.Pause();
            return;
        }

        a.volume = s.value;
        if (s.value == 0f)
        {
            a.Pause();
        }
        else
        {
            a.UnPause();
        }
    }
}
