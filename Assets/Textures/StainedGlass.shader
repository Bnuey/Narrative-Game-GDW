Shader "Alvaro/URPGlassWithProperExtrusion"
{
Properties
{
_MainTex ("Texture", 2D) = "white" {}
_BumpMap ("Normalmap", 2D) = "bump" {}
_ScaleUV ("Scale", Range(1,20)) = 1
_BumpExtrusion ("Bump Extrusion", Range(0, 0.1)) = 0.01 // Extrusion amount
_FresnelIntensity ("Fresnel Intensity", Range(0, 2)) = 1
_EmissionColor ("Emission Color", Color) = (0,0,0,0)
_TintIntensity ("Tint Intensity", Range(1, 5)) = 1.5
}
SubShader
{
Tags { "Queue" = "Transparent" "RenderPipeline" = "UniversalRenderPipeline" }
Pass
{
HLSLPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
struct appdata
{
float4 vertex : POSITION;
float2 uv : TEXCOORD0;
float3 normal : NORMAL;
};
struct v2f
{
float2 uv : TEXCOORD0;
float4 uvgrab : TEXCOORD1;
float2 uvbump : TEXCOORD2;
float4 vertex : SV_POSITION;
float3 viewDirWS : TEXCOORD3;
float3 normalWS : TEXCOORD4;
};
// Declare texture and sampler variables for _MainTex and _BumpMap
TEXTURE2D(_MainTex);
SAMPLER(sampler_MainTex);
float4 _MainTex_ST;
TEXTURE2D(_BumpMap);
SAMPLER(sampler_BumpMap);
float4 _BumpMap_ST;
TEXTURE2D(_GrabTexture);
SAMPLER(sampler_GrabTexture);
float4 _GrabTexture_TexelSize;
float _ScaleUV;
float _BumpExtrusion; // Bump extrusion amount
float _FresnelIntensity;
float _TintIntensity;
float4 _EmissionColor;
// Vertex shader (extrusion based on vertex normal, not bump map)
v2f vert(appdata v)
{
v2f o;
// Transform vertex to world space
float3 worldPos = TransformObjectToWorld(v.vertex.xyz);
float3 normalWS = normalize(TransformObjectToWorldNormal(v.normal));
// Extrude vertices along the original normals (simplified)
worldPos += normalWS * _BumpExtrusion; // Extrude along normal direction
// Output the final vertex position in clip space
o.vertex = TransformWorldToHClip(worldPos);
#if UNITY_UV_STARTS_AT_TOP
float scale = -1.0;
#else
float scale = 1.0f;
#endif
o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y * scale) + o.vertex.w) * 0.5;
o.uvgrab.zw = o.vertex.zw;
o.uv = TRANSFORM_TEX(v.uv, _MainTex);
o.uvbump = TRANSFORM_TEX(v.uv, _BumpMap);
o.normalWS = normalWS;
o.viewDirWS = normalize(_WorldSpaceCameraPos - worldPos);
return o;
}
// Fragment shader
half4 frag(v2f i) : SV_Target
{
// Sample the normal map for lighting effects
half3 normalTS = UnpackNormal(SAMPLE_TEXTURE2D(_BumpMap, sampler_BumpMap, i.uvbump));
float3 normalWS = normalize(normalTS + i.normalWS);
// Fresnel effect
float viewNormalDot = saturate(dot(i.viewDirWS, normalWS));
float fresnelFactor = pow(1.0 - abs(viewNormalDot), _FresnelIntensity);
// Sample grab texture and main texture
half4 col = SAMPLE_TEXTURE2D(_GrabTexture, sampler_GrabTexture, i.uvgrab.xy /
i.uvgrab.w);
half4 tint = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
// Apply Fresnel effect and normal-based lighting to the color
col.rgb += fresnelFactor * tint.rgb;
// Apply tint with intensity factor
col *= tint * _TintIntensity;
// Apply emission
col += _EmissionColor;
// Gamma correction for vibrancy
col.rgb = pow(col.rgb, 1.0 / 2.2);
return col;
}
ENDHLSL
}
}
}