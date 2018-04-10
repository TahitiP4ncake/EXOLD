// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:1,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33451,y:32746,varname:node_3138,prsc:2|emission-6919-OUT,custl-293-OUT;n:type:ShaderForge.SFN_LightVector,id:2555,x:31856,y:32895,varname:node_2555,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:479,x:31856,y:33023,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7812,x:32027,y:32942,cmnt:Lambert,varname:node_7812,prsc:2,dt:1|A-2555-OUT,B-479-OUT;n:type:ShaderForge.SFN_AmbientLight,id:9058,x:32662,y:32885,varname:node_9058,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6919,x:33133,y:32792,cmnt:Ambient Light,varname:node_6919,prsc:2|A-8366-RGB,B-3286-OUT;n:type:ShaderForge.SFN_Set,id:8876,x:33449,y:32673,varname:color,prsc:2|IN-8366-RGB;n:type:ShaderForge.SFN_Set,id:5141,x:32200,y:32942,varname:light,prsc:2|IN-7812-OUT;n:type:ShaderForge.SFN_Get,id:6766,x:30328,y:33200,varname:node_6766,prsc:2|IN-5141-OUT;n:type:ShaderForge.SFN_Get,id:837,x:32182,y:33387,varname:node_837,prsc:2|IN-8876-OUT;n:type:ShaderForge.SFN_Multiply,id:1516,x:32512,y:33254,cmnt:Modify how dark you want the shadows,varname:node_1516,prsc:2|A-837-OUT,B-8210-OUT;n:type:ShaderForge.SFN_Slider,id:8210,x:32009,y:33292,ptovrint:False,ptlb:ShadowDarkness,ptin:_ShadowDarkness,varname:node_6152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_LightColor,id:1301,x:31574,y:33710,varname:node_1301,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:5982,x:31574,y:33850,varname:node_5982,prsc:2;n:type:ShaderForge.SFN_Multiply,id:901,x:31930,y:33658,varname:node_901,prsc:2|A-5366-OUT,B-1301-RGB,C-5982-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2023,x:31185,y:32882,ptovrint:False,ptlb:Tones,ptin:_Tones,varname:node_2501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Subtract,id:3024,x:31500,y:32923,cmnt:Number of lighting tones,varname:node_3024,prsc:2|A-2023-OUT,B-2058-OUT;n:type:ShaderForge.SFN_Vector1,id:2058,x:31185,y:33039,varname:node_2058,prsc:2,v1:1;n:type:ShaderForge.SFN_Set,id:643,x:31683,y:32923,varname:tones,prsc:2|IN-3024-OUT;n:type:ShaderForge.SFN_Multiply,id:364,x:31150,y:33241,varname:node_364,prsc:2|A-8604-OUT,B-4156-OUT;n:type:ShaderForge.SFN_Get,id:4156,x:30934,y:33380,varname:node_4156,prsc:2|IN-643-OUT;n:type:ShaderForge.SFN_Round,id:7342,x:31423,y:33246,cmnt:Clamp the lighting,varname:node_7342,prsc:2|IN-364-OUT;n:type:ShaderForge.SFN_Divide,id:5366,x:31725,y:33461,varname:node_5366,prsc:2|A-7342-OUT,B-4156-OUT;n:type:ShaderForge.SFN_Lerp,id:293,x:32761,y:33367,varname:node_293,prsc:2|A-1516-OUT,B-837-OUT,T-4247-OUT;n:type:ShaderForge.SFN_Tex2d,id:8366,x:32396,y:32711,ptovrint:False,ptlb:Albedo,ptin:_Albedo,varname:node_8366,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Clamp01,id:3286,x:32934,y:32867,varname:node_3286,prsc:2|IN-9058-RGB;n:type:ShaderForge.SFN_Clamp01,id:2885,x:30529,y:33218,varname:node_2885,prsc:2|IN-6766-OUT;n:type:ShaderForge.SFN_Clamp01,id:4247,x:32218,y:33621,varname:node_4247,prsc:2|IN-901-OUT;n:type:ShaderForge.SFN_RemapRange,id:8604,x:30785,y:33192,varname:node_8604,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.8|IN-2885-OUT;proporder:8210-2023-8366;pass:END;sub:END;*/

Shader "Shader Forge/S_CutRock" {
    Properties {
        _ShadowDarkness ("ShadowDarkness", Range(0, 1)) = 0
        _Tones ("Tones", Float ) = 2
        _Albedo ("Albedo", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "DisableBatching"="True"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _ShadowDarkness;
            uniform float _Tones;
            uniform sampler2D _Albedo; uniform float4 _Albedo_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _Albedo_var = tex2D(_Albedo,TRANSFORM_TEX(i.uv0, _Albedo));
                float3 emissive = (_Albedo_var.rgb*saturate(UNITY_LIGHTMODEL_AMBIENT.rgb));
                float3 color = _Albedo_var.rgb;
                float3 node_837 = color;
                float light = max(0,dot(lightDirection,normalDirection));
                float tones = (_Tones-1.0);
                float node_4156 = tones;
                float3 finalColor = emissive + lerp((node_837*_ShadowDarkness),node_837,saturate(((round(((saturate(light)*0.8+0.0)*node_4156))/node_4156)*_LightColor0.rgb*attenuation)));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _ShadowDarkness;
            uniform float _Tones;
            uniform sampler2D _Albedo; uniform float4 _Albedo_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Albedo_var = tex2D(_Albedo,TRANSFORM_TEX(i.uv0, _Albedo));
                float3 color = _Albedo_var.rgb;
                float3 node_837 = color;
                float light = max(0,dot(lightDirection,normalDirection));
                float tones = (_Tones-1.0);
                float node_4156 = tones;
                float3 finalColor = lerp((node_837*_ShadowDarkness),node_837,saturate(((round(((saturate(light)*0.8+0.0)*node_4156))/node_4156)*_LightColor0.rgb*attenuation)));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
