using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NeonFilter : SimpleFilter
{
    protected override void UseFilter(RenderTexture source, RenderTexture destination)
    {
        //берем быструю текстуру для вычисления
        RenderTexture neonTex = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
        RenderTexture thresholdTex = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
        RenderTexture blurTex = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

        Graphics.Blit(source, neonTex, _mat, 0);
        Graphics.Blit(neonTex, thresholdTex, _mat, 1);
        Graphics.Blit(thresholdTex, blurTex, _mat, 2);
        _mat.SetTexture("_SrcTex", neonTex);
        Graphics.Blit(blurTex, destination, _mat, 3);

        RenderTexture.ReleaseTemporary(neonTex);
        RenderTexture.ReleaseTemporary(thresholdTex);
        RenderTexture.ReleaseTemporary(blurTex);
    }
   
}
