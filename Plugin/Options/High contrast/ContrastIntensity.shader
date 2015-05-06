Shader "PluginShader/ContrastIntensity" {
	Properties {
		[HideInInspector]_MainTex ("Base (RGB)", 2D) = "" {}
	}
	
	SubShader {
	
		ZTest Always Cull Off ZWrite Off Fog { Mode Off } //Rendering settings

		Pass{
		    CGPROGRAM
		    #pragma vertex vert
		    #pragma fragment frag
			#include "UnityCG.cginc" 

	
			struct v2f 
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			sampler2D _MainTex;

			float intensity;
				
			v2f vert( appdata_img v ) 
			{
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}
			
			half4 frag(v2f i) : SV_Target 
			{
				half4 pixelColor = tex2D (_MainTex, i.uv);
				pixelColor.rgb = ((pixelColor.rgb - 0.5f) * max(intensity, 0)) + 0.5f;
				return pixelColor;
			}
			ENDCG
		}
		
		
	}
	
	Fallback off
} 
