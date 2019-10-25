using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{

    AudioSource _audioSource;
    public static float[] _sapmples= new float[512];

    public static float[] _frequencyBands = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];
    //#if UNITY_WEBGL
    int count = 0;
    float[] _WebSamples;

    //#endif


    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //for (int i = count; i < _sapmples.Length; i++)
        //{
        //    _sapmples[i] = _WebSamples[count + i];
        //}
        //count += 512;
        //StartCoroutine("start");
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        
    }

    private void BandBuffer()
    {

        for (int g = 0; g < 8; g++)
        {
            if (_frequencyBands[g] > _bandBuffer[g])
            {
                if (_frequencyBands[g] - _bandBuffer[g] > 0.1f)
                {
                    _bandBuffer[g] += 0.2f;
                }
                else
                {
                    _bandBuffer[g] = _frequencyBands[g];
                    _bufferDecrease[g] = 0.005f;
                }
            }
            else if (_frequencyBands[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1f;
            }
        }
    }

    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator start()
    {
       
        // Start function WaitAndPrint as a coroutine
        yield return StartCoroutine("WaitAndPrint");
    }


    void GetSpectrumAudioSource()
    {
        
            _sapmples = CamSpectrumData.RetuenSpectrumData(); 
            //AudioListener.GetSpectrumData(_sapmples, 0, FFTWindow.Blackman); 
            //_audioSource.GetSpectrumData(_sapmples, 0, FFTWindow.Blackman);

        
    }



    void MakeFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _sapmples[count] * (count + 1);

                count++;
            }
            average /= count;
            _frequencyBands[i] = average * 10;
        }
    }
}
