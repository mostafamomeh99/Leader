import { lazy } from "react";
const TopBarPath=lazy(()=> import("../../Components/TopBarPath/TopBarPath"))
import { AppContext } from "../../StateMangment";
import { useTranslation } from "react-i18next";
import { useState,useContext } from "react";
import styles from "./PathAddPage.module.css";
import { Route,Routes } from "react-router-dom";
import PathEditHome from "../../Components/PathEditHome/PathEditHome";
const Sidebar=lazy(() => import("../../Components/Sidebar/Sidebar"));
const PathEditInfo=lazy(() => import("../../Components/PathEditInfo/PathEditInfo"));
function PathAddPage() {
  const {t}=useTranslation()
  const {direction } = useContext(AppContext);

return(

<>

   <div className={styles.layout}     style={{
      flexDirection: direction === "rtl" ? "row-reverse" : "row",  
    }}>
     {/* Sidebar */}
     <Sidebar />

      {/* Main content */}
  <div className={styles.main}   style={{ direction: direction, }}>
  <TopBarPath/> 
<Routes>
  <Route path="/" element={<><PathEditHome/></>} />
    <Route path="/pathEditInfo" element={<><PathEditInfo/></>} />
</Routes>
       <div style={{height:"1000px"}}></div>
    
     </div>
  </div>
</>

)


}


  export default PathAddPage





