using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Bogadanul.Assets.Scripts.UI
{
    public class TimelineController : MonoBehaviour
    {
        public List<PlayableDirector> playableDirectors;
        public List<TimelineAsset> timelines = null;
        private int index;

        public static event Action OnTextchange = null;

        public void PlayNextTimeline ()
        {
            if (timelines.Count <= index)
            {
                return;
            }
            PlayTimeline ();
            index++;
        }

        public void PlayTimeline ()
        {
            if (index < timelines.Count)
            {
                playableDirectors[0].Play (timelines[index]);

                OnTextchange?.Invoke ();
            }
            else
            {
                Debug.LogError ("NoMoreTimelines");
            }
        }

        public void End ()
        {
            playableDirectors[0].Stop ();
        }
    }
}