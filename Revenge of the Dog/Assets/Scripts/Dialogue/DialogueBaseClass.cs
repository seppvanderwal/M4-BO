using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
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
