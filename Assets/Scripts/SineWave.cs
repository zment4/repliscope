using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a texture that can be modified realtime and used on a quad
public class SineWave : MonoBehaviour {
    public Color WaveColor = Color.white;
    public Color BackgroundColor = Color.black;

    public float MinAmplitude = 0.5f;
    public float MaxAmplitude = 3f;
    public float MinWavelength = 1f;
    public float MaxWavelength = 5f;
    public int Width = 256, Height = 256;
    public float WaveLength = 1;
    public float Amplitude = 1;
    public float LineWidth = 0.1f;
    public Rect OArea = new Rect();
    public float HorizontalSpeed = 1.0f;

    private Texture2D texture;

    private void Start()
    {
        texture = CreateSineWaveTexture(Width, Height, WaveLength, Amplitude, texture);

        var mr = GetComponent<MeshRenderer>();
        if (mr != null)
            mr.material.mainTexture = texture;
    }

    private void Update()
    {
        WaveLength = Mathf.Clamp(WaveLength, MinWavelength, MaxWavelength);
        Amplitude = Mathf.Clamp(Amplitude, MinAmplitude, MaxAmplitude);

        OArea.x += HorizontalSpeed * Time.deltaTime;

        texture = CreateSineWaveTexture(Width, Height, WaveLength, Amplitude, texture);
    }

    private Texture2D CreateSineWaveTexture(int width, int height, float wavelength, float amplitude, Texture2D texture)
    {
        if (texture == null)
            texture = new Texture2D(width, height);

        if (texture.width != width || texture.height != height)
            texture.Resize(width, height);

        float ox = OArea.xMin;
        for (int x = 0; x < width; x++)
        {
            float sine = Mathf.Sin(ox * wavelength);
            float cosine = Mathf.Cos(ox * wavelength);

            float oy = OArea.yMin;
            for (int y = 0; y < height; y++)
            {
                float f = sine * amplitude - oy;
                f *= ((1f - Mathf.Abs(cosine)) + 1f) / 2f / amplitude;

                float d = Mathf.Sqrt(f * f);
                float t = d / LineWidth;

                Color gradient = Color.Lerp(WaveColor, BackgroundColor, t);

                texture.SetPixel(x, y, gradient);

                oy += ((float) OArea.height / height);
            }

            ox += ((float) OArea.width / width);
        }

        texture.Apply();
        return texture;
    }
}
