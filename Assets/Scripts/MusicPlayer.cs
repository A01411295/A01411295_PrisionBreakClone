using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    MusicPlayer instance;

	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
	
}
