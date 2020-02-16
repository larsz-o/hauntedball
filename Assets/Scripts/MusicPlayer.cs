﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake(){
        int gameStatusCount = FindObjectsOfType<MusicPlayer>().Length;
        if (gameStatusCount > 1 )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
