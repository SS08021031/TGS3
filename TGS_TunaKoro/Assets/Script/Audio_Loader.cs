using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Loader : MonoBehaviour
{
    public Audio_Manager AM;

    //�I�[�f�B�I�}�l�[�W���[�𐶐��@
    private void Awake()
    {
        if(FindObjectOfType<Audio_Manager>() == null)
        {
            Audio_Manager.instance = Instantiate(AM);
            DontDestroyOnLoad(Audio_Manager.instance.gameObject);
        }
    }
}
