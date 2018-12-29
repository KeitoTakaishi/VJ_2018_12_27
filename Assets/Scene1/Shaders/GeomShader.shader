Shader "Custom/SimpleGeometryShaderAndGrassShader/SimpleGeometryShader"
{
    Properties
    {
        _Height("Height", float) = 5.0
        _High("_High", float) = 5.0
        [HDR]_BottomColor("Bottom Color", Color) = (1.0, 0.0, 0.0, 1.0)
        [HDR]_TopColor("Top Color", Color) = (0.0, 0.0, 1.0, 1.0)
        _ID("Id", Int) = 0
    }
        SubShader
    {
        Tags{ "RenderType" = "Opaque" }
        LOD 100

        Cull Off
        Lighting Off

        Pass
    {
        CGPROGRAM
#pragma target 5.0
#pragma vertex vert
#pragma geometry geom
#pragma fragment frag
#include "UnityCG.cginc"

        uniform float _Height;
    uniform float4 _BottomColor, _TopColor;

    struct v2g
    {
        float4 pos : SV_POSITION;
        float3 normal : NORMAL;
 
    };

    struct g2f
    {
        float4 pos : SV_POSITION;
        float4 col : COLOR;
    };

    

    v2g vert(appdata_full v)
    {
        v2g o;
        o.pos = v.vertex;
        o.normal = v.normal;

        return o;
    }

    float rand(float2 co) {
        return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
    }

    int _ID;
    float _vol[31];
    float _High;
    [maxvertexcount(9)]
    void geom(triangle v2g input[3], inout TriangleStream<g2f> outStream)
        //void geom(triangle v2g input[3], inout LineStream<g2f> outStream)
    {
        float4 p0 = input[0].pos;
        float4 p1 = input[1].pos;
        float4 p2 = input[2].pos;

        float3 normal = (input[0].normal + input[1].normal + input[2].normal) / 3.0;
        normal = normalize(normal);
        float3 _c = p0 + p1 + p2;
        float v = _vol[0];

        
        //float4 c = float4(float3(normal), 1.0f) * _Height*2.0 * rand(float2(_c.x + _ID * 1000.0*rand(float2(floor(_Time.x), floor(_Time.x))), _c.y + sin(_Time.w))) + (p0 + p1 + p2) / 3.0f;
        //float r = rand(float2(floor(_c.x * 100.0)/100.0, _Time.z)) > 0.5 ? 1.0 : 0.0;
        float r = frac(_c.x + _Time.y);
        r += rand(float2(_c.x, _c.y)) * 0.5;
        r = r > 0.95 ? r : 0.0;
        
        _Height = _Height > 1.0 ? 1.0 : _Height;
        float4 c = float4(float3(normal * _Height * r), 1.0f);


        g2f out0;
        out0.pos = UnityObjectToClipPos(p0);
        out0.col = _BottomColor;

        g2f out1;
        out1.pos = UnityObjectToClipPos(p1);
        out1.col = _BottomColor;

        g2f out2;
        out2.pos = UnityObjectToClipPos(p2);
        out2.col = _BottomColor;

        g2f o;
        o.pos = UnityObjectToClipPos(c);
        //o.col = _TopColor;
        //o.col = fixed4(_High, _High, _High, 1.0);
        o.col = fixed4 (0.0, _High, _High +0.1, 1.0);

        // bottom
        /* outStream.Append(out0);
        outStream.Append(out1);
        outStream.Append(out2);
        outStream.RestartStrip();
        */

        // sides
        /*outStream.Append(out0);
        outStream.Append(out1);
        outStream.Append(o);
        outStream.RestartStrip();

        outStream.Append(out1);
        outStream.Append(out2);
        outStream.Append(o);
        outStream.RestartStrip();

        outStream.Append(out2);
        outStream.Append(out0);
        outStream.Append(o);
        outStream.RestartStrip();*/


        outStream.Append(out0);
        outStream.Append(out1);
        outStream.Append(o);
        outStream.RestartStrip();

        outStream.Append(out1);
        outStream.Append(out2);
        outStream.Append(o);
        outStream.RestartStrip();

        outStream.Append(out2);
        outStream.Append(out0);
        outStream.Append(o);
        outStream.RestartStrip();
    }

    float4 frag(g2f i) : COLOR
    {
        return i.col;
    }
        ENDCG
    }
    }
}