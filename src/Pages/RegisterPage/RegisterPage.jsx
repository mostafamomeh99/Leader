import { lazy } from "react";
import styles from "./RegisterPage.module.css";
import SideBar from "../../Components/SideBar/SideBar";
import { AppContext } from "../../StateMangment";
import { useState,useContext } from "react";


const Register = lazy(() => import("../../Components/Register/Register"));

function RegisterPage() {
  const {direction } = useContext(AppContext);
  return (
    <div className={styles.layout}     style={{
        flexDirection: direction === "rtl" ? "row-reverse" : "row", 
      }}>
      {/* Sidebar */}
      <SideBar />

      {/* Main content */}
      <div className={styles.main}   style={{
    direction: direction, 
  }}>
<Register/>
    
        <div style={{height:"1000px"}}></div>
      </div>
    </div>
  );
}

export default RegisterPage;
