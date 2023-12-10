using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
