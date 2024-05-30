import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { AppProvider } from "./context/AppContext.tsx";
import "./index.css";
import { ConfigProvider } from "antd";
import { SWRConfig } from "swr";
import { http } from "./api/index.ts";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <ConfigProvider
      theme={{
        token: {
          fontSize: 18
        }
      }}
    >
      <AppProvider>
        <SWRConfig
          value={{
            fetcher: (resource) => http.get(resource).then(res => res.data)
          }}
        >
          <App />
        </SWRConfig>
      </AppProvider>
    </ConfigProvider>
  </React.StrictMode>
);
