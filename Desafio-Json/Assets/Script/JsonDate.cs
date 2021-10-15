using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public string message;
}

[System.Serializable]
public class JsonDate
{
    public bool success;
    public string status;
    public Data data;
}
