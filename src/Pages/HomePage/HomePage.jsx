import { lazy } from "react";
import Topbar from "../../Components/TopBar/Topbar";
import styles from "./HomePage.module.css";
import { AppContext } from "../../StateMangment";
import { useState,useContext } from "react";
import { useTranslation } from "react-i18next";
import {  Routes, Route, Router } from "react-router-dom";
import ScheduleCalls from "../../Components/ScheduleCalls/ScheduleCalls"
import UsersTableData from "../../Components/UsersTableData/UsersTableData";
import PathInfoAdd from "../../Components/PathInfoAdd/PathInfoAdd";
const CircleIndicator=lazy(() => import("../../Components/CircleIndicator/CircleIndicator"));
const UploadExcel=lazy(() => import("../../Components/UploadExcel/UploadExcel"));
const Home = lazy(() => import("../../Components/Home/Home"));
const Sidebar=lazy(() => import("../../Components/Sidebar/Sidebar"));
const StatsCard=lazy(() => import("../../Components/CallStatesCard/StatsCard"));
const TableData=lazy(() => import("../../Components/TableData/TableData"));
const DownloadOperation=lazy(()=> import("../../Components/Operation/DownloadOperation"))
const CategoriesTableData=lazy(()=> import("../../Components/CategoriesTableData/CategoriesTableData"))
const NewCategory=lazy(()=> import("../../Components/NewCategory/NewCategory"))
const CampaignTableData=lazy(()=> import("../../Components/CampaignTableData/CampaignTableData"))
const NewCampaign=lazy(()=> import("../../Components/NewCampaign/NewCampaign"))
const PathTableData=lazy(()=> import("../../Components/PathTableData/PathTableData"))
const PathPage=lazy(()=> import("../PathEditPage/PathEditPage"))

function HomePage() {
  const {t}=useTranslation()

  const {direction } = useContext(AppContext);
  return (
    <div className={styles.layout}     style={{
        flexDirection: direction === "rtl" ? "row-reverse" : "row",  
      }}>
      {/* Sidebar */}
      <Sidebar />

      {/* Main content */}
      <div className={styles.main}   style={{ direction: direction, }}>
              <Topbar />
          <Routes>
        <Route path="/" element={<>
      <Home/>
        
        </>} />





        
        <Route path="/calls" element={<ScheduleCalls />} />
        <Route path="/DownloadBenefits" element={<DownloadOperation />} />
        <Route path="/Register" element={<>  < UsersTableData/>  </>} />
              <Route path="/Categories" element={<>  < CategoriesTableData/>  </>} />
               <Route path="/newCategory" element={<>  <NewCategory/>  </>}/>
                <Route path="/newCategory/:categoryId" element={<>  <NewCategory/>  </>}/>
               <Route path="/Campaign" element={<><CampaignTableData/></>} />
                   <Route path="/NewCampaign/:campaignId" element={<><NewCampaign/></>} />
                   <Route path="/NewCampaign" element={<><NewCampaign/></>} />
                        <Route path="/path" element={<><PathTableData/></>} /> 
              
       <Route path="/addpath" element={<><PathInfoAdd/></>} /> 

      </Routes>
      
      </div>
    </div>
  );
}

export default HomePage;
