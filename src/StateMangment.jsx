import { createContext, useState, useEffect } from "react";
import { useTranslation } from "react-i18next";
import {jwtDecode} from "jwt-decode";

export const AppContext = createContext();

function StateManagement({ children }) {
  const { i18n } = useTranslation();
  const [direction, setDirection] = useState("rtl");
  const [token, setToken] = useState(null);
  const [user, setUser] = useState(null);

  // Language setup
  useEffect(() => {
    const storedLang = localStorage.getItem("i18nextLng") || "ar";
    i18n.changeLanguage(storedLang);
    setDirection(storedLang === "en" ? "ltr" : "rtl");
  }, [i18n]);

  const switchLang = (lng) => {
    localStorage.setItem("i18nextLng", lng);
    i18n.changeLanguage(lng);
    setDirection(lng === "ar" ? "rtl" : "ltr");
  };




  // Token setup
  useEffect(() => {
    const savedToken = localStorage.getItem("auth");
    if (savedToken) {
      handleToken(savedToken);
    }
  }, []);

  const handleToken = (newToken) => {
    try {
      localStorage.setItem("authToken", newToken);
      const decoded = jwtDecode(newToken);
      setToken(newToken);
      setUser(decoded);
    } catch (err) {
      console.error("Invalid token", err);
      logout();
    }
  };

  const login = (newToken) => {
    handleToken(newToken);
  };

  const logout = () => {
    localStorage.removeItem("authToken");
    setToken(null);
    setUser(null);
  };






  // sharedData
  const sharedData = {
    switchLang,
    direction,
    token,
    user,
    login,
    logout,
  };

  return (
    <AppContext.Provider value={sharedData}>
      {children}
    </AppContext.Provider>
  );
}

export default StateManagement;
