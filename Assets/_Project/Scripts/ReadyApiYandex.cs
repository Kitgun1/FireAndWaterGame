using System;
using UnityEngine;

namespace FireAndWater
{
    public class ReadyApiYandex : MonoBehaviour
    {
        private static bool _isInvoke = false;

        private void Start()
        {
            if (!_isInvoke)
            {
                #if UNITY_WEBGL
                Agava.YandexGames.YandexGamesSdk.GameReady();
                #endif
                _isInvoke = true;
            }
        }
    }
}