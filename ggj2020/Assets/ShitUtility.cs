using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets
{
    class ShitUtility:MonoBehaviour
    {
        /// <summary>
        /// These two arrays better be the same length because I am not making any failsafes for this rn
        /// </summary>
        public List<TextMeshProUGUI> textObjects;
        public List<string> strings;

        /// <summary>
        /// Aidan wrote these, ripping them from terminal.cs
        /// </summary>
        /// <param name="text"></param>
        public void WriteToDisplay(string text, TextMeshProUGUI display, float speed = .1f)
        {
            StartCoroutine(WriteCoroutine(text, display, speed));
        }

        IEnumerator WriteCoroutine(string words, TextMeshProUGUI display, float speed)
        {

            TextMeshProUGUI displayText = display;

            for (int i = 0; i < words.Length; i++)
            {
                displayText.text += words[i];
                yield return new WaitForSeconds(speed);
            }
        }

        private void Start()
        {
            //just kidding i will check
            if (strings.Count == textObjects.Count)
            {
                for (int i = 0; i < textObjects.Count; i++)
                {
                    WriteToDisplay(strings[i], textObjects[i]);
                }
            }
        }
    }
}
