using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class FMODMarkerListener : MonoBehaviour
{
    public StudioEventEmitter emitter;
    public EnemyGun gun;
    public RotatingEnemyGun rotatinggun;

    private EventInstance eventInstance;
    private GCHandle callbackHandle;

    private readonly Queue<string> markerQueue = new Queue<string>();
    private readonly object queueLock = new object();

    private void Start()
    {
        if (emitter == null)
            emitter = GetComponent<StudioEventEmitter>();

        if (emitter == null)
        {
            UnityEngine.Debug.LogError("FMODMarkerListener: No StudioEventEmitter assigned.");
            return;
        }

        eventInstance = emitter.EventInstance;

        callbackHandle = GCHandle.Alloc(this);
        eventInstance.setUserData(GCHandle.ToIntPtr(callbackHandle));
        eventInstance.setCallback(MarkerCallback, EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
    }

    private void Update()
    {
        lock (queueLock)
        {
            while (markerQueue.Count > 0)
            {
                string markerName = markerQueue.Dequeue();
                HandleMarker(markerName);
            }
        }
    }

    private void OnDestroy()
    {
        if (eventInstance.isValid())
        {
            eventInstance.setCallback(null, EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
            eventInstance.setUserData(IntPtr.Zero);
        }

        if (callbackHandle.IsAllocated)
            callbackHandle.Free();
    }

    [AOT.MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
    private static RESULT MarkerCallback(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
    {
        EventInstance instance = new EventInstance(instancePtr);

        if (type == EVENT_CALLBACK_TYPE.TIMELINE_MARKER)
        {
            TIMELINE_MARKER_PROPERTIES marker =
                Marshal.PtrToStructure<TIMELINE_MARKER_PROPERTIES>(parameterPtr);

            instance.getUserData(out IntPtr userDataPtr);

            if (userDataPtr != IntPtr.Zero)
            {
                GCHandle handle = GCHandle.FromIntPtr(userDataPtr);

                if (handle.Target is FMODMarkerListener listener)
                {
                    listener.QueueMarker(marker.name);
                }
            }
        }

        return RESULT.OK;
    }

    private void QueueMarker(string markerName)
    {
        lock (queueLock)
        {
            markerQueue.Enqueue(markerName);
        }
    }

    private void HandleMarker(string markerName)
    {
        UnityEngine.Debug.Log("FMOD Marker Hit: " + markerName);

        switch (markerName)
        {
            case "Kick":
                if (gun != null)
                    gun.shootdefault();
                break;

            case "Lead":
                if (gun != null)
                    gun.shotgun();
                break;

            case "Bass":
                if (gun != null)
                    gun.circle();
                break;

            case "Impact":
                if (rotatinggun != null)
                    rotatinggun.shootvolley();
                break;
        }
    }
}
