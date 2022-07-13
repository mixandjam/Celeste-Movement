#ifndef SUPERCYAN_SHADING_LIGHTING_INCLUDED
#define SUPERCYAN_SHADING_LIGHTING_INCLUDED

static const half LightingSupercyanShadingSmoothMin = 0.3;
static const half LightingSupercyanShadingSmoothMax = 0.5;
static const half LightingSupercyanShadingSmoothPow = 0.5;
static const half LightingSupercyanShadingRimStrength = 0.25;

inline half GetMax(half3 color) {
	return max(color.g, max(color.r, color.b));
}

inline void LightingSupercyanShadingForward_GI(inout SurfaceOutput s, UnityGIInput data, inout UnityGI gi)
{
	gi = UnityGlobalIllumination(data, 1.0, s.Normal);
}

inline half4 LightingSupercyanShadingForward(SurfaceOutput s, half3 viewDir, UnityGI gi) {
	UnityLight light = gi.light;

	half diffuse = max(0, min(dot(s.Normal, light.dir), GetMax(light.color)));
	half rim = (1 - dot(s.Normal, viewDir)) * diffuse;

	diffuse = pow(smoothstep(LightingSupercyanShadingSmoothMin, LightingSupercyanShadingSmoothMax, diffuse), LightingSupercyanShadingSmoothPow);
	rim = (pow(smoothstep(LightingSupercyanShadingSmoothMin, LightingSupercyanShadingSmoothMax, rim), LightingSupercyanShadingSmoothPow)) * LightingSupercyanShadingRimStrength;

	half4 c;
	c.rgb = s.Albedo * light.color * diffuse + rim * light.color;

#ifdef UNITY_LIGHT_FUNCTION_APPLY_INDIRECT
	c.rgb += s.Albedo * gi.indirect.diffuse.rgb;
#endif

	c.a = s.Alpha;
	return c;
}

#endif