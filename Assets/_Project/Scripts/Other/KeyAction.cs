using System;
using UnityEngine;
using UnityEngine.Events;

namespace FireAndWater
{
    [Serializable]
    public struct KeyAction
    {
        public KeyCode KeyCode;
        public UnityEvent Call;
    }
}