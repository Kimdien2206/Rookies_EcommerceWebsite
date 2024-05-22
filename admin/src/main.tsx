import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { AppProvider } from "./context/AppContext.tsx";
import "./index.css";
import { ConfigProvider } from "antd";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <ConfigProvider
      theme={{
        token: {
          fontSize: 20
        }
      }}
    >
      <AppProvider>
        <App />
      </AppProvider>
    </ConfigProvider>
  </React.StrictMode>
);
