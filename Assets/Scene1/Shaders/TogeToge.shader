// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SolidColor2" {
    SubShader{
        Pass{
        CGPROGRAM

#pragma vertex vert
#pragma fragment frag

        struct appdata_base {
        float4 vertex   : POSITION;
        float3 normal   : NORMAL;
        float4 texcoord : TEXCOORD0;
    };

    float val;
    float4 vert(appdata_base v) : SV_POSITION{

        float4 p = v.vertex;
        p.xyz += v.normal.xyz * val;
        return UnityObjectToClipPos(p);

    }

        fixed4 frag() : COLOR{
        return fixed4(1.0,0.0,0.0,1.0);
    }

        ENDCG
    }
  }
}