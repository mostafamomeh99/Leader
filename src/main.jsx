import { StrictMode, Suspense, lazy } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import StateManagement from "./StateMangment.jsx";
import { BrowserRouter } from "react-router-dom";
import "./Resources/i1n8";     // i18next config
import "./Resources/bootstrap";  // bootstrap config
const App = lazy(() => import("./App.jsx"));

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <BrowserRouter>
    <StateManagement>
      <Suspense fallback={<div>Loading...</div>}>
        <App />
      </Suspense>
    </StateManagement>
    </BrowserRouter>
  </StrictMode>
);
