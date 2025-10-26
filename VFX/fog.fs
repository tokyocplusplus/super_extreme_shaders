#version 330
out vec4 FragColor;

float near = 0.1; 
float far  = 17.0; 
  
float LinearizeDepth(float depth) 
{
    float z = depth * 2.0 - 1.0; // NDC
    return (2.0 * near * far) / (far + near - z * (far - near));	
}

void main()
{             
    float depth = LinearizeDepth(gl_FragCoord.z) / far; // divide by far for demonstration
    float d = 1 - depth;
    float darknessFactor = 0.5;
    vec4 idk = vec4(vec3(d * darknessFactor),1.0);
    FragColor = idk;
}
