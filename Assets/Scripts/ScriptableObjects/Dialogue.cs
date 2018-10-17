﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue")]
public class Dialogue : ScriptableObject {
    public new string name;

    [TextArea(3,10)]
    public string[] sentences;
}
