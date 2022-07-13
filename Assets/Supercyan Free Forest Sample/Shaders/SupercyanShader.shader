Shader "Supercyan/SupercyanShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf SupercyanShadingForward fullforwardshadows 
			#pragma target 3.0

			#include "SupercyanShaderLighting.cginc"

			sampler2D _MainTex;

			struct Input
			{
				float2 uv_MainTex;
			};

			UNITY_INSTANCING_BUFFER_START(Props)
				UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutput o)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}