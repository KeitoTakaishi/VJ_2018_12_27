Shader "GlitchFx"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _DiffX("DiffX", Float) = 1.0
        _DiffY("DiffY", Float) = 1.0
        _BlockSizeX("BlockSizeX", Float) = 30.0
		_BlockSizeY("BlockSizeY", Float) = 30.0
        _BlockNum("BlockNum", Int) = 20
		_Threshold("Threshold", Float) = 0.5
        _TimeMag("TimeMag", Float) = 20.0
    }
    
    SubShader
    {
        Cull Off
        ZTest Always
        ZWrite Off
        
        Tags { "RenderType" = "Opaque"}
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "SimplexNoise3D.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            float _DiffX;
            float _DiffY;
            float _BlockSizeX;
            float _BlockSizeY;
			int _BlockNum;
			float _Threshold;
            float _TimeMag = 20.0;
            
            fixed4 frag (v2f i) : SV_Target
            {
                float noise = simplexNoise(float3(i.vertex.x, i.vertex.y, _Time.y));
                float2 uv = float2(i.uv);
                
                float NoiseBlock = 5;
                float2 block = floor(uv * _BlockNum) / _BlockNum;
                
                noise = simplexNoise(float3(block.x*_BlockSizeX, block.y*_BlockSizeY, _Time.y*_TimeMag));
                
                
                
                fixed4 col = tex2D(_MainTex, i.uv);
                float2 d = float2(0.01*_DiffX, 0.01*_DiffY);
                
                if(noise > _Threshold){
                   col.r = tex2D(_MainTex, frac(uv + _DiffX)).r;
                   col.g = tex2D(_MainTex, frac(uv - (_DiffX*1.3+_DiffY*0.7)/2.0)).g;
                   col.b = tex2D(_MainTex, frac(uv + _DiffY)).b;
                }
                
               
           
                return col;
            }
            ENDCG
        }
    }
}