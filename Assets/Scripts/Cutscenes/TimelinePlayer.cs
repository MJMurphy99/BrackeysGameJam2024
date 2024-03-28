using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public static class TimelinePlayer
{
    private static PlayableDirector director;

    public static void StartTimeline()
    {
        director.Play();
    }

    public static void BuildDirector(PlayableDirector dir)
    {
        director = dir;
    }
}
