Shader "PluginShader/EdgeDetection" {
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

	
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv[3] : TEXCOORD0;
			};
	
			sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;

			sampler2D _CameraDepthNormalsTexture;
			sampler2D_float _CameraDepthTexture;

			uniform half4 _Sensitivity; //.x = depth sensitivity, .y = normals sensitivity
			uniform half _FadeToWhite;
			uniform half _SampleDistance;



			inline half IsOnEdge(half2 centerNormal, float centerDepth, half2 sampleNormal, float sampleDepth)
			{
				// difference in normals (encoded in xy)
				half2 diff = abs(centerNormal - sampleNormal) * _Sensitivity.y;
				half normalIsSimilar = (diff.x + diff.y) * _Sensitivity.y < 0.1;

				// difference in depth
				float zdiff = abs(centerDepth-sampleDepth);

				// scale the required threshold by the distance
				half depthIsSimilar = zdiff * _Sensitivity.x < 0.09 * centerDepth;
	
				if(normalIsSimilar == false || depthIsSimilar == false) //Edge detected
				{
					return true;
				}
				else
				{
					return false;
				}

			}	


				
			v2f vert( appdata_img v ) 
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
		
				float2 uv = v.texcoord.xy;				

				#if UNITY_UV_STARTS_AT_TOP
				if (_MainTex_TexelSize.y < 0)
					uv.y = 1-uv.y;
				#endif

				o.uv[0] = uv;
				
				//sample coordinates
				o.uv[1] = uv + float2(-_MainTex_TexelSize.x, -_MainTex_TexelSize.y) * _SampleDistance;
				o.uv[2] = uv + float2(+_MainTex_TexelSize.x, -_MainTex_TexelSize.y) * _SampleDistance;
		
				return o;
			}
			
			half4 frag(v2f i) : SV_Target 
			{
				half4 original = tex2D(_MainTex, float2(i.uv[0].x, 1 - i.uv[0].y));
			
				//Sample the current pixel and two in the surrindings, in the depth + normal buffer
				half4 center = tex2D (_CameraDepthNormalsTexture, i.uv[0]);
				half4 sample1 = tex2D (_CameraDepthNormalsTexture, i.uv[1]);
				half4 sample2 = tex2D (_CameraDepthNormalsTexture, i.uv[2]);
		
				half edge = 1.0;

				if(IsOnEdge(center.xy, DecodeFloatRG(center.zw), sample1.xy, DecodeFloatRG(sample1.zw)) == false 
					&& IsOnEdge(center.xy, DecodeFloatRG(center.zw), sample2.xy, DecodeFloatRG(sample2.zw)) == false)
				{
					return lerp(original, half4(1,1,1,1), _FadeToWhite);
				}

				else //Edge detected, display black line !
				{
					return half4(0,0,0,1);
				}

			}

			ENDCG
		}
		
		
	}
	
	Fallback off
} 
