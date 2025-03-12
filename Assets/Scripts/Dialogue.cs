using System;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //public string name;

    //[TextArea(3, 10)]

    //public string[] sentences;
    public Sentences[] sentences;
    public message[] Messages;
    public NPCLayout[] actor;
}

[System.Serializable]

public class message
{
    public String audio;
    public int actorId;
    public String sentence;
    public string[] respuestas;
}

/*
[System.Serializable]

public class actor
{
    public string actorName; 
    public Sprite sprite;

}*/