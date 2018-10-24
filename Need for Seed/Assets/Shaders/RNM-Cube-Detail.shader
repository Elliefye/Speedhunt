/*  Author's info:
 *  - Blog  : http://n00body.squarespace.com/
 *  - E-mail: crunchy.bytes.blog@gmail.com
 *
 *  Usage Requirements:
 *  - If you use a large portion of my codebase, please credit either myself
 *      or the original author for portions of code that have been borrowed
 *  - If you wish to use bits of my code in a commercial project, please use
 *      the provided information to contact me and tell me about it.
 */

Shader "[n00b's RNM]/RNM-Cube-Detail" {
    Properties {
        _MainColor          ("Main Color", Color)           = (1,1,1,1)
        _LightMapColor      ("LightMap Color", Color)       = (1,1,1,0) 
        _LightMapIntensity  ("LightMap Intensity", Float)   = 1
        _LightMapInfluence  ("LightMap Influence", Float)   = 0
        _SpecColor          ("Specular Color", Color)       = (1,1,1,1)
        _Shininess          ("Shininess", Float)            = 0.078125
        _Fresnel            ("Fresnel", Float)              = 1
        _EnvMapColor        ("Env Map Color", Color)        = (1,1,1,1)
        _EnvMapIntensity    ("Env Map Intensity", Float)    = 1
        _DetailTransform    ("Detail Transform", Vector)    = (1,1,0,0)
        _DetailWeight       ("Detail Weight", Float)        = 0
        _MainTex            ("Main Texture", 2D)            = "white" {}
        _BumpMap            ("Bump Map", 2D)                = "bump" {}
        _DetailMap          ("Detail Map", 2D)              = "white" {}
        _DetailBumpMap      ("Detail Bump Map", 2D)         = "bump" {}
        _LightMap0          ("LightMap 0", 2D)              = "white" {}
        _LightMap1          ("LightMap 1", 2D)              = "white" {}
        _LightMap2          ("LightMap 2", 2D)              = "white" {}
        _EnvMap             ("Env Map", CUBE)               = "" {}
    }
    SubShader {
        Tags { "RenderType" = "Opaque" }
        CGPROGRAM
            #pragma surface Surface BlinnPhong
            #pragma target 3.0 // required, since we exceed SM2.0 64 instr limit
            
            #define Square(x)   x * x 
            #define DeGamma(x)  Square(x)
            #define ReGamma(x)  sqrt(x)
            
            struct Input 
            {
                float2 uv_MainTex;
                float2 uv2_LightMap0; 
                float3 viewDir;
                float3 worldRefl;
                INTERNAL_DATA
            };
            
            uniform float4      _MainColor;
            uniform float3      _LightMapColor; 
            uniform float       _LightMapIntensity;
            uniform float       _LightMapInfluence;
            // SpecColor is implicit (>_<)
            uniform float       _Shininess;
            uniform float       _Fresnel;
            uniform float3      _EnvMapColor; 
            uniform float       _EnvMapIntensity;
            uniform float4      _DetailTransform;
            uniform float       _DetailWeight;
            uniform sampler2D   _MainTex;
            uniform sampler2D   _BumpMap;    
            uniform sampler2D   _DetailMap;
            uniform sampler2D   _DetailBumpMap;             
            uniform sampler2D   _LightMap0;
            uniform sampler2D   _LightMap1; 
            uniform sampler2D   _LightMap2; 
            uniform samplerCUBE _EnvMap;

            half Fresnel (in half3 N, in half3 E, in half f0)
            {
                return f0 + (1.0f - f0) * pow(1.0f - dot(N, E), 5.0f);
            }
            
            void Surface (Input IN, inout SurfaceOutput o) 
            {
                half3 dp;
                half3 DiffuseLight;
                half3 SpecularLight;
                half3 Result;
            
                // Valve RNM basis (Right-Handed)
                // http://www.valvesoftware.com/publications/2004/GDC2004_Half-Life2_Shading.pdf
                half3 RNM_BASIS[3] =
                {
                    half3(sqrt(2.0) / sqrt(3.0),              0.0, 1.0 / sqrt(3.0)), 
                    half3(     -1.0 / sqrt(6.0),  1.0 / sqrt(2.0), 1.0 / sqrt(3.0)),
                    half3(     -1.0 / sqrt(6.0), -1.0 / sqrt(2.0), 1.0 / sqrt(3.0))
                };
            
                // ---- Detail Mapping ----
                half3 CombinedDiffuse;
                half3 CombinedNormal;
                half4 Material      = (half4)tex2D(_MainTex, IN.uv_MainTex);
                half4 Detail        = (half4)tex2D(_DetailMap, IN.uv_MainTex * _DetailTransform.xy + _DetailTransform.zw);
                half3 Normal        = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex)).xyz;
                half3 DetailNormal  = UnpackNormal(tex2D(_DetailBumpMap, IN.uv_MainTex * _DetailTransform.xy + _DetailTransform.zw));
                
                CombinedDiffuse     = lerp(Material.rgb, Detail.rgb, Detail.a);
                CombinedNormal      = Normal;
                CombinedNormal.xy  += DetailNormal.xy;
                CombinedNormal.xyz  = normalize(CombinedNormal.xyz);
                
                // ---- Material ----
                o.Alpha     = 1.0f;
                o.Albedo    = lerp(Material.rgb, CombinedDiffuse, _DetailWeight) * _MainColor;
                o.Normal    = lerp(Normal.xyz, CombinedNormal, _DetailWeight);
                o.Gloss     = Material.a; // _SpecColor gets implicitly multiplied (>_<)
                o.Specular  = _Shininess;
                o.Emission  = 0.0f;
                
                // ---- Static Lighting ----                
                // De-Gamma surface materials & lightmaps 
                half3 DiffuseColor      = DeGamma(o.Albedo);
                half3 SpecularIntensity = DeGamma(o.Gloss *_SpecColor);
                
                half3 Irradiance0 = DeGamma((half3)tex2D(_LightMap0, IN.uv2_LightMap0).rgb);
                half3 Irradiance1 = DeGamma((half3)tex2D(_LightMap1, IN.uv2_LightMap0).rgb);
                half3 Irradiance2 = DeGamma((half3)tex2D(_LightMap2, IN.uv2_LightMap0).rgb);
                
                // Diffuse Lighting
                // http://www.valvesoftware.com/publications/2004/GDC2004_Half-Life2_Shading.pdf
                dp.x = saturate(dot(o.Normal, RNM_BASIS[0]));
                dp.y = saturate(dot(o.Normal, RNM_BASIS[1]));
                dp.z = saturate(dot(o.Normal, RNM_BASIS[2]));
                dp *= dp;

                dp = dp / dot(dp, half3(1.0f, 1.0f, 1.0f));

                DiffuseLight = dp.x * Irradiance0 +
                                dp.y * Irradiance1 +
                                dp.z * Irradiance2;
                
                // Specular Lighting 
                SpecularLight   = DeGamma(texCUBE(_EnvMap, WorldReflectionVector(IN, o.Normal)).rgb);
                SpecularLight  *= _EnvMapColor * _EnvMapIntensity * Fresnel(o.Normal, normalize(IN.viewDir), _Fresnel);
                SpecularLight   = lerp(SpecularLight, SpecularLight * DiffuseLight, _LightMapInfluence);

                // Accumulate in linear space
                Result = DeGamma(_LightMapColor) * _LightMapIntensity *
                        (DiffuseLight * DiffuseColor + 
                        SpecularLight * SpecularIntensity);
                
                // Re-Gamma result (>_<)
                o.Emission  += ReGamma(Result);
            }
        ENDCG
    }
    Fallback "[n00b's RNM]/RNM"
}
