using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlaySnd : MonoBehaviour
{
        public AudioSource AudioSource;
        public AudioClip ClickSound;

        public void Awake()
        {
            GetComponent<Button>().onClick.AddListener(PlayClickSound);
        }

        private void PlayClickSound()
        {
            AudioSource.PlayOneShot(ClickSound);
        }
    }
