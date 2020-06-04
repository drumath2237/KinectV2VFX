﻿using System;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace KinectV2VFX
{
    [RequireComponent(typeof(DepthSourceManager))]
    public class DepthTextureGenerator : UnityEngine.MonoBehaviour
    {
        [SerializeField] private DepthSourceManager _DepthSource;
        [SerializeField] private Texture2D _DepthTexture2D;

        private void Start()
        {
            _DepthSource = GetComponent<DepthSourceManager>();
        }

        private void Update()
        {
            var depthData = _DepthSource.GetData();
            byte[] _rawData = new byte[depthData.Length * 2];
            
            Buffer.BlockCopy(depthData, 0, _rawData, 0, depthData.Length*2);

            _DepthTexture2D.LoadRawTextureData(_rawData);
            _DepthTexture2D.Apply();
        }
    }
}