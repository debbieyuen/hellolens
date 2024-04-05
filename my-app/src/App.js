import './App.css';
import React from "react";
import Unity, { UnityContext } from "react-unity-webgl";

const unityContext = new UnityContext({
  loaderUrl: "./Build1/Build/Build1.loader.js",
  dataUrl: "./Build1/Build/Build1.data",
  frameworkUrl: "./Build1/Build/Build1.framework.js",
  codeUrl: "./Build1/Build/Build1.wasm",
});

function App() {
  return (
    
    <div className="App">
      <div className ="Unity">
        <Unity unityContext={unityContext} 
        style= {{
          height: "100vh",
          width: "100vw",
          position: "absolute",
          top: 0,
          left: 0,
          justifySelf: "center",
          alignSelf: "center",
          overflow: "hidden",
        }}/>  
      </div>

      <div className="HeaderBar">
        <h1>HELLOLENS</h1>
        <a href="https://docs.google.com/document/d/1_dCsDPlbdG0KmRdg_9qzkT5Wib6FfCAADcAgBb3p4GE/edit?usp=sharing"><button>Resume</button></a>
        <a href="https://debbieyuen.me/"><button>Portfolio</button></a>
        <a href="https://github.com/debbieyuen"><button>GitHub</button></a>
      </div>
    </div>
  );
}

export default App;