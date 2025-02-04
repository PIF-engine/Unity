﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Common;

public class LSLGazeOutlet : MonoBehaviour {


    private const string unique_source_id = "D256CFBDBA3144878CFA64140A219D31";

    private liblsl.StreamOutlet outlet;
    private liblsl.StreamInfo streamInfo;
    public liblsl.StreamInfo GetStreamInfo()
    {
        return streamInfo;
    }
    /// <summary>
    /// Use a array to reduce allocation costs
    /// </summary>
    private string[] currentSample;

    private double dataRate;

    public double GetDataRate()
    {
        return dataRate;
    }


    //do we have someone listening?
    public bool HasConsumer()
    {
        return outlet != null && outlet.have_consumers();
    }

    public string StreamName = "Unity.PIF.VectorName";
    public string StreamType = "Unity.VectorName";
    private const int ChannelCount = 4; // { Name , x , y , z }

    public MomentForSampling sampling;


    //Public fields for prefabs
    public GameObject TargetTMPDisplayPrefab;
    public GameObject FOVERig;


    private Raycaster raycast;

    private bool useFOVEGazeCast;


    //Set up our array for the current samples
    void Start () {
        // initialize the array once
        currentSample = new string[ChannelCount];

        dataRate = LSLUtils.GetSamplingRateFor(sampling, false);

        streamInfo = new liblsl.StreamInfo(StreamName, StreamType, ChannelCount, dataRate, liblsl.channel_format_t.cf_string, unique_source_id);

        outlet = new liblsl.StreamOutlet(streamInfo);

        gameObject.AddComponent<Raycaster>();
        raycast = gameObject.GetComponent<Raycaster>();
        try
        {
            useFOVEGazeCast = FoveInterface.IsHardwareConnected();
        }
        catch (Exception e)
        {
            useFOVEGazeCast = false;
        }
    }


    //Push the current mouse position and if it intersects with a collider
    private void pushSample()
    {
        if (outlet == null)
        {
            Debug.Log("No Outlet");
            return;
        }

        if (useFOVEGazeCast && FoveInterface.IsEyeTrackingCalibrating())
            return;

        //Will be using the FOVEGazeCast?
        var CRET = useFOVEGazeCast ? raycast.DoFOVECast(FOVERig, TargetTMPDisplayPrefab) : raycast.DoScreencast(Input.mousePosition);
        //if (float.IsInfinity(CRET.x)) return; //missed!
        currentSample[0] = CRET.Name;
        currentSample[1] = "" + CRET.x;
        currentSample[2] = "" + CRET.y;
        currentSample[3] = "" + CRET.z;

        //Debug.Log("Looking at word: " + CRET.Name);

        outlet.push_sample(currentSample, liblsl.local_clock());
        //Debug.Log("Pushed Word Sample");
    }

    /*
     * Do our sampling 
     */
    void FixedUpdate()
    {
        if (sampling == MomentForSampling.FixedUpdate)
            pushSample();
    }

    void Update()
    {
        if (sampling == MomentForSampling.Update)
            pushSample();
    }

    void LateUpdate()
    {
        if (sampling == MomentForSampling.LateUpdate)
            pushSample();
    }
}
