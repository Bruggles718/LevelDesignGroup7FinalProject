using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Troll : MonoBehaviour
{

    private Animator _animator;
    public AudioClip clip;
    public int volume = 1;
    public float roarSoundDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Roar()
    {
        _animator.Play("Troll_Roar");
        StartCoroutine(RoarSoundCo());
    }

    IEnumerator RoarSoundCo()
    {
        yield return new WaitForSeconds(roarSoundDelay);
        for (int i = 0; i < volume; i += 1)
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
        }
    }
}
