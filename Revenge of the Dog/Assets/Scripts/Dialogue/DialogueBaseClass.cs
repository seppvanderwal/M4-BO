<<<<<<< HEAD
﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
>>>>>>> Valerie-Art

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
<<<<<<< HEAD
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, Text textHolder, Color textColor,float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            //textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }
}

=======
        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, float delay, AudioClip sound)
        {
            textHolder.color = textColor;

            for(int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                //play letter sound
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
>>>>>>> Valerie-Art
